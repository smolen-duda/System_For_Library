using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CsvHelper;

namespace Library
{
    public partial class LibraryManager : Form
    {
        public LibraryManager()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            DatabaseManager dbManager = new DatabaseManager();
            dbManager.SeedData();

        }

        private void FindBook_Click(object sender, EventArgs e)
        {
            FindBook findBook = new FindBook();
            findBook.Show();

            // Disabling button of default nul record.
            findBook.CheckButtons();
        }

        private void FindReader_Click(object sender, EventArgs e)
        {
            //List<Copy> nullList = new List<Copy>();
            BorrowBook borrowBook = new BorrowBook();
            borrowBook.Show();
            borrowBook.CheckButtons();
            borrowBook.CheckCombo();

        }

        private void Pay_Click(object sender, EventArgs e)
        {

        }
    }
}
