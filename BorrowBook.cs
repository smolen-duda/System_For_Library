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
    public partial class BorrowBook : Form
    {
        private bool counter = true;
        private List<Copy> copies;
        private string checkingIfRecordisNull;
        private DataGridView dataGridView { get; }
        private int rowIndex;

        public BorrowBook(List<Copy> choosenCopies, DataGridView dataGridView10, int row)
        {
            InitializeComponent();

            dataGridView = dataGridView10;
            rowIndex = row;
            copies = choosenCopies;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            Search1.Visible = true;
            Search.Visible = false;


            // Displays an empty row and column headers. Just for good appearance.
            List<object> booksToDisplay = new List<object>()
            {  new {
                    ID = (string)null,
                    Name=(string)null,
                    Surname=(string)null,
                    Phone =(string)null,
                    Fees= (int?)null
                    }
            };

            dataGridView1.DataSource = booksToDisplay;
            dataGridView1.Columns["Action"].DisplayIndex = 5;
        }

        public BorrowBook()
        {
            InitializeComponent();
            Save.Visible = false;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            Search.Visible = true;
            Search1.Visible = false;

            // Displays an empty row and column headers. Just for good appearance.
            List<object> booksToDisplay = new List<object>()
            {  new {
                    ID = (string)null,
                    Name=(string)null,
                    Surname=(string)null,
                    Phone =(string)null,
                    Fees= (int?)null
                    }
            };

            dataGridView1.DataSource = booksToDisplay;
            dataGridView1.Columns["Action"].DisplayIndex = 5;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //
        //
        //
        //
        //

        private void Search_Click(object sender, EventArgs e)
        {
            counter = false;
            Action.Items.Clear();
            DatabaseManager dbManager = new DatabaseManager();
            List<Reader> readers = dbManager.FindReaders(NameBox.Text, SurnameBox.Text, IDBox.Text);

            dataGridView1.Visible = true;
            dataGridView2.Visible = false;

            dataGridView1.DataSource = Display(readers);
            dataGridView1.Columns["Action"].DisplayIndex = 5;
            Action.Items.AddRange("Pay the fees", "Show borrowings");

           
            if (readers.Count == 0)
            {
                CheckButtons();
            }
        }

        //
        //
        //
        //
        //

        private void Search1_Click(object sender, EventArgs e)
        {
            counter = true;
            DatabaseManager dbManager = new DatabaseManager();
            List<Reader> readers = dbManager.FindReaders(NameBox.Text, SurnameBox.Text, IDBox.Text);

            dataGridView1.Visible = false;
            dataGridView2.Visible = true;

            dataGridViewDisableButtonColumn1.Text = "Choose";
            dataGridView2.DataSource = Display(readers);
            dataGridView2.Columns["dataGridViewDisableButtonColumn1"].DisplayIndex = 5;

            if (readers.Count == 0)
            {
                CheckButtons();
            }
        }


        //
        //
        //
        //
        //

        public void CheckButtons()
        {
            DataGridViewDisableButtonCell btn = new DataGridViewDisableButtonCell();
           // btn.CheckButtons(dataGridView1);
            btn.CheckButtons(dataGridView2);
        }
        //
        //
        //
        //
        //
        public void CheckCombo()
        {
            DataGridViewDisableComboBoxCell combo = new DataGridViewDisableComboBoxCell();
            combo.CheckCombo(dataGridView1);
        }

        //
        //
        //
        //
        //

        private List<object> Display(List<Reader> readers)
        {
            // Preparing data for displaying.

            List<object> readersToDisplay = new List<object>();

            if (readers.Count == 0)
            { // Only for displaying purposes.
                var temp = new
                {
                    ID = (string)null,
                    Name = (string)null,
                    Surname = (string)null,
                    Phone = (string)null,
                    Fees = (int?)null
                };
                readersToDisplay.Add(temp);
                counter = true;
            }
            else
            {

                foreach (Reader reader in readers)
                {
                    string phone = null;
                    foreach (PhoneNumber number in reader.PhoneNumbers)
                    {
                        phone += number.Number + " ";
                    }
                    object temp = new
                    {
                        ID = reader.IDNumber,
                        Name = reader.Name,
                        Surname = reader.Surname,
                        Phone = phone,
                        Fees = reader.Fees

                    };
                    readersToDisplay.Add(temp);

                }
            }
            return readersToDisplay;

        }
        //
        //
        //
        //
        //

        private (List<object>,List<int>) Display(List<Borrowing> borrowings)
        {
            List<object> toDisplay = new List<object>();
            List<int> counters = new List<int>();

            if (borrowings.Count == 0)
            { // Only for displaying purposes.
                var temp = new
                {
                    ID = (string)null,
                    Book = (string)null,
                    CopyID = (int?)null,
                    DateOfTaking = (DateTime?)null,
                    DateOfBack = (DateTime?)null,
                    DateOFBack_Expected = (DateTime?)null,
                };
                toDisplay.Add(temp);
            }
            else
            {
                DatabaseManager dbManager = new DatabaseManager();
                foreach (Borrowing borrowing in borrowings)
                {
                    Copy copy = dbManager.GetCopy(borrowing);

                    var temp = new
                    {
                        ID = borrowing.BorrowingID,
                        Book = dbManager.GetBook(copy).Title,
                        CopyID = copy.CopyID,
                        DateOfTaking = borrowing.DateOfTaking,
                        DateOfBack = borrowing.DateOfBack,
                        DateOFBack_Expected = borrowing.DateOfBack_Expected,
                    };
                    toDisplay.Add(temp);

                    if (borrowing.DateOfBack == null)
                    {
                        counters.Add(0);
                    }
                    else
                    {
                        counters.Add(1);
                    }


                }
            }
            return (toDisplay,counters);
        }

        //
        //
        //
        //
        //



        // This event handler manually raises the CellValueChanged event 
        // by calling the CommitEdit method. 
        void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int row=e.RowIndex;
            if (row<0)
            {
                row=0;
            }
            
            // My combobox column is the second one so I hard coded a 1, flavor to taste
            DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dataGridView1.Rows[row].Cells[0];
            if (cb.Value != null)
            {
                // do stuff
                dataGridView1.Invalidate();
                var action = cb.EditedFormattedValue;

                var rowIndex = e.RowIndex;
                checkingIfRecordisNull = Convert.ToString(dataGridView1.Rows[rowIndex].Cells[1].Value);
               
                int fees = int.Parse(Convert.ToString(dataGridView1.Rows[rowIndex].Cells[5].Value));

                switch(action)
                {
                    case "Pay the fees":
                        if (!String.IsNullOrEmpty(checkingIfRecordisNull))
                        {
                            if (fees == 0)
                            {
                                MessageBox.Show("There are no fees to pay.");
                            }
                            else
                            {
                                Fee fee = new Fee(checkingIfRecordisNull);
                                fee.Show();
                            }
                        }
                        else
                        {
                            // Null record is displayed.
                        }
                        break;

                    case "Show borrowings":
                        List<Borrowing> borrowings = new List<Borrowing>();


                        if (!String.IsNullOrEmpty(checkingIfRecordisNull))
                        {
                            DatabaseManager dbManager = new DatabaseManager();
                            if (counter == false)
                            {
                                borrowings = dbManager.GetBorrowingsForReader(checkingIfRecordisNull);
                                (List<object> data, List<int> counters) = Display(borrowings);
                                dataGridView2.DataSource = data;
                                dataGridView2.Columns["dataGridViewDisableButtonColumn1"].DisplayIndex = 6;
                                dataGridViewDisableButtonColumn1.Text = "Give back";
                                dataGridView2.Visible = true;
                                dataGridView1.Visible = false;
                                counter = true;

                                if (borrowings.Count == 0)
                                {
                                    CheckButtons();
                                }
                                else
                                {
                                    DataGridViewDisableButtonCell dbtn = new DataGridViewDisableButtonCell();
                                    dbtn.CheckButtons(dataGridView2, counters);
                                }
                            } 

                        }
                        else
                        {
                            // Null record is displayed.
                        }
                        break;
                }

            }
        
        }

        //
        //
        //
        //
        //
        

        private void Save_Click(object sender, EventArgs e)
        {
            DatabaseManager dbManager = new DatabaseManager();
            Reader reader = new Reader();
            Copy copy = copies[0];

            if (counter == true)
            {
                reader = dbManager.GetReader(checkingIfRecordisNull);
                dbManager.NewBorrowing(reader, copy);
            }

            DataGridViewDisableButtonCell btn = (DataGridViewDisableButtonCell)dataGridView.Rows[rowIndex].Cells[0];
            btn.Enabled = false;
            FindBook.counter = true;

            this.Close();

        }

        //
        //
        //
        //
        //

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(counter==true)
            {
                var rowIndex = e.RowIndex;
                DatabaseManager dbManager = new DatabaseManager();

                checkingIfRecordisNull = Convert.ToString(dataGridView2.Rows[rowIndex].Cells[1].Value);
                DataGridViewDisableButtonCell btn = (DataGridViewDisableButtonCell)dataGridView2.Rows[rowIndex].Cells[0];
                if (btn.Enabled == true)
                {
                    if(Search1.Visible==true)
                    {
                        var fees = int.Parse(Convert.ToString(dataGridView2.Rows[rowIndex].Cells[5].Value));
                        if(fees==0)
                        {
                            counter = true;
                            string title = copies[0].Book.Title;
                            string takingDate = DateTime.UtcNow.ToString("dd-MM-yyyy");
                            string backDate = DateTime.UtcNow.AddDays(30).ToString("dd-MM-yyyy");

                            TitleLabel.Text = title;
                            TakingDateLabel.Text = takingDate;
                            BackDateLabel.Text = backDate;
                        }
                        else
                        {
                            MessageBox.Show("First pay all the fees");
                        }
                    }
                    else
                    {
                        dbManager.GiveBack(checkingIfRecordisNull);
                        MessageBox.Show("Complete.");
                    }
                    
                }
                else
                {
                    // Button is disabled.
                }
            }


        }

    }
}