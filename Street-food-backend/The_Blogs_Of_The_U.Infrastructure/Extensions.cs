using Microsoft.Extensions.DependencyInjection;
using The_Blogs_Of_The_U.Infrastructure.MySqlDb.Repository;
using The_Blogs_Of_The_U.Domain.Core.Ports;

namespace The_Blogs_Of_The_U.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection svc)
        {
            svc.AddTransient(typeof(IMySqlRepositoryClient), typeof(MySqlRepositoryClient));

            return svc;
        }

    }
}
