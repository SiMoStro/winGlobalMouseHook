namespace MouseHookTest
{
    partial class MouseInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.w_lWParam = new System.Windows.Forms.Label();
            this.w_lLParam = new System.Windows.Forms.Label();
            this.w_lCode = new System.Windows.Forms.Label();
            this.w_lY = new System.Windows.Forms.Label();
            this.w_lX = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "LParam";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "WParam";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // w_lWParam
            // 
            this.w_lWParam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.w_lWParam.Location = new System.Drawing.Point(82, 65);
            this.w_lWParam.Name = "w_lWParam";
            this.w_lWParam.Size = new System.Drawing.Size(92, 25);
            this.w_lWParam.TabIndex = 5;
            this.w_lWParam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // w_lLParam
            // 
            this.w_lLParam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.w_lLParam.Location = new System.Drawing.Point(82, 40);
            this.w_lLParam.Name = "w_lLParam";
            this.w_lLParam.Size = new System.Drawing.Size(92, 25);
            this.w_lLParam.TabIndex = 4;
            this.w_lLParam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // w_lCode
            // 
            this.w_lCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.w_lCode.Location = new System.Drawing.Point(82, 15);
            this.w_lCode.Name = "w_lCode";
            this.w_lCode.Size = new System.Drawing.Size(92, 25);
            this.w_lCode.TabIndex = 3;
            this.w_lCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // w_lY
            // 
            this.w_lY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.w_lY.Location = new System.Drawing.Point(82, 115);
            this.w_lY.Name = "w_lY";
            this.w_lY.Size = new System.Drawing.Size(92, 25);
            this.w_lY.TabIndex = 9;
            this.w_lY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // w_lX
            // 
            this.w_lX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.w_lX.Location = new System.Drawing.Point(82, 90);
            this.w_lX.Name = "w_lX";
            this.w_lX.Size = new System.Drawing.Size(92, 25);
            this.w_lX.TabIndex = 8;
            this.w_lX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "Y";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(10, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "X";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MouseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 155);
            this.ControlBox = false;
            this.Controls.Add(this.w_lY);
            this.Controls.Add(this.w_lX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.w_lWParam);
            this.Controls.Add(this.w_lLParam);
            this.Controls.Add(this.w_lCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MouseInfo";
            this.Text = "Mouse info";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label w_lWParam;
        private System.Windows.Forms.Label w_lLParam;
        private System.Windows.Forms.Label w_lCode;
        private System.Windows.Forms.Label w_lY;
        private System.Windows.Forms.Label w_lX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}