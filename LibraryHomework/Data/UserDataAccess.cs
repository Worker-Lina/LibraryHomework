using LibraryHomework.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LibraryHomework.Data
{
    public class UserDataAccess : DbDataAccess<User>
    {
        public override ICollection<User> Select()
        {
            var selectSqlScript = "SELECT u.Id, u.[login], u.[Password] FROM Ticket t JOIN Users u ON u.Id = t.UserId JOIN Books b On b.Id = BookId";

            var command = new SqlCommand(selectSqlScript, connection);
            var dataReader = command.ExecuteReader();

            var users = new List<User>();

            while (dataReader.Read())
            {
                users.Add(new User
                {
                    Id = int.Parse(dataReader["Id"].ToString()),
                    Login = dataReader["Login"].ToString(),
                    Password = dataReader["Password"].ToString()
                });
            }

            dataReader.Close();
            command.Dispose();

            return users;
        }


        public void CancelDebts()
        {
            var deleteDebts = "Delete Ticket";

            var command = new SqlCommand(deleteDebts, connection);
            command.ExecuteNonQuery();

            command.Dispose();
        }
    }
}
