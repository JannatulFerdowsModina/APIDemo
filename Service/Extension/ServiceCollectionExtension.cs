using Microsoft.Extensions.DependencyInjection;
using Service.BookService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Extension
{
   public static class ServiceCollectionExtension
    {
        public static void AddBookServices(this IServiceCollection services)
        {
            services.AddTransient<IBookInterface, BookInterface>();
        }
    }
}
