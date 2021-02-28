using LibraryHomework.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LibraryHomework.Data
{
    public class BookDataAccess : DbDataAccess<Book>
    {
        public override ICollection<Book> Select()
        {
            var selectSqlScript = "SELECT b.Id, b.Name  FROM Users u join Ticket t on t.UserId = u.Id join Books b on b.Id = t.BookId where u.Id = 2";

            var command = new SqlCommand(selectSqlScript, connection);
            var dataReader = command.ExecuteReader();

            var books = new List<Book>();

            while (dataReader.Read())
            {
                books.Add(new Book
                {
                    Id = int.Parse(dataReader["Id"].ToString()),
                    Name = dataReader["Name"].ToString(),
                });
            }

            dataReader.Close();
            command.Dispose();

            return books;
        }


        public ICollection<Book> SelectAvailableBook()
        {
            var selectSqlScript = "Select b.Id, b.[Name] from books b where not exists(Select * from Ticket t where BookId = b.Id)";

            var command = new SqlCommand(selectSqlScript, connection);
            var dataReader = command.ExecuteReader();

            var books = new List<Book>();

            while (dataReader.Read())
            {
                books.Add(new Book
                {
                    Id = int.Parse(dataReader["Id"].ToString()),
                    Name = dataReader["Name"].ToString(),
                });
            }

            dataReader.Close();
            command.Dispose();

            return books;
        }
    }
}
