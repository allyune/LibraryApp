using System;
using Library.BusinessLogic.Interfaces;
using Library.Data.Interfaces;
using Library.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Library.BusinessLogic
{
    public static class DependenciesRegistration
	{
		public static IServiceCollection AddBusinessLogicDependencies(this IServiceCollection provider)
		{
			provider.AddTransient<IBooksRepository, BooksRepository>();
			return provider;
		}
	}
}

