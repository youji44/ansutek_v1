using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Net;
using System.Runtime.InteropServices;

namespace OperatorUI
{
    public partial class Form1 : Form
    {
        private double scale;
        private double minRoll;
        private double maxRoll;
        private int num_remain = 0;
        private string bCode;
        private string pCode;
        private string pDesc;
        private int rQty = 0;
        private string roll_len;
        private string roll_width;
        private string rollPack;
        private string sqrMetric;
        private string norWeight;
        private string rVal;
        private string norThickness;
        private string lblFormatName;
        private string line1Desc;
        private string extTxtDesc;
        private string Img1Name;
        private string Img2Name;
        private int quantity = 1;
        private int label_number = 1;
        bool scannedProdcut = false;
        bool scannedBatch = false;
        bool scannedRQty = false;
        bool printingFinished = true;

        private string specInstruction;
        public Thread thread;
        public Thread printingThread;
        // private TcpClient _tcpClient;

        public ManualResetEvent allDone = new ManualResetEvent(false);
        public bool isFirst = true;

        private Scale myScale;

        BarTender.Format btFormat;
        BarTender.Messages btMsgs;
        BarTender.Application btApp;
        BarTender.BtPrintResult btResult;

        public Form1()
        {
            InitializeComponent();

            PasswordForm frm = new PasswordForm();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                // The user canceled.
                this.Close();
            }

            productTable.ReadOnly = true;
            PrintBtn.Enabled = false;
            readLog();
            btApp = new BarTender.Application();
            //thread = new Thread(StartListening);
            //thread.Start();

            myScale = new Scale("192.168.1.180", 1705);
            scaleTimer.Enabled = true; //Trigger weight update
        }


        private void scanInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string scanner = PUFA1550P.Text;
                if (Char.IsLetter(scanner[0])) ScanProductCode(scanner);
                else if ((scanner.Length >= 5) && Char.IsDigit(scanner[0]))
                {
                    batchCode.Text = scanner;
                    bCode = scanner;
                    scannedBatch = true;
                    PUFA1550P.Text = "";
                }
                else if ((scanner.Length <= 4) && Char.IsDigit(scanner[0]))
                {
                    rollQty.Text = scanner;
                    num_remain = Int16.Parse(scanner);
                    scannedRQty = true;
                    rQty = num_remain;
                    remain_num_lbl.Text = "Number of remaining labels\n" + num_remain.ToString();
                    PUFA1550P.Text = "";
                }
                else
                {
                    MessageBox.Show("Incorrect Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (scannedBatch && scannedProdcut && scannedRQty) PrintBtn.Enabled = true;
                else PrintBtn.Enabled = false;
            }
        }

        private void ScanProductCode(string scanner)
        {

            productCode.Text = scanner;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(@"C:\ansutek\productiondata.xlsx");           // WORKBOOK TO OPEN THE EXCEL FILE.
            Excel.Worksheet xlWorkSheet = xlWorkBook.Worksheets[1];

            int rowNum = xlWorkSheet.UsedRange.Rows.Count;
            int new_num = 1;
            product p = new product();
            List<product> products = new List<product>();
            for (int i = 2; i <= rowNum; i++)
            {
                if (xlWorkSheet.Cells[i, 1].value == null)
                {
                    break;
                }
                else
                {
                    if (scanner == xlWorkSheet.Cells[i, 2].value)
                    {
                        p.No = new_num;

                        pCode = xlWorkSheet.Cells[i, 2].value.ToString();
                        p.ProdcutCode = pCode;

                        pDesc = xlWorkSheet.Cells[i, 3].value.ToString();
                        p.ProductDescription = pDesc;

                        roll_len = xlWorkSheet.Cells[i, 4].value.ToString();
                        p.Length = roll_len;

                        roll_width = xlWorkSheet.Cells[i, 5].text.ToString();
                        rollPack = xlWorkSheet.Cells[i, 6].text.ToString();
                        sqrMetric = xlWorkSheet.Cells[i, 7].text.ToString();

                        norWeight = xlWorkSheet.Cells[i, 8].text.ToString();
                        p.NominalWeight = norWeight;
                        products.Add(p);


                        minRoll = xlWorkSheet.Cells[i, 9].value;
                        minRollBox.Text = minRoll.ToString();
                        maxRoll = xlWorkSheet.Cells[i, 10].value;
                        maxRollBox.Text = maxRoll.ToString();

                        rVal = xlWorkSheet.Cells[i, 11].text.ToString();
                        norThickness = xlWorkSheet.Cells[i, 12].text.ToString();

                        lblFormatName = xlWorkSheet.Cells[i, 13].value.ToString();
                        line1Desc = xlWorkSheet.Cells[i, 14].text.ToString();
                        extTxtDesc = xlWorkSheet.Cells[i, 15].text.ToString();

                        Img1Name = xlWorkSheet.Cells[i, 16].text.ToString();
                        Img2Name = xlWorkSheet.Cells[i, 17].text.ToString();

                        specInstruction = xlWorkSheet.Cells[i, 18].text.ToString();
                        isFirst = true;
                        break;
                    }
                }
            }
            productTable.DataSource = products;
            if (products.Count > 0) scannedProdcut = true;
            else
            {
                scannedProdcut = false;
                minRollBox.Text = "";
                maxRollBox.Text = "";
                MessageBox.Show("Product Code (" + PUFA1550P.Text + ") Could Not be Found Contact the Office", "PRODUCT CODE Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            xlApp.Quit();
            PUFA1550P.Text = "";
            if (isFirst);
            else
            {
                MessageBox.Show("SCAN WRONG ", "PRODUCT CODE Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isFirst = false;
            }
               
            }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            if (pCode == string.Empty)
            {
                PrintBtn.BackColor = Color.Orange;
                DialogResult prompt = MessageBox.Show("NO PRODUCT CODE \nCLICK OK TO CONTINUE", "!!!WARNING!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (prompt == DialogResult.OK) PrintBtn.BackColor = Color.FromArgb(68, 114, 196);
                // return;
            }

            if (bCode == string.Empty)
            {
                PrintBtn.BackColor = Color.Orange;
                DialogResult prompt = MessageBox.Show("NO BATCH CODE \nCLICK OK TO CONTINUE", "!!!WARNING!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (prompt == DialogResult.OK) PrintBtn.BackColor = Color.FromArgb(68, 114, 196);
                // return;
                
            }

            if (rollQty.Text == string.Empty)
            {
                PrintBtn.BackColor = Color.Orange;
                DialogResult prompt = MessageBox.Show("NO ROLL QTY \nCLICK OK TO CONTINUE", "!!!WARNING!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (prompt == DialogResult.OK) PrintBtn.BackColor = Color.FromArgb(68, 114, 196);
                // return;
            }
                     

            if ((scale >= minRoll) && (scale <= maxRoll))
            {
                PrintBtn.Enabled = false;
                printingFinished = false;
                instruc_lbl.Text = specInstruction;
                if (isFirst)
                {
                    MessageBox.Show(specInstruction, "Instruction", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                    isFirst = false;
                }
                // MessageBox.Show("Please wait for printing label.", "Printing");
                PrintBtn.BackColor = Color.Red;
                printingThread = new Thread(printingLabel);
                printingThread.Start();
                printingThread.Join();
                remain_num_lbl.Text = "Number of remaining labels\n" + num_remain.ToString();

            }
            else
            {
                PrintBtn.BackColor = Color.Red;
                DialogResult prompt = MessageBox.Show("WEIGHT OUTSIDE MIN/MAX\nNO LABEL PRINTED\nPRESS ENTER TO CONTINUE", "Weight Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (prompt == DialogResult.OK) PrintBtn.BackColor = Color.FromArgb(68, 114, 196);
            }

            //Thread.Sleep(2000)
            PrintBtn.BackColor = Color.FromArgb(68, 114, 196);
            Application.DoEvents();
            printingFinished = true;
            PrintBtn.Enabled = true;
            
        }

        private void printingLabel()
        {
            // 06/07/2022  Get data for filewrite prior to sending label to BT so that weight is correct 
            //btApp = new BarTender.Application();
            try
            {
                string formatFile = @"C:\ansutek\" + lblFormatName.Trim(' ') + ".btw";
                btFormat = btApp.Formats.Open(formatFile);
                btFormat.SetNamedSubStringValue("scale", scale.ToString());
                btFormat.SetNamedSubStringValue("minRoll", minRoll.ToString());
                btFormat.SetNamedSubStringValue("maxRoll", maxRoll.ToString());
                btFormat.SetNamedSubStringValue("num_remain", label_number.ToString());
                btFormat.SetNamedSubStringValue("pCode", pCode);
                btFormat.SetNamedSubStringValue("pDesc", pDesc);
                btFormat.SetNamedSubStringValue("rQty", rQty.ToString());
                btFormat.SetNamedSubStringValue("bCode", bCode);
                btFormat.SetNamedSubStringValue("roll_len", roll_len.ToString());
                btFormat.SetNamedSubStringValue("roll_width", roll_width.ToString());
                btFormat.SetNamedSubStringValue("roll_Pack", rollPack.ToString());
                btFormat.SetNamedSubStringValue("sqrMetric", sqrMetric.ToString());
                btFormat.SetNamedSubStringValue("line1Desc", line1Desc);
                btFormat.SetNamedSubStringValue("extTxtDesc", extTxtDesc);
                btFormat.SetNamedSubStringValue("Img1Name", Img1Name);
                btFormat.SetNamedSubStringValue("Barcode", Img2Name);
                btFormat.SetNamedSubStringValue("rVal", rVal.ToString());
                btFormat.SetNamedSubStringValue("norThickness", norThickness.ToString());
                btFormat.SetNamedSubStringValue("norWeight", norWeight.ToString());

                BarTender.BtPrintResult btResult = BarTender.BtPrintResult.btSuccess;
                int count = 0;
                btResult = btFormat.Print("job1", true, 5000, out btMsgs);
                while (btResult != BarTender.BtPrintResult.btSuccess)
                {
                    btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges);
                    if (count > 4)
                    {
                        DialogResult boxResult = MessageBox.Show("Label did not print. Please check and retry", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                        if (boxResult == DialogResult.Retry) count = 0;
                        else
                        {
                            count = 0;
                            break;
                        }
                    }
                    btResult = btFormat.Print("job1", true, 5000, out btMsgs);
                    count++;
                }
                if (btResult == BarTender.BtPrintResult.btSuccess)
                {
                    // decrement number remaining increment label number 
                    num_remain--;
                    string fileName = @"c:\ansutek\datatable.csv ";
                    string newLine = DateTime.Today.ToString("d/MM/yyyy") + ", " + DateTime.Now.TimeOfDay.ToString()
                        + ", " + pCode + ", " + bCode + ", " + scale.ToString() + ", " + label_number.ToString() + ", " + num_remain.ToString() + ", " + rQty.ToString() + Environment.NewLine;
                    if (!File.Exists(fileName))
                    {
                        string headerLine = "Date, Time, Product Code, Scan Batch Code, Displayed Weight, Label Number, Remain Number, Roll Qty" + Environment.NewLine;
                        File.WriteAllText(fileName, headerLine);
                    }
                    File.AppendAllText(fileName, newLine);
                    // increment number printed 
                    label_number++;
                }
            }
            catch (IOException ex)
            {
                //MessageBox.Show(ex.ToString());
                MessageBox.Show("Can't write the log since the file is opened by another program. Please close the program.");


            }
            catch (COMException ex)
            {
                MessageBox.Show("Print Label Failed, please check printer and try again", "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges);
            printingThread.Abort();
            
            }

            private void completeBtn_Click(object sender, EventArgs e)
        {
            minRoll = 0;
            maxRoll = 0;
            num_remain = 0;
            label_number = 1;
            pCode = "";
            bCode = "";
            specInstruction = "";
            PUFA1550P.Text = "";
            productCode.Text = "";
            batchCode.Text = "";
            rollQty.Text = "";
            minRollBox.Text = "";
            maxRollBox.Text = "";
            instruc_lbl.Text = "";
            remain_num_lbl.Text = "Number of remaining labels\n";
            productTable.DataSource = new List<product>();
            scannedRQty = false;
            scannedBatch = false;
            scannedProdcut = false;
            PrintBtn.Enabled = false;
            PUFA1550P.Focus();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp);
            //thread.Abort();
            Environment.Exit(0);
        }

        private void scaleTimer_Tick(object sender, EventArgs e)
        {
            myScale.TryGetScaleWeight(out string weight, out Exception err);

            if (err != null)
            {
                weighScale.Value = "Error";
                //Optional show the error here
                //If you're going to show an error, pause the tick event timer while waiting for user confirmation
                //MessageBox.Show(err.Message, "Scale Connection Error");
            }
            else if (weight == "-------") {
                weighScale.Value = weight;
                //PrintBtn.Enabled = false;
            } else if (Double.TryParse(weight, out double dWeight)) {
                weighScale.Value = weight;
                scale = dWeight;
                //if (printingFinished) PrintBtn.Enabled = true;
            }
            else
            {
                weighScale.Value = "Error";
            }
        }

        private void readLog()
        {
            string fileName = @"c:\ansutek\datatable.csv ";
            try
            {
                
                string[] lines = File.ReadAllLines(fileName);
                string[] lastlogs = lines[lines.Length - 1].Split(',');

                this.pCode = lastlogs[2];
                ScanProductCode(lastlogs[2].TrimStart(' '));
                if (pCode != "") scannedProdcut = true;

                this.bCode = lastlogs[3].TrimStart(' ');
                batchCode.Text = bCode;
                if (bCode != "") scannedBatch = true;

                //this.scale = Double.Parse(lastlogs[4]);
                weighScale.Value = ("Error");
                

                this.label_number = int.Parse(lastlogs[5]);
                label_number++;

                this.num_remain = int.Parse(lastlogs[6]);
                remain_num_lbl.Text = "Number of remaining labels\n" + num_remain.ToString();

                this.rQty = int.Parse(lastlogs[7]);
                rollQty.Text = lastlogs[7];
                if (lastlogs[7] != null) scannedRQty = true;

                if (scannedBatch && scannedProdcut && scannedRQty) PrintBtn.Enabled = true;
                else PrintBtn.Enabled = false;
            }
            catch (IOException e)
            {
                MessageBox.Show("Can't read the previous data since the file is opened by another program.");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}