
namespace Library
{
    partial class FindBook
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
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.AuthorBox = new System.Windows.Forms.TextBox();
            this.YearBox = new System.Windows.Forms.TextBox();
            this.ISBNBox = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Action = new Library.DataGridViewDisableButtonColumn();
            this.Return = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Author";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(21, 107);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(38, 17);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Year";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(21, 149);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(39, 17);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "ISBN";
            // 
            // TitleBox
            // 
            this.TitleBox.Location = new System.Drawing.Point(93, 21);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(514, 22);
            this.TitleBox.TabIndex = 4;
            // 
            // AuthorBox
            // 
            this.AuthorBox.Location = new System.Drawing.Point(93, 60);
            this.AuthorBox.Name = "AuthorBox";
            this.AuthorBox.Size = new System.Drawing.Size(514, 22);
            this.AuthorBox.TabIndex = 5;
            // 
            // YearBox
            // 
            this.YearBox.Location = new System.Drawing.Point(93, 102);
            this.YearBox.Name = "YearBox";
            this.YearBox.Size = new System.Drawing.Size(514, 22);
            this.YearBox.TabIndex = 6;
            // 
            // ISBNBox
            // 
            this.ISBNBox.Location = new System.Drawing.Point(93, 149);
            this.ISBNBox.Name = "ISBNBox";
            this.ISBNBox.Size = new System.Drawing.Size(514, 22);
            this.ISBNBox.TabIndex = 7;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(678, 44);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(127, 38);
            this.Search.TabIndex = 8;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(1192, 351);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(103, 41);
            this.Back.TabIndex = 9;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action});
            this.dataGridView1.Location = new System.Drawing.Point(24, 202);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1144, 190);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.MinimumWidth = 6;
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Text = "Choose";
            this.Action.UseColumnTextForButtonValue = true;
            this.Action.Width = 125;
            // 
            // Return
            // 
            this.Return.Location = new System.Drawing.Point(678, 107);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(127, 38);
            this.Return.TabIndex = 11;
            this.Return.Text = "Return to all books";
            this.Return.UseVisualStyleBackColor = true;
            this.Return.Click += new System.EventHandler(this.Return_Click);
            // 
            // FindBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 438);
            this.Controls.Add(this.Return);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.ISBNBox);
            this.Controls.Add(this.YearBox);
            this.Controls.Add(this.AuthorBox);
            this.Controls.Add(this.TitleBox);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FindBook";
            this.Text = "Find book form";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.TextBox AuthorBox;
        private System.Windows.Forms.TextBox YearBox;
        private System.Windows.Forms.TextBox ISBNBox;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataGridViewDisableButtonColumn Action;
        private System.Windows.Forms.Button Return;
    }
}