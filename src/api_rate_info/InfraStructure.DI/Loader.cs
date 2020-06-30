using Application.Interest.RateQuery;
using CQRSHelper._Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace InfraStructure.DI
{
    public class Loader
    {

        public static void Register(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration cfg, Action<Type> setMediator)
        {
            setMediator(typeof(RateQueryHandler));
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
