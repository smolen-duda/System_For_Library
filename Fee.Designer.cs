
namespace Library
{
    partial class Fee
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
            this.FeeBox = new System.Windows.Forms.TextBox();
            this.Pay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "How much you pay?";
            // 
            // FeeBox
            // 
            this.FeeBox.Location = new System.Drawing.Point(15, 69);
            this.FeeBox.Name = "FeeBox";
            this.FeeBox.Size = new System.Drawing.Size(156, 22);
            this.FeeBox.TabIndex = 1;
            // 
            // Pay
            // 
            this.Pay.Location = new System.Drawing.Point(112, 114);
            this.Pay.Name = "Pay";
            this.Pay.Size = new System.Drawing.Size(92, 31);
            this.Pay.TabIndex = 2;
            this.Pay.Text = "Pay";
            this.Pay.UseVisualStyleBackColor = true;
            this.Pay.Click += new System.EventHandler(this.Pay_Click);
            // 
            // Fee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 173);
            this.Controls.Add(this.Pay);
            this.Controls.Add(this.FeeBox);
            this.Controls.Add(this.label1);
            this.Name = "Fee";
            this.Text = "Fee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FeeBox;
        private System.Windows.Forms.Button Pay;
    }
}