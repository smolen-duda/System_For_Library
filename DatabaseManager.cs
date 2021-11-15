using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper;
using System.IO;
using System.Data.Entity;

namespace Library
{
    [NotMapped]
    public class DatabaseManager
    { 

        public DatabaseManager()
        {

        }


        // Seeding default data

        //
        //
        //
        //
        //
        private void SeedBooks()
        {
            using (Context db = new Context())
            {
                IList<Book> defaultBooks = new List<Book>();
                var rnd = new Random();

                using (var streamReader = System.IO.File.OpenText("E:\\C#\\Projekty\\Library\\books1.csv"))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        var splittedLine = line.Split(',');
                        int i = rnd.Next(1, 8);

                        // Randomly assings Topic, number of Brunches and number of Copies.
                        Topic temp = db.Topics.Where(t => t.TopicID == i).First();


                        int numberBranches = rnd.Next(1, 3);
                        List<Branch> branches = new List<Branch>();
                        for (int k = 1; k < numberBranches + 1; k++)
                        {
                            Branch tempBranch = db.Branches.Where(b => b.BranchID == k).First();
                            branches.Add(tempBranch);
                        }


                        Book book = new Book() { ISBN = splittedLine[0], Title = splittedLine[1], Author = splittedLine[2], Year = int.Parse(splittedLine[3]), Topic = temp, Branches = branches };
                        if (!db.Books.Any(b => b.ISBN == book.ISBN))
                        {
                            db.Books.Add(book);
                            foreach (Branch branch in branches)
                            {
                                GenerateCopies(db, book, branch);
                            }
                        }

                    }
                }
                db.SaveChanges();
                System.Windows.Forms.MessageBox.Show("Data seeded.");
            }
        }

        //
        //
        //
        //
        //

        private void GenerateCopies(Context db, Book book, Branch branch)
        {
            List<Copy> copies = new List<Copy>();

            List<string> status = new List<string>() { "Available", "Borrowed", "Reserved" };

            var rnd = new Random();
            int numberCopies = rnd.Next(1, 4);
            int numberStatus = rnd.Next(0, 3);

            for (int i = 0; i < numberCopies; i++)
            {
                Copy temp = new Copy() { Book = book, Status = status[numberStatus], Branch = branch };
                db.Copies.Add(temp);
            }
            db.SaveChanges();

        }
        //
        //
        //
        //
        //
        private void SeedTopicsandBranches()
        {
            using (Context db = new Context())
            {
                List<string> topics = new List<string>() { "Fantasy", "Novel", "Handbook", "Sci-Fi", "Poetry", "Biography", "Fairy tale" };
                foreach (string str in topics)
                {
                    Topic temp = new Topic() { Name = str };
                    if (!db.Topics.Any(t => t.Name == temp.Name))
                    {
                        db.Topics.Add(temp);
                    }
                }
                Branch branch1 = new Branch() { Location = "London" };
                Branch branch2 = new Branch() { Location = "Glasgow" };

                db.Branches.Add(branch1);
                db.Branches.Add(branch2);

                db.SaveChanges();
                System.Windows.Forms.MessageBox.Show("Topics and Branches seeded.");
            }
        }
        //
        //
        //
        //
        //
        private void SeedReaders()
        {
            List<Reader> readers = new List<Reader>();

            using (var streamReader = File.OpenText("E:\\C#\\Projekty\\Library\\Readers.csv"))
            {
                var reader = new CsvReader(streamReader, System.Globalization.CultureInfo.InvariantCulture);
                readers = reader.GetRecords<Reader>().ToList();
            }
            using (Context db = new Context())
            {
                db.Readers.AddRange(readers);
                db.SaveChanges();
            }

            System.Windows.Forms.MessageBox.Show("Readers seeded.");

        }

        //
        //
        //
        //
        //
        private void SeedPhoneNumbers()
        {
            using (var streamReader = System.IO.File.OpenText("E:\\C#\\Projekty\\Library\\Phone numbers.csv"))
            {
                while (!streamReader.EndOfStream)
                {
                    using (Context db = new Context())
                    {
                        List<Reader> readers = db.Readers.ToList();
                        foreach (Reader reader in readers)
                        {
                            var line = streamReader.ReadLine();
                            var splittedLine = line.Split(',');

                            foreach (string number in splittedLine)
                            {
                                if (!String.IsNullOrEmpty(number))
                                {
                                    PhoneNumber phone = new PhoneNumber() { Number = number, Reader = reader };
                                    db.PhoneNumbers.Add(phone);
                                }
                            }
                        }
                        db.SaveChanges();

                    }
                }
            }
            System.Windows.Forms.MessageBox.Show("Phone Numbers seeded.");
        }

        //
        //
        //
        //
        //
        public void SeedData()
        {
            SeedTopicsandBranches();
            SeedBooks();
            SeedReaders();
            SeedPhoneNumbers();
        }

        //
        //
        //
        //
        //

        // CRUD operations

        //
        //
        //
        //
        //

        public List<Book> FindBook(string title, string author, string year1, string ISBN)
        {
            List<Book> books = new List<Book>();
            if (!String.IsNullOrEmpty(title) || !String.IsNullOrEmpty(author) || Int32.TryParse(year1, out int year) || !String.IsNullOrEmpty(ISBN))
            {
                books=Search(title, author, year1, ISBN);

                System.Windows.Forms.MessageBox.Show("Searching complete.");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("You have to fill at least one field.");
            }
            return books;
        }

        //
        //
        //
        //
        //

        private List<Book> Search(string title, string author, string year1, string ISBN)
        {
            List<Book> books = new List<Book>();

            using (Context db = new Context())
            {
                books = db.Books.Include("Topic").ToList();
            }
            

            (bool, bool, bool, bool) conditions = (!String.IsNullOrEmpty(title), !String.IsNullOrEmpty(author), Int32.TryParse(year1, out int year), !String.IsNullOrEmpty(ISBN));
            Dictionary<(bool, bool, bool, bool), int> conditionsToValues = new Dictionary<(bool, bool, bool, bool), int>();
            conditionsToValues.Add((true, true, true, true), 1);
            conditionsToValues.Add((true, true, true, false), 2);
            conditionsToValues.Add((true, true, false, false), 3);
            conditionsToValues.Add((true, false, false, false), 4);
            conditionsToValues.Add((true, true, false, true), 5);
            conditionsToValues.Add((true, false, false, true), 6);
            conditionsToValues.Add((false, false, false, true), 7);
            conditionsToValues.Add((true, false, true, true), 8);
            conditionsToValues.Add((false, false, true, true), 9);
            conditionsToValues.Add((false, true, true, true), 10);
            conditionsToValues.Add((false, true, false, true), 11);
            conditionsToValues.Add((false, true, true, false), 12);
            conditionsToValues.Add((true, false, true, false), 13);
            conditionsToValues.Add((false, true, false, false), 14);
            conditionsToValues.Add((false, false, true, false), 15);


            conditionsToValues.TryGetValue(conditions, out int value);


            switch (value)
            {
                case 1:
                    books = SearchByTitle(books, title);
                    books = SearchByAuthor(books, author);
                    books = SearchByYear(books, year);
                    books = SearchByISBN(books, ISBN);
                    break;

                case 2:
                    books = SearchByTitle(books, title);
                    books = SearchByAuthor(books, author);
                    books = SearchByYear(books, year);
                    break;

                case 3:
                    books = SearchByTitle(books, title);
                    books = SearchByAuthor(books, author);
                    break;

                case 4:
                    books = SearchByTitle(books, title);
                    break;

                case 5:
                    books = SearchByTitle(books, title);
                    books = SearchByAuthor(books, author);
                    books = SearchByISBN(books, ISBN);
                    break;

                case 6:
                    books = SearchByTitle(books, title);
                    books = SearchByISBN(books, ISBN);
                    break;

                case 7:
                    books = SearchByISBN(books, ISBN);
                    break;

                case 8:
                    books = SearchByTitle(books, title);
                    books = SearchByYear(books, year);
                    books = SearchByISBN(books, ISBN);
                    break;

                case 9:
                    books = SearchByYear(books, year);
                    books = SearchByISBN(books, ISBN);
                    break;

                case 10:
                    books = SearchByAuthor(books, author);
                    books = SearchByYear(books, year);
                    books = SearchByISBN(books, ISBN);
                    break;

                case 11:
                    books = SearchByAuthor(books, author);
                    books = SearchByISBN(books, ISBN);
                    break;

                case 12:
                    books = SearchByAuthor(books, author);
                    books = SearchByYear(books, year);
                    break;

                case 13:
                    books = SearchByTitle(books, title);
                    books = SearchByYear(books, year);
                    break;

                case 14:
                    books = SearchByAuthor(books, author);
                    break;

                case 15:
                    books = SearchByYear(books, year);
                    break;
            }

            return books;
        }

        //
        //
        //
        //
        //

        public List<Copy> ChooseBookAndItsCopies( int bookID)
        {
            Book book = new Book();
            List<Copy> copies = new List<Copy>();
            using (Context db = new Context())
            {
                book = db.Books.Where(b => b.BookID == bookID).Include("Copies").First();
                foreach(Copy copy in book.Copies)
                {
                    var temp = db.Copies.Where(c => c.CopyID == copy.CopyID).Include("Branch").Include("Book").First();
                    copies.Add(temp);
                }

            }
            return copies;
        }

        //
        //
        //
        //
        //

        public List<Reader> FindReaders(string name, string surname, string ID)
        {
            List<Reader> readers = new List<Reader>();
            if (!String.IsNullOrEmpty(name) || !String.IsNullOrEmpty(surname) ||!String.IsNullOrEmpty(ID))
            {
                readers = SearchReaders(name,surname,ID);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("You have to fill at least one field.");
            }
            return readers;
        }
        

        //
        //
        //
        //
        //

        private List<Reader> SearchReaders(string name, string surname, string ID)
        {
            Reader reader = new Reader();
            List<Reader> readers = new List<Reader>();


                using (Context db = new Context())
                {
                    readers = db.Readers.Include("PhoneNumbers").ToList();
                }


                (bool, bool, bool) conditions = (!String.IsNullOrEmpty(name), !String.IsNullOrEmpty(surname), !String.IsNullOrEmpty(ID));
                Dictionary<(bool, bool, bool), int> conditionsToValues = new Dictionary<(bool, bool, bool), int>();
                conditionsToValues.Add((true, true, true), 1);
                conditionsToValues.Add((true, true, false), 2);
                conditionsToValues.Add((true, false, false), 3);
                conditionsToValues.Add((true,  false, true), 4);
                conditionsToValues.Add(( false, false, true), 5);
                conditionsToValues.Add((false, true, false), 6);
                conditionsToValues.Add(( false, true, true), 7);


                conditionsToValues.TryGetValue(conditions, out int value);


            switch (value)
            {
                case 1:
                    readers = SearchByID(readers, ID);
                    readers = SearchBySurname(readers, surname);
                    readers = SearchByName(readers,name);
                    break;

                case 2:
                    readers = SearchBySurname(readers, surname);
                    readers = SearchByName(readers, name);
                    break;

                case 3:
                    readers = SearchByName(readers, name);
                    break;

                case 4:
                    readers = SearchByID(readers, ID);
                    readers = SearchByName(readers, name);
                    break;

                case 5:
                    readers = SearchByID(readers, ID);
                    break;

                case 6:
                    readers = SearchBySurname(readers, surname);
                    break;

                case 7:
                    readers = SearchByID(readers, ID);
                    readers = SearchBySurname(readers, surname);
                    break;
               
            }

            System.Windows.Forms.MessageBox.Show("Searching complete.");
            return readers;
        }

        //
        //
        //
        //
        //

        public void NewBorrowing(Reader reader, Copy copy1)
        {
            DateTime now = DateTime.UtcNow;
            DateTime back = DateTime.UtcNow.AddDays(30);

            using (Context db = new Context())
            {
                db.Readers.Attach(reader);

                var copy = db.Copies.Where(c=>c.CopyID==copy1.CopyID).Include("Book").Include("Branch").AsNoTracking().First();
                db.Copies.Attach(copy);
                db.Books.Attach(copy.Book);
                db.Branches.Attach(copy.Branch);
                Borrowing borrowing = new Borrowing() { Copy = copy, Reader = reader, DateOfTaking = now, DateOfBack_Expected = back, DateOfBack = null };
                db.Borrowings.Add(borrowing);
                copy.Status = "Borrowed";

                db.SaveChanges();
            }
            System.Windows.Forms.MessageBox.Show("Complete.");
            
        }
        //
        //
        //
        //
        //

        public void GiveBack(string id)
        {
            using (Context db = new Context())
            {
                int ID = int.Parse(id);
                Borrowing borrowing = db.Borrowings.Where(b => b.BorrowingID == ID).Include("Copy").First();
                DateTime now = DateTime.UtcNow;
                borrowing.DateOfBack = now;
                TimeSpan diff = Convert.ToDateTime(borrowing.DateOfBack)-borrowing.DateOfBack_Expected;
                double times = Math.Truncate(diff.Days / 30.0);
                System.Windows.Forms.MessageBox.Show(times.ToString());
                if (times>0)
                {
                    int fee = (int)times * 2;
                    Reader reader=db.Readers.Where(r => r.ReaderID == borrowing.ReaderID).First();
                    reader.Fees += fee;
                    
                }
                borrowing.Copy.Status = "Available";
                db.SaveChanges();
            }
        }

        //
        //
        //
        //
        //

        public void PayTheFees(string id,int value)
        {
            Reader reader = GetReader(id);
            using (Context db = new Context())
            {
                db.Readers.Attach(reader);
                if (value >= reader.Fees)
                {
                    reader.Fees = 0;
                }
                else
                {
                    reader.Fees -= value;
                }
                db.SaveChanges();
            }
            System.Windows.Forms.MessageBox.Show("Complete.");
        }

        //
        //
        //
        //
        //

        // Retrieving data from database.

        //
        //
        //
        //
        //

        public Reader GetReader(string ID)
        {
            using (Context db = new Context())
            {
                Reader reader = db.Readers.Where(r => r.IDNumber == ID).Include("Borrowings").First();
                return reader;
            }

        }
        //
        //
        //
        //
        //
        public List<Borrowing> GetBorrowingsForReader(string id)
        {
            Reader reader=GetReader(id);
            List<Borrowing> borrowings = reader.Borrowings.ToList();

            return borrowings;
        }
        //
        //
        //
        //
        //
        public Book GetBook(Copy copy)
        {
            Book book = new Book();
            using (Context db = new Context())
            {
                db.Copies.Attach(copy);
                book = db.Books.Where(b => b.BookID==copy.BookID).First();
            }
            return book;
        }
        //
        //
        //
        //
        //
        public Copy GetCopy(Borrowing borrowing)
        {
            Copy copy;
            using (Context db = new Context())
            {
                db.Borrowings.Attach(borrowing);
                copy = borrowing.Copy;
            }

            return copy;
        }

        //
        //
        // 
        //
        //

        private List<Book> SearchByTitle(List<Book> books, string title)
        {
            string[] splittedTitle=title.Split(' ');
            foreach (string word in splittedTitle)
            {
               books = books.Where(b => b.Title.ToLower().Contains(word.ToLower())).ToList();
            }
             
            return books;
        }

        private List<Book> SearchByAuthor(List<Book> books, string author)
        {
            string[] splittedAuthor = author.Split(' ');
            foreach (string word in splittedAuthor)
            {
                books = books.Where(b => b.Author.ToLower().Contains(word.ToLower())).ToList();
            }
            return books;

        }

        private List<Book> SearchByYear(List<Book> books,int year)
        {
            List<Book> choosenBooks = books.Where(b => b.Year == year).ToList();
            return choosenBooks;

        }

        private List<Book> SearchByISBN(List<Book> books, string ISBN)
        {
            List<Book> choosenBooks = books.Where(b => b.ISBN.ToLower().Contains(ISBN.ToLower())).ToList();
            return choosenBooks;
        }


        private List<Reader> SearchByName(List<Reader> readers, string name)
        {
            string[] splittedName = name.Split(' ');
            foreach (string word in splittedName)
            {
                readers = readers.Where(b => b.Name.ToLower().Contains(word.ToLower())).ToList();
            }

            return readers;
        }

        private List<Reader> SearchBySurname(List<Reader> readers, string surname)
        {
            string[] splittedSurname = surname.Split(' ');
            foreach (string word in splittedSurname)
            {
                readers = readers.Where(b => b.Surname.ToLower().Contains(word.ToLower())).ToList();
            }

            return readers;
        }

        private List<Reader> SearchByID(List<Reader> readers, string id)
        {
            readers = readers.Where(b => b.IDNumber.ToLower().Contains(id.ToLower())).ToList();

            return readers;
        }




        private void CloseSomethingElse(System.Windows.Forms.Form form)
        {
            form.Close();
        }
    }
}
