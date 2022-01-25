using System;

namespace WebApplication4_Y4
{
    internal class SQLiteConnection : IDisposable
    {
        private string connectionString;

        public SQLiteConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal void Execute(string v1, object p1, string v2, object p2)
        {
            throw new NotImplementedException();
        }

        internal void Execute(string v1, object v, object p)
        {
            throw new NotImplementedException();
        }

        internal void Execute(string v, object p)
        {
            throw new NotImplementedException();
        }

        internal void Execute(string v1, object time, object wHERE, object p1, string v2, object p2)
        {
            throw new NotImplementedException();
        }

        internal object Query<T>(string v)
        {
            throw new NotImplementedException();
        }

        internal T QuerySingle<T>(string v1, object cpumetrics, string wHERE, int v2, string v3, object p)
        {
            throw new NotImplementedException();
        }
    }
}