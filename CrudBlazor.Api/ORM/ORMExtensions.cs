using CrudBlazor.Api.ORM.DAO;
using CrudBlazor.Core.CRUD;
using FluentNHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using System.Reflection;

namespace CrudBlazor.Api.ORM
{
    public static class ORMExtensions
    {
        public static IServiceCollection AddNHibernate ( this IServiceCollection services, string connectionString)
        {
            var configuration = new Configuration();

            configuration.DataBaseIntegration(c =>
            {
                c.Dialect<MySQLDialect>();
                c.ConnectionString = connectionString;
                c.LogFormattedSql = false;
                c.LogSqlInConsole = false;
            });

            configuration.AddMappingsFromAssembly(Assembly.GetExecutingAssembly());

            var sessionFactory = configuration.BuildSessionFactory();
            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());
            
            // Add DAO Services
            services.AddScoped<UserDAO>();
            services.AddScoped<CustomerDAO>();

            return services;
        }

        public static PaginateResponse<TResult> ToPaginateResponse<TResult, TRequest>(this IQueryable<TResult> query, PaginateRequest<TRequest> request)
        {
            var result = new PaginateResponse<TResult>
            {
                PageSize = request.PageSize <= 0 ? 25 : request.PageSize,
                PageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber,
                TotalRecords = query.Count()
            };

            // Pega o total de páginas
            result.TotalPages = (int)Math.Ceiling(result.TotalRecords / (decimal)result.PageSize);

            // Verifica se a pagina é maior do que a última página
            result.PageNumber = result.PageNumber > result.TotalPages ? result.TotalPages : result.PageNumber;

            // Pega os dados fazendo a paginação
            result.Data = query.Take(result.PageSize).Skip(result.Skip).ToList() ?? [];

            return result;
        }

        public static string ToLike(this string input)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(input))
                result = input.Trim().Replace(" ", "%");
            return result;
        }

    }

}
