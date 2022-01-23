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
            // Создаем строку подключения в виде базы данных в оперативной памяти
            string connectionString = "Data Source=:memory:";

            // создаем соединение с базой данных
            using (var connection = new SQLiteConnection(connectionString))
            {
                // открываем соединение
                connection.Open();


                // создаем объект через который будут выполняться команды к базе данных

                using (var command = new SQLiteCommand(connection))
                {
                    // задаем новый текст команды для выполнения
                    // удаляем таблицу с метриками если она существует в базе данных

                    command.CommandText = "DROP TABLE IF EXISTS cpumetrics";
                    // отправляем запрос в базу данных
                    command.ExecuteNonQuery();

                    // создаем таблицу с метриками
                    command.CommandText = @"CREATE TABLE cpumetrics(id INTEGER PRIMARY KEY, value INT, time INT)";
                    command.ExecuteNonQuery();

                    // создаем запрос на вставку данных
                    command.CommandText = "INSERT INTO cpumetrics(value, time)VALUES(10, 1)";

                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO cpumetrics(value, time)VALUES(50, 2)";

                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO cpumetrics(value, time)VALUES(75, 4)";

                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO cpumetrics(value, time)VALUES(90, 5)";

                    command.ExecuteNonQuery();

                    // создаем строку для выборки данных из базы
                    // LIMIT 3 обозначает, что мы достанем только 3 записи
                    string readQuery = "SELECT * FROM cpumetrics LIMIT 3";

                    // создаем массив, в который запишем объекты с данными из базы данных

                    var returnArray = new CpuMetric[3];
                    // изменяем текст команды на наш запрос чтения
                    command.CommandText = readQuery;

                    // создаем читалку из базы данных

                    {
                        // счетчик для того, чтобы записать объект в правильное место в массиве

                        var counter = 0;
                        // цикл будет выполняться до тех пор, пока есть что читать из базы данных


                        while (reader.Read())
                        {
                            // создаем объект и записываем его в массив


                            returnArray[counter] = new CpuMetric
                            {
                                Id = reader.GetInt32(0), // читаем данные полученные из базы данных


                                Value = reader.GetInt32(1), // преобразуя к целочисленному типу


                                Time = reader.GetInt64(2)

                            };
                            // увеличиваем значение счетчика
                            counter++;

                        }

                    }

                    // оборачиваем массив с данными в объект ответа и возвращаем пользователю

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
