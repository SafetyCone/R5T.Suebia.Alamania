using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Alamania;
using R5T.Dacia;
using R5T.Lombardy;


namespace R5T.Suebia.Alamania
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="AlamaniaSecretsDirectoryPathProvider"/> implementation of <see cref="ISecretsDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddAlamaniaSecretsDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<IRivetOrganizationDirectoryPathProvider> addRivetOrganizationDirectoryPathProvider,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            services
                .AddSingleton<ISecretsDirectoryPathProvider, AlamaniaSecretsDirectoryPathProvider>()
                .RunServiceAction(addRivetOrganizationDirectoryPathProvider)
                .RunServiceAction(addStringlyTypedPathOperator)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="AlamaniaSecretsDirectoryPathProvider"/> implementation of <see cref="ISecretsDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<ISecretsDirectoryPathProvider> AddAlamaniaSecretsDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<IRivetOrganizationDirectoryPathProvider> addRivetOrganizationDirectoryPathProvider,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            var serviceAction = new ServiceAction<ISecretsDirectoryPathProvider>(() => services.AddAlamaniaSecretsDirectoryPathProvider(
                addRivetOrganizationDirectoryPathProvider,
                addStringlyTypedPathOperator));
            return serviceAction;
        }
    }
}
