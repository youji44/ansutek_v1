
namespace OperatorUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PUFA1550P = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.productCode = new System.Windows.Forms.TextBox();
            this.batchCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rollQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maxRollBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.minRollBox = new System.Windows.Forms.TextBox();
            this.productTable = new System.Windows.Forms.DataGridView();
            this.completeBtn = new System.Windows.Forms.Button();
            this.PrintBtn = new System.Windows.Forms.Button();
            this.remain_num_lbl = new System.Windows.Forms.Label();
            this.instruc_lbl = new System.Windows.Forms.Label();
            this.scaleTimer = new System.Windows.Forms.Timer(this.components);
            this.weighScale = new DmitryBrant.CustomControls.SevenSegmentArray();
            ((System.ComponentModel.ISupportInitialize)(this.productTable)).BeginInit();
            this.SuspendLayout();
            // 
            // PUFA1550P
            // 
            this.PUFA1550P.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.PUFA1550P.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PUFA1550P.ForeColor = System.Drawing.SystemColors.Info;
            this.PUFA1550P.Location = new System.Drawing.Point(481, 229);
            this.PUFA1550P.Name = "PUFA1550P";
            this.PUFA1550P.Size = new System.Drawing.Size(361, 62);
            this.PUFA1550P.TabIndex = 1;
            this.PUFA1550P.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PUFA1550P.KeyDown += new System.Windows.Forms.KeyEventHandler(this.scanInput_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(411, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Scan Product Code";
            // 
            // productCode
            // 
            this.productCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.productCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productCode.Location = new System.Drawing.Point(565, 306);
            this.productCode.Name = "productCode";
            this.productCode.ReadOnly = true;
            this.productCode.Size = new System.Drawing.Size(130, 23);
            this.productCode.TabIndex = 3;
            // 
            // batchCode
            // 
            this.batchCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.batchCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.batchCode.Location = new System.Drawing.Point(565, 332);
            this.batchCode.Name = "batchCode";
            this.batchCode.ReadOnly = true;
            this.batchCode.Size = new System.Drawing.Size(130, 23);
            this.batchCode.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(426, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Scan Batch Code";
            // 
            // rollQty
            // 
            this.rollQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rollQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollQty.Location = new System.Drawing.Point(565, 358);
            this.rollQty.Name = "rollQty";
            this.rollQty.ReadOnly = true;
            this.rollQty.Size = new System.Drawing.Size(130, 23);
            this.rollQty.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(444, 358);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Scan Roll QTY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(778, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 9);
            this.label4.TabIndex = 8;
            this.label4.Text = "Max Roll Weight";
            // 
            // maxRollBox
            // 
            this.maxRollBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.maxRollBox.Location = new System.Drawing.Point(780, 319);
            this.maxRollBox.Name = "maxRollBox";
            this.maxRollBox.ReadOnly = true;
            this.maxRollBox.Size = new System.Drawing.Size(100, 20);
            this.maxRollBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(778, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 9);
            this.label5.TabIndex = 10;
            this.label5.Text = "Min Roll Weight";
            // 
            // minRollBox
            // 
            this.minRollBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.minRollBox.Location = new System.Drawing.Point(780, 361);
            this.minRollBox.Name = "minRollBox";
            this.minRollBox.ReadOnly = true;
            this.minRollBox.Size = new System.Drawing.Size(100, 20);
            this.minRollBox.TabIndex = 11;
            // 
            // productTable
            // 
            this.productTable.AllowUserToAddRows = false;
            this.productTable.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.productTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productTable.Location = new System.Drawing.Point(399, 398);
            this.productTable.Name = "productTable";
            this.productTable.RowHeadersVisible = false;
            this.productTable.RowHeadersWidth = 4;
            this.productTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.productTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.productTable.Size = new System.Drawing.Size(500, 76);
            this.productTable.TabIndex = 12;
            // 
            // completeBtn
            // 
            this.completeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(90)))), ((int)(((byte)(17)))));
            this.completeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.completeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.completeBtn.Location = new System.Drawing.Point(399, 493);
            this.completeBtn.Name = "completeBtn";
            this.completeBtn.Size = new System.Drawing.Size(128, 68);
            this.completeBtn.TabIndex = 13;
            this.completeBtn.Text = "Complete";
            this.completeBtn.UseVisualStyleBackColor = false;
            this.completeBtn.Click += new System.EventHandler(this.completeBtn_Click);
            // 
            // PrintBtn
            // 
            this.PrintBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(114)))), ((int)(((byte)(196)))));
            this.PrintBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.PrintBtn.Location = new System.Drawing.Point(771, 493);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(128, 70);
            this.PrintBtn.TabIndex = 14;
            this.PrintBtn.Text = "Print";
            this.PrintBtn.UseVisualStyleBackColor = false;
            this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // remain_num_lbl
            // 
            this.remain_num_lbl.AutoSize = true;
            this.remain_num_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(114)))), ((int)(((byte)(196)))));
            this.remain_num_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remain_num_lbl.ForeColor = System.Drawing.SystemColors.Window;
            this.remain_num_lbl.Location = new System.Drawing.Point(546, 510);
            this.remain_num_lbl.MaximumSize = new System.Drawing.Size(200, 38);
            this.remain_num_lbl.MinimumSize = new System.Drawing.Size(200, 38);
            this.remain_num_lbl.Name = "remain_num_lbl";
            this.remain_num_lbl.Size = new System.Drawing.Size(200, 38);
            this.remain_num_lbl.TabIndex = 15;
            this.remain_num_lbl.Text = "Number of remaning labels:";
            this.remain_num_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // instruc_lbl
            // 
            this.instruc_lbl.AutoSize = true;
            this.instruc_lbl.BackColor = System.Drawing.SystemColors.Control;
            this.instruc_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.instruc_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instruc_lbl.Location = new System.Drawing.Point(399, 581);
            this.instruc_lbl.MaximumSize = new System.Drawing.Size(500, 100);
            this.instruc_lbl.MinimumSize = new System.Drawing.Size(500, 100);
            this.instruc_lbl.Name = "instruc_lbl";
            this.instruc_lbl.Size = new System.Drawing.Size(500, 100);
            this.instruc_lbl.TabIndex = 16;
            this.instruc_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // scaleTimer
            // 
            this.scaleTimer.Tick += new System.EventHandler(this.scaleTimer_Tick);
            // 
            // weighScale
            // 
            this.weighScale.ArrayCount = 5;
            this.weighScale.ColorBackground = System.Drawing.Color.Black;
            this.weighScale.ColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(24)))), ((int)(((byte)(3)))));
            this.weighScale.ColorLight = System.Drawing.Color.Red;
            this.weighScale.DecimalShow = true;
            this.weighScale.ElementPadding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.weighScale.ElementWidth = 10;
            this.weighScale.ItalicFactor = -0.07F;
            this.weighScale.Location = new System.Drawing.Point(348, 12);
            this.weighScale.Name = "weighScale";
            this.weighScale.Size = new System.Drawing.Size(647, 211);
            this.weighScale.TabIndex = 0;
            this.weighScale.TabStop = false;
            this.weighScale.Value = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 692);
            this.ControlBox = false;
            this.Controls.Add(this.instruc_lbl);
            this.Controls.Add(this.remain_num_lbl);
            this.Controls.Add(this.PrintBtn);
            this.Controls.Add(this.completeBtn);
            this.Controls.Add(this.productTable);
            this.Controls.Add(this.minRollBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maxRollBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rollQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.batchCode);
            this.Controls.Add(this.productCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PUFA1550P);
            this.Controls.Add(this.weighScale);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ANSUTEK COMMERCIAL LTD  - www.ansutek.co.nz - 0800 27 26 26";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DmitryBrant.CustomControls.SevenSegmentArray weighScale;
        private System.Windows.Forms.TextBox PUFA1550P;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox productCode;
        private System.Windows.Forms.TextBox batchCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rollQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox maxRollBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox minRollBox;
        private System.Windows.Forms.DataGridView productTable;
        private System.Windows.Forms.Button completeBtn;
        private System.Windows.Forms.Button PrintBtn;
        private System.Windows.Forms.Label remain_num_lbl;
        private System.Windows.Forms.Label instruc_lbl;
        private System.Windows.Forms.Timer scaleTimer;
    }
}

