using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication_API.Properties;

namespace WebApplication_API
{
    public class Program
    {
        private object clientFactory;

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public class Person
        {
            public object Id { get; set; }
            public int Age { get; set; }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        //services.AddHttpClient(HttpGet);
        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "http://localhost:50343/api/cpumetrics/from/1/to/999999?var=val&var1=val1");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            //var client = clientFactory.CreateClient();
            HttpResponseMessage response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                var metricsResponse = JsonSerializer.DeserializeAsync
                <CpuMetricsResponse>(responseStream).Result;
            }
            else
            {
                // ошибка при получении ответа
            }
            return Ok();
        }

        private IActionResult Ok()
        {
            throw new NotImplementedException();
        }

    }

    internal class client
    {
        internal static object SendAsync(HttpRequestMessage request)
        {
            throw new NotImplementedException();
        }

    }
}
