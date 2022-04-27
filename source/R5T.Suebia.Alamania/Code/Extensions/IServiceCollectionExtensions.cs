using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Alamania;
using R5T.Lombardy;

using R5T.T0063;


namespace R5T.Suebia.Alamania
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="RivetOrganizationSecretsDirectoryPathProvider"/> implementation of <see cref="IRivetOrganizationSecretsDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddRivetOrganizationSecretsDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IRivetOrganizationDirectoryPathProvider> rivetOrganizationDirectoryPathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services
                .Run(rivetOrganizationDirectoryPathProviderAction)
                .Run(stringlyTypedPathOperatorAction)
                .AddSingleton<IRivetOrganizationSecretsDirectoryPathProvider, RivetOrganizationSecretsDirectoryPathProvider>()
                ;

            return services;
        }

        /// <summary>
        /// Forwards the <see cref="IRivetOrganizationSecretsDirectoryPathProvider"/> to the <see cref="ISecretsDirectoryPathProvider"/> service as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection ForwardRivetOrganizationSecretsDirectoryPathProviderAsSecretsDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IRivetOrganizationSecretsDirectoryPathProvider> rivetOrganizationSecretsDirectoryPathProviderAction)
        {
            services
                .Run(rivetOrganizationSecretsDirectoryPathProviderAction)
                .AddSingleton<ISecretsDirectoryPathProvider>(serviceProvider =>
                {
                    var rivetOrganizationSecretsDirectoryPathProvider = serviceProvider.GetRequiredService<IRivetOrganizationSecretsDirectoryPathProvider>();
                    return rivetOrganizationSecretsDirectoryPathProvider;
                })
                ;

            return services;
        }
    }
}
