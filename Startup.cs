using Company.Function;
using Company.Function.Contexts;
using Company.Function.Repositories;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: WebJobsStartup(typeof(Startup))]
namespace Company.Function
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.AddMediatR(AppDomain.CurrentDomain.Load(this.GetType().Assembly.GetName()));

            builder.Services.AddTransient<IUsersRepository, UsersRepository>();

            builder.Services.AddDbContextFactory<DataBaseContext>();
        }   
    }
}