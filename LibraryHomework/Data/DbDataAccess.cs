﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LibraryHomework.Data
{
    public abstract class DbDataAccess<T> : IDisposable
    {
        protected readonly SqlConnection connection;

        public DbDataAccess()
        {
            connection = new SqlConnection();
            connection.ConnectionString = "Server=DESKTOP-6543DI3; Database=Library; Trusted_Connection=True;";
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public abstract ICollection<T> Select();
    }
}
