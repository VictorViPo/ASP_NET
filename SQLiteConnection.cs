﻿using System;

namespace WebApplication2_Y2
{
    internal class SQLiteConnection : IDisposable
    {
        private string connectionString;

        public SQLiteConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }
    }
}