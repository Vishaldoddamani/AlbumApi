using AutoMapper;
using System;
using Xunit;
using AlbumApi.Controllers;
using AlbumApi.Models;
using AlbumApi.Services;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Net.Http.Headers;   



namespace MyAlbumXunitProject
{
    public class AlbumUnitTest
    {


        public AlbumUnitTest()
        {
            string[] args = null;
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<AlbumApi.Startup>();
        });

        [Fact]
        public async System.Threading.Tasks.Task Test1Async()
        {



        }
    }
}
