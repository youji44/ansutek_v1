
namespace OperatorUI
{
    partial class PasswordForm
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
            this.pw_lbl = new System.Windows.Forms.Label();
            this.pw_txt = new System.Windows.Forms.TextBox();
            this.ok_Btn = new System.Windows.Forms.Button();
            this.cancel_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pw_lbl
            // 
            this.pw_lbl.AutoSize = true;
            this.pw_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pw_lbl.Location = new System.Drawing.Point(21, 26);
            this.pw_lbl.Name = "pw_lbl";
            this.pw_lbl.Size = new System.Drawing.Size(101, 16);
            this.pw_lbl.TabIndex = 0;
            this.pw_lbl.Text = "Operator Logon";
            // 
            // pw_txt
            // 
            this.pw_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pw_txt.Location = new System.Drawing.Point(24, 45);
            this.pw_txt.Name = "pw_txt";
            this.pw_txt.PasswordChar = '*';
            this.pw_txt.Size = new System.Drawing.Size(271, 22);
            this.pw_txt.TabIndex = 1;
            // 
            // ok_Btn
            // 
            this.ok_Btn.Location = new System.Drawing.Point(139, 91);
            this.ok_Btn.Name = "ok_Btn";
            this.ok_Btn.Size = new System.Drawing.Size(75, 30);
            this.ok_Btn.TabIndex = 2;
            this.ok_Btn.Text = "OK";
            this.ok_Btn.UseVisualStyleBackColor = true;
            this.ok_Btn.Click += new System.EventHandler(this.ok_Btn_Click);
            // 
            // cancel_Btn
            // 
            this.cancel_Btn.Location = new System.Drawing.Point(220, 91);
            this.cancel_Btn.Name = "cancel_Btn";
            this.cancel_Btn.Size = new System.Drawing.Size(75, 30);
            this.cancel_Btn.TabIndex = 3;
            this.cancel_Btn.Text = "Cancel";
            this.cancel_Btn.UseVisualStyleBackColor = true;
            this.cancel_Btn.Click += new System.EventHandler(this.cancel_Btn_Click);
            // 
            // PasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 148);
            this.Controls.Add(this.cancel_Btn);
            this.Controls.Add(this.ok_Btn);
            this.Controls.Add(this.pw_txt);
            this.Controls.Add(this.pw_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TEXTILE Products OPERATOR Logon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pw_lbl;
        private System.Windows.Forms.TextBox pw_txt;
        private System.Windows.Forms.Button ok_Btn;
        private System.Windows.Forms.Button cancel_Btn;
    }
}