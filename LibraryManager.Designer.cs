
namespace Library
{
    partial class LibraryManager
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
            this.ExitButton = new System.Windows.Forms.Button();
            this.SeedData = new System.Windows.Forms.Button();
            this.FindBook = new System.Windows.Forms.Button();
            this.FindReader = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(330, 138);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(138, 53);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SeedData
            // 
            this.SeedData.Location = new System.Drawing.Point(330, 59);
            this.SeedData.Name = "SeedData";
            this.SeedData.Size = new System.Drawing.Size(138, 55);
            this.SeedData.TabIndex = 1;
            this.SeedData.Text = "Seed default data";
            this.SeedData.UseVisualStyleBackColor = true;
            this.SeedData.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FindBook
            // 
            this.FindBook.Location = new System.Drawing.Point(25, 39);
            this.FindBook.Name = "FindBook";
            this.FindBook.Size = new System.Drawing.Size(128, 62);
            this.FindBook.TabIndex = 2;
            this.FindBook.Text = "Find Book";
            this.FindBook.UseVisualStyleBackColor = true;
            this.FindBook.Click += new System.EventHandler(this.FindBook_Click);
            // 
            // FindReader
            // 
            this.FindReader.Location = new System.Drawing.Point(25, 138);
            this.FindReader.Name = "FindReader";
            this.FindReader.Size = new System.Drawing.Size(128, 62);
            this.FindReader.TabIndex = 3;
            this.FindReader.Text = "Find Reader";
            this.FindReader.UseVisualStyleBackColor = true;
            this.FindReader.Click += new System.EventHandler(this.FindReader_Click);
            // 
            // LibraryManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 289);
            this.Controls.Add(this.FindReader);
            this.Controls.Add(this.FindBook);
            this.Controls.Add(this.SeedData);
            this.Controls.Add(this.ExitButton);
            this.Name = "LibraryManager";
            this.Text = "LibraryManager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button SeedData;
        private System.Windows.Forms.Button FindBook;
        private System.Windows.Forms.Button FindReader;
    }
}

