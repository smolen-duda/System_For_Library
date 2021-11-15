using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms.VisualStyles;

namespace Library
{
    public partial class FindBook : Form
    {
        List<Copy> copies = new List<Copy>();
        public static bool counter = true;
        List<object> booksToDisplay = new List<object>();

        public FindBook()
        {
            InitializeComponent();

            // Displays an empty row and column headers. Just for good appearance.
            List<object> booksToDisplay = new List<object>()
            {  new {
                    BookID = (int?)null,
                    Title = (string)null,
                    Author = (string)null,
                    Year = (int?)null,
                    ISBN = (string)null,
                    Topic = (string)null
                    }
            };

            dataGridView1.DataSource = booksToDisplay;
            dataGridView1.Columns["Action"].DisplayIndex = 6;

        }

        //
        //
        //
        //

        private void Search_Click(object sender, EventArgs e)
        {
            DatabaseManager dbManager = new DatabaseManager();
            counter = false;

            List<Book> books = dbManager.FindBook(TitleBox.Text, AuthorBox.Text, YearBox.Text, ISBNBox.Text);

            foreach (Book book in books)
            {
                object temp = new
                {
                    BookID = book.BookID,
                    Title = book.Title,
                    Author = book.Author,
                    Year = book.Year,
                    ISBN = book.ISBN,
                    Topic = book.Topic.Name
                };
                booksToDisplay.Add(temp);
            }


            // This prevents bugs connected to the case when searched books does not exist.

            if (booksToDisplay.Count == 0)
            {
                object temp = new
                {
                    BookID = (int?)null,
                    Title = (string)null,
                    Author = (string)null,
                    Year = (int?)null,
                    ISBN = (string)null,
                    Topic = (string)null
                };
                booksToDisplay.Add(temp);

                dataGridView1.DataSource = booksToDisplay;
                dataGridView1.Columns["Action"].DisplayIndex = 6;

                DataGridViewDisableButtonCell btn = (DataGridViewDisableButtonCell)dataGridView1.Rows[0].Cells[0];
                btn.CheckButtons(this.dataGridView1);
                counter = true;

            }
            else
            {
                dataGridView1.DataSource = booksToDisplay;
                dataGridView1.Columns["Action"].DisplayIndex = 6;
            }

        }

        //
        //
        //
        //
        //

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            // Finding all copies of the choosen book.
            

            if (counter == false)
            {
                // Displaying all copies of the choosen book.
                copies = FindCopies(senderGrid, e);
                DisplayCopies(copies);

                counter =true;
            }
            else
            {
                // If it is possible borrows or reserves the book.

                var rowIndex = e.RowIndex;
                var checkingIfRecordisNull = Convert.ToString(dataGridView1.Rows[rowIndex].Cells[1].Value);
                List<Copy> choosenCopies = new List<Copy>();

                if (!String.IsNullOrEmpty(checkingIfRecordisNull))
                {
                    DataGridViewDisableButtonCell btn = (DataGridViewDisableButtonCell)dataGridView1.Rows[rowIndex].Cells[0];

                    if (btn.Enabled == true)
                    {
                        Copy copy = SelectCopy(senderGrid, e, copies);
                        choosenCopies.Add(copy);

                        BorrowBook borrowBook = new BorrowBook(choosenCopies,this.dataGridView1,rowIndex);
                        borrowBook.Show();
                        borrowBook.CheckButtons();
                    }
                    else
                    {
                        // Button is disabled.
                    }
                }
                else
                {
                    // Null record is displayed.
                }

            }
        }

        //
        //
        //
        //
        //

        private List<Copy> FindCopies(DataGridView senderGrid, DataGridViewCellEventArgs e)
        {

            List<Copy> copies = new List<Copy>();

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewDisableButtonColumn &&
                    e.RowIndex >= 0)
            {
                DatabaseManager dbManager = new DatabaseManager();
                var rowIndex = e.RowIndex;
                var currentRow = dataGridView1.Rows[rowIndex];

                // Selecting id of the choosen book.
                int BookID = Int32.Parse(currentRow.Cells[1].Value.ToString());


                // Selecting existing copies of this book
                copies = dbManager.ChooseBookAndItsCopies(BookID);

            }
            return copies;
        }

        //
        //
        //
        //
        //

        private void DisplayCopies(List<Copy> copies)
        {
            // Preparing data for displaying.

            List<object> copiesToDisplay = new List<object>();
            List<int> counters = new List<int>();

            foreach (Copy copy in copies)
            {
                object temp = new
                {
                    CopyID = copy.CopyID,
                    Title = copy.Book.Title,
                    Status = copy.Status,
                    Branch = copy.Branch.Location
                };
                copiesToDisplay.Add(temp);

                if (copy.Status == "Borrowed" || copy.Status == "Reserved")
                {
                    counters.Add(1);
                }
                else
                {
                    counters.Add(0);
                }

            }


            dataGridView1.DataSource = copiesToDisplay;
            dataGridView1.Columns["Action"].DisplayIndex = 4;
            DataGridViewDisableButtonCell btn = new DataGridViewDisableButtonCell();

            btn.CheckButtons(this.dataGridView1, counters);
        }

        //
        //
        //
        //
        //

        public void CheckButtons()
        {
            DataGridViewDisableButtonCell btn = new DataGridViewDisableButtonCell();
            btn.CheckButtons(dataGridView1);
        }

        //
        //
        //
        //
        //

        private Copy SelectCopy(DataGridView senderGrid, DataGridViewCellEventArgs e, List<Copy> copies)
        {
            Copy copy = new Copy();
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewDisableButtonColumn &&
                    e.RowIndex >= 0)
            {
                DatabaseManager dbManager = new DatabaseManager();
                var rowIndex = e.RowIndex;
                var currentRow = dataGridView1.Rows[rowIndex];

                // Selecting id of the choosen copy.
                int copyID = Int32.Parse(currentRow.Cells[1].Value.ToString());

                copy = copies.Where(c => c.CopyID == copyID).First();
            }
            return copy;
        }

        //
        //
        //
        //
        //

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Return_Click(object sender, EventArgs e)
        {
            counter = false;
            if (booksToDisplay.Count == 0)
            {
                dataGridView1.DataSource = booksToDisplay;
                dataGridView1.Columns["Action"].DisplayIndex = 6;

                DataGridViewDisableButtonCell btn = (DataGridViewDisableButtonCell)dataGridView1.Rows[0].Cells[0];
                btn.CheckButtons(this.dataGridView1);

            }
            else
            {
                dataGridView1.DataSource = booksToDisplay;
                dataGridView1.Columns["Action"].DisplayIndex = 6;
            }

        }

        //
        //
        //
        //
        //


    }
}
