using LibraryHomework.Data;
using LibraryHomework.Models;
using System;
using System.Collections.Generic;

namespace LibraryHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1) Выведите список должников.

            var users = new List<User>();

            using (var userDataAccess = new UserDataAccess())
            {
                users = (List<User>)userDataAccess.Select();
            }

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}. {user.Login} | {user.Password}   ");
            }
            



            // 2) Выведите список авторов книги №3 (по порядку из таблицы ‘Book’). 
            /*var authors = new List<Author>();

            using (var authorDataAccess = new AuthorDataAccess())
            {
                authors = (List<Author>)authorDataAccess.Select();
            }

            */


            //3) Выведите список книг, которые доступны в данный момент.

            /*var books = new List<Book>();

            using (var bookDataAccess = new BookDataAccess())
            {
                books = (List<Book>)bookDataAccess.SelectAvailableBook();
            }

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Id}. {book.Name}");
            }*/



            // 4) Вывести список книг, которые на руках у пользователя №2. 
            /*var books = new List<Book>();

            using (var bookDataAccess = new BookDataAccess())
            {
                books = (List<Book>)bookDataAccess.Select();
            }

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Id}, {book.Name}");
            }*/


        }
    }
}
