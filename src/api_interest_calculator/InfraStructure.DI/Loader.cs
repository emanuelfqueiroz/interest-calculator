using Application.InterestQueries.CalculatorQuery;
using Application.Services;
using Application.Services.RateClient;
using CQRSHelper._Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Retry;
using System;
using System.Net.Http;
using System.Reflection;

namespace InfraStructure.DI
{
    public static class Loader
    {

        public static void Register(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration cfg, Action<Type> setMediator)
        {
            setMediator(typeof(CalculatorQueryHandler));
            AsyncRetryPolicy retryPolicy = Policy
                 .Handle<HttpRequestException>()
                 .WaitAndRetryAsync(3, retryAttempt =>
                     TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                 );
            services.AddSingleton<AsyncRetryPolicy>(retryPolicy);

            var config = cfg.GetSection("services").Get<ServicesConfig>();
            
            services.AddSingleton<ServicesConfig>();
            services.AddScoped<IRateService, RateClient>(o => new RateClient(
                new HttpClient() {  BaseAddress = cfg.Uri("RateServiceUrl") }
            ));
            
        }

        public static Uri Uri(this IConfiguration cfg, string name)
        {
            return new Uri(cfg[name]);
        }

        public static Assembly[] GetAll()
        {
            return new[] {
                typeof(ICommand).GetTypeInfo().Assembly,
                typeof(IQuery<Response>).GetTypeInfo().Assembly
            };
        }

    }
}
