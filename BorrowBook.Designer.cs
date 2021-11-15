
namespace Library
{
    partial class BorrowBook
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
            this.Cancel = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.SurnameBox = new System.Windows.Forms.TextBox();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TakingDateLabel = new System.Windows.Forms.Label();
            this.BackDateLabel = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewDisableButtonColumn1 = new Library.DataGridViewDisableButtonColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Action = new Library.DataGridViewDisableComboBoxColumn();
            this.Search1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(1053, 364);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(110, 53);
            this.Cancel.TabIndex = 0;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(136, 71);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(299, 22);
            this.NameBox.TabIndex = 1;
            // 
            // SurnameBox
            // 
            this.SurnameBox.Location = new System.Drawing.Point(136, 115);
            this.SurnameBox.Name = "SurnameBox";
            this.SurnameBox.Size = new System.Drawing.Size(299, 22);
            this.SurnameBox.TabIndex = 2;
            // 
            // IDBox
            // 
            this.IDBox.Location = new System.Drawing.Point(136, 160);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(299, 22);
            this.IDBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Surname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(24, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Reader data";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(1053, 292);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(109, 51);
            this.Save.TabIndex = 9;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(1053, 71);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(109, 51);
            this.Search.TabIndex = 10;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(565, 71);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(0, 17);
            this.TitleLabel.TabIndex = 11;
            // 
            // TakingDateLabel
            // 
            this.TakingDateLabel.AutoSize = true;
            this.TakingDateLabel.Location = new System.Drawing.Point(565, 120);
            this.TakingDateLabel.Name = "TakingDateLabel";
            this.TakingDateLabel.Size = new System.Drawing.Size(0, 17);
            this.TakingDateLabel.TabIndex = 12;
            // 
            // BackDateLabel
            // 
            this.BackDateLabel.AutoSize = true;
            this.BackDateLabel.Location = new System.Drawing.Point(565, 165);
            this.BackDateLabel.Name = "BackDateLabel";
            this.BackDateLabel.Size = new System.Drawing.Size(0, 17);
            this.BackDateLabel.TabIndex = 13;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewDisableButtonColumn1});
            this.dataGridView2.Location = new System.Drawing.Point(27, 230);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(997, 187);
            this.dataGridView2.TabIndex = 14;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // dataGridViewDisableButtonColumn1
            // 
            this.dataGridViewDisableButtonColumn1.HeaderText = "Action";
            this.dataGridViewDisableButtonColumn1.MinimumWidth = 6;
            this.dataGridViewDisableButtonColumn1.Name = "dataGridViewDisableButtonColumn1";
            this.dataGridViewDisableButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDisableButtonColumn1.Text = "Choose";
            this.dataGridViewDisableButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewDisableButtonColumn1.Width = 125;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action});
            this.dataGridView1.Location = new System.Drawing.Point(27, 230);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(997, 187);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.MinimumWidth = 6;
            this.Action.Name = "Action";
            this.Action.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Action.Width = 125;
            // 
            // Search1
            // 
            this.Search1.Location = new System.Drawing.Point(1053, 71);
            this.Search1.Name = "Search1";
            this.Search1.Size = new System.Drawing.Size(109, 51);
            this.Search1.TabIndex = 15;
            this.Search1.Text = "Search";
            this.Search1.UseVisualStyleBackColor = true;
            this.Search1.Click += new System.EventHandler(this.Search1_Click);
            // 
            // BorrowBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 450);
            this.Controls.Add(this.Search1);
            this.Controls.Add(this.BackDateLabel);
            this.Controls.Add(this.TakingDateLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IDBox);
            this.Controls.Add(this.SurnameBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BorrowBook";
            this.Text = "BorrowBook";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox SurnameBox;
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label TakingDateLabel;
        private System.Windows.Forms.Label BackDateLabel;
        private System.Windows.Forms.DataGridView dataGridView2;
        private DataGridViewDisableButtonColumn dataGridViewDisableButtonColumn1;
        private DataGridViewDisableComboBoxColumn Action;
        private System.Windows.Forms.Button Search1;
    }
}