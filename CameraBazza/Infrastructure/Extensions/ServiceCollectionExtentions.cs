﻿using System.Linq;

namespace CameraBazza.Web.Infrastructure.Extensions
{
   using System.Reflection;
   using Microsoft.Extensions.DependencyInjection;
   using Services;

   public static class ServiceCollectionExtentions
   {
      public static IServiceCollection AddDomainServices(this IServiceCollection services)
      {
         Assembly
            .GetAssembly(typeof(IService))
            .GetTypes()
            .Where(t => t.IsClass && t.GetInterfaces()
                           .Any(i => i.Name == $"I{t.Name}"))
            .Select(t => new
            {
               Interface = t.GetInterface($"I{t.Name}"),
               Implementation = t
            })
            .ToList()
            .ForEach(s => services.AddTransient(s.Interface, s.Implementation));

         return services;
      }
   }
}
