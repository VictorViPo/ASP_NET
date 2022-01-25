using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4_Y4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        
{
private static object CreateHostBuilder(string[] args)
        {
            throw new NotImplementedException();
        }

        public class CpuMetricsRepository : ICpuMetricsRepository
        {
            // строка подключения
            private const string ConnectionString = @"Data Source=metrics.db;
            Version=3;Pooling=True;Max Pool Size=100;";
            private const string V1 = "INSERT INTO cpumetrics(value, time);
            private const string V = "UPDATE cpumetrics SET value = @value, time = @time WHERE id = @id;
            private object value;
            private object time;
            private object cpumetrics;

            public object SqlMapper { get; }
            public string WHERE { get; private set; }

            // инжектируем соединение с базой данных в наш репозиторий через конструктор
            public CpuMetricsRepository()
            {
                // добавляем парсилку типа TimeSpan в качестве подсказки для SQLite
                SqlMapper.AddTypeHandler(new TimeSpanHandler());
            }

            public void Create(CpuMetric item)
            {
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    // запрос на вставку данных с плейсхолдерами для параметров
                    connection.Execute(V1,
                    VALUES(@value, @time),
                    // анонимный объект с параметрами запроса
                    new
                    {
                        // value подставится на место "@value" в строке запроса
                        // значение запишется из поля Value объекта item
                        value = item.Value,

                        // записываем в поле time количество секунд
                        time = item.Time.TotalSeconds

                    });

                }

            }

            private object VALUES(object value, object time)
            {
                throw new NotImplementedException();
            }

            public void Delete(int id)
            {
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Execute("DELETE FROM cpumetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });
                }
            }

            public void Update(CpuMetric item)
            {
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Execute(V,
                    new
                    {
                        value = item.Value,
                        time = item.Time.TotalSeconds,
                        id = item.Id
                    });
                }
            }

            public IList<CpuMetric> GetAll()
            {
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    // читаем при помощи Query и в шаблон подставляем тип данных
                    // объект которого Dapper сам и заполнит его поля
                    // в соответсвии с названиями колонок
                    return connection.Query<CpuMetric>("SELECT Id, Time, Value FROM cpumetrics").
                        ToList();
                }
            }

            public CpuMetric GetById(int id)
            {
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    return connection.QuerySingle<CpuMetric>("SELECT Id, Time, Value FROM,

#pragma warning disable CS1717 // Назначение выполнено для той же переменной
                    cpumetrics WHERE, id = @id,
#pragma warning restore CS1717 // Назначение выполнено для той же переменной
                    new { id = id });
                }
            }
        }
    }
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseStartup<Startup>();
});
    }
}



