using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
internal class command
{
    internal static SQLiteDataReader ExecuteReader()
    {
        throw new NotImplementedException();
    }
}

namespace WebApplication2_Y2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger =

            NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("init main");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        })
        .ConfigureLogging(logging =>
        {
            logging.ClearProviders();
            logging.SetMinimumLevel(LogLevel.Trace);

        }).UseNLog();
        public class CpuMetric
        {
            public int Id { get; set; }

            public int Value { get; set; }

            public long Time { get; set; }

        }
        [HttpGet("sql-read-write-test")]
        public IActionResult TryToInsertAndRead()
        {
            // ������� ������ ����������� � ���� ���� ������ � ����������� ������
            string connectionString = "Data Source=:memory:";

            // ������� ���������� � ����� ������
            using (var connection = new SQLiteConnection(connectionString))
            {
                // ��������� ����������
                connection.Open();


                // ������� ������ ����� ������� ����� ����������� ������� � ���� ������

                using (var command = new SQLiteCommand(connection))
                {
                    // ������ ����� ����� ������� ��� ����������
                    // ������� ������� � ��������� ���� ��� ���������� � ���� ������

                    command.CommandText = "DROP TABLE IF EXISTS cpumetrics";
                    // ���������� ������ � ���� ������
                    command.ExecuteNonQuery();

                    // ������� ������� � ���������
                    command.CommandText = @"CREATE TABLE cpumetrics(id INTEGER PRIMARY KEY, value INT, time INT)";
                    command.ExecuteNonQuery();

                    // ������� ������ �� ������� ������
                    command.CommandText = "INSERT INTO cpumetrics(value, time)VALUES(10, 1)";

                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO cpumetrics(value, time)VALUES(50, 2)";

                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO cpumetrics(value, time)VALUES(75, 4)";

                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO cpumetrics(value, time)VALUES(90, 5)";

                    command.ExecuteNonQuery();

                    // ������� ������ ��� ������� ������ �� ����
                    // LIMIT 3 ����������, ��� �� �������� ������ 3 ������
                    string readQuery = "SELECT * FROM cpumetrics LIMIT 3";

                    // ������� ������, � ������� ������� ������� � ������� �� ���� ������

                    var returnArray = new CpuMetric[3];
                    // �������� ����� ������� �� ��� ������ ������
                    command.CommandText = readQuery;

                    // ������� ������� �� ���� ������

                    {
                        // ������� ��� ����, ����� �������� ������ � ���������� ����� � �������

                        var counter = 0;
                        // ���� ����� ����������� �� ��� ���, ���� ���� ��� ������ �� ���� ������


                        while (reader.Read())
                        {
                            // ������� ������ � ���������� ��� � ������


                            returnArray[counter] = new CpuMetric
                            {
                                Id = reader.GetInt32(0), // ������ ������ ���������� �� ���� ������


                                Value = reader.GetInt32(1), // ���������� � �������������� ����


                                Time = reader.GetInt64(2)

                            };
                            // ����������� �������� ��������
                            counter++;

                        }

                    }

                    // ����������� ������ � ������� � ������ ������ � ���������� ������������

                    return Ok(returnArray);

                }

            }

        }

        private IActionResult Ok(CpuMetric[] returnArray)
        {
            throw new NotImplementedException();
        }
    }

    internal class reader
    {
        internal static int GetInt32(int v)
        {
            throw new NotImplementedException();
        }

        internal static long GetInt64(int v)
        {
            throw new NotImplementedException();
        }

        internal static bool Read()
        {
            throw new NotImplementedException();
        }
    }

    internal class SQLiteCommand : IDisposable
    {
        private SQLiteConnection connection;

        public SQLiteCommand(SQLiteConnection connection)
        {
            this.connection = connection;
        }

        public string CommandText { get; internal set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        internal void ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        internal SQLiteDataReader ExecuteReader()
        {
            throw new NotImplementedException();
        }
    }
}
