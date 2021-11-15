using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Fee : Form
    {
        private string ID;
        public Fee(string id)
        {
            ID = id;
            InitializeComponent();
        }

        private void Pay_Click(object sender, EventArgs e)
        {
            DatabaseManager dbManager = new DatabaseManager();
            if (int.TryParse(FeeBox.Text, out int value))
            {
                dbManager.PayTheFees(ID, value);
            }
            else
            {
                MessageBox.Show("Incorrect value.");
            }
            this.Close();
        }
    }
}
