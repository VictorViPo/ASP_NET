using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
                //������ ���
                int hotDays = 0;
                //������� �����������
                int commonTemp = 0;

                Random ranom = new Random();

                // ������ ����������
                int[] dayTemp = new int[31];


                //���������� ������� ����������
                for (int i = 0; i < 31; i++)
                {
                    dayTemp[i] = ranom.Next(-45, 45);
                }

                for (int j = 0; j < 31; j++)
                {
                    commonTemp = commonTemp + dayTemp[j];

                    if (dayTemp[j] > 0)
                    {
                        hotDays++;
                    }
                }
                commonTemp = commonTemp / dayTemp.Count();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
