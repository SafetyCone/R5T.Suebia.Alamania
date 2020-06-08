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
        /// Adds the <see cref="RivetOrganizationSecretsDirectoryPathProvider"/> implementation of <see cref="IRivetOrganizationSecretsDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddRivetOrganizationSecretsDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IRivetOrganizationDirectoryPathProvider> rivetOrganizationDirectoryPathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services
                .AddSingleton<IRivetOrganizationSecretsDirectoryPathProvider, RivetOrganizationSecretsDirectoryPathProvider>()
                .RunServiceAction(rivetOrganizationDirectoryPathProviderAction)
                .RunServiceAction(stringlyTypedPathOperatorAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="RivetOrganizationSecretsDirectoryPathProvider"/> implementation of <see cref="ISecretsDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IRivetOrganizationSecretsDirectoryPathProvider> AddRivetOrganizationSecretsDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IRivetOrganizationDirectoryPathProvider> rivetOrganizationDirectoryPathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = ServiceAction<IRivetOrganizationSecretsDirectoryPathProvider>.New(() => services.AddRivetOrganizationSecretsDirectoryPathProvider(
                rivetOrganizationDirectoryPathProviderAction,
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Forwards the <see cref="IRivetOrganizationSecretsDirectoryPathProvider"/> to the <see cref="ISecretsDirectoryPathProvider"/> service as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection ForwardRivetOrganizationSecretsDirectoryPathProviderAsSecretsDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IRivetOrganizationSecretsDirectoryPathProvider> rivetOrganizationSecretsDirectoryPathProviderAction)
        {
            services
                .AddSingleton<ISecretsDirectoryPathProvider>(serviceProvider =>
                {
                    var rivetOrganizationSecretsDirectoryPathProvider = serviceProvider.GetRequiredService<IRivetOrganizationSecretsDirectoryPathProvider>();
                    return rivetOrganizationSecretsDirectoryPathProvider;
                })
                .Run(rivetOrganizationSecretsDirectoryPathProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Forwards the <see cref="IRivetOrganizationSecretsDirectoryPathProvider"/> to the <see cref="ISecretsDirectoryPathProvider"/> service as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISecretsDirectoryPathProvider> ForwardRivetOrganizationSecretsDirectoryPathProviderAsSecretsDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IRivetOrganizationSecretsDirectoryPathProvider> rivetOrganizationSecretsDirectoryPathProviderAction)
        {
            var serviceAction = ServiceAction<ISecretsDirectoryPathProvider>.New(() => services.ForwardRivetOrganizationSecretsDirectoryPathProviderAsSecretsDirectoryPathProvider(
                rivetOrganizationSecretsDirectoryPathProviderAction));

            return serviceAction;
        }
    }
}
