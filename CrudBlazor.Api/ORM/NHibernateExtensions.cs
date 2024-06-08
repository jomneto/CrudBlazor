using CrudBlazor.Api.ORM.DAO;
using CrudBlazor.Core.CRUD;
using FluentNHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using System.Reflection;

namespace CrudBlazor.Api.ORM
{
    public static class NHibernateExtensions
    {
        public static IServiceCollection AddNHibernate ( this IServiceCollection services, string connectionString)
        {
            var configuration = new Configuration();

            configuration.DataBaseIntegration(c =>
            {
                c.Dialect<MySQLDialect>();
                c.ConnectionString = connectionString;
                c.LogFormattedSql = true;
                c.LogSqlInConsole = true;
            });

            configuration.AddMappingsFromAssembly(Assembly.GetExecutingAssembly());

            var sessionFactory = configuration.BuildSessionFactory();
            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());
            
            // Add DAO Services
            services.AddScoped<UserDAO>();

            return services;
        }

        public static PaginateResponse<TResult> ToPaginateResponse<TResult, TRequest>(this IQueryable<TResult> query, PaginateRequest<TRequest> request)
        {
            var result = new PaginateResponse<TResult>
            {
                PageSize = request.PageSize,
                PageNumber = request.PageNumber,
                TotalRecords = query.Count()
            };

            // Pega o total de páginas
            result.TotalPages = (int)Math.Ceiling(result.TotalRecords / (decimal)result.PageSize);

            // Pega os dados fazendo a paginação
            result.Data = query.Take(result.PageSize).Skip(request.Skip).ToList() ?? [];

            return result;
        }

    }

}
