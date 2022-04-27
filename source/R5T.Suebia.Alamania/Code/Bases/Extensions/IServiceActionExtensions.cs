using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Alamania;
using R5T.Lombardy;

using R5T.T0062;
using R5T.T0063;


namespace R5T.Suebia.Alamania
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="RivetOrganizationSecretsDirectoryPathProvider"/> implementation of <see cref="IRivetOrganizationSecretsDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IRivetOrganizationSecretsDirectoryPathProvider> AddRivetOrganizationSecretsDirectoryPathProviderAction(this IServiceAction _,
            IServiceAction<IRivetOrganizationDirectoryPathProvider> rivetOrganizationDirectoryPathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = _.New<IRivetOrganizationSecretsDirectoryPathProvider>(services => services.AddRivetOrganizationSecretsDirectoryPathProvider(
                rivetOrganizationDirectoryPathProviderAction,
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Forwards the <see cref="IRivetOrganizationSecretsDirectoryPathProvider"/> service to <see cref="ISecretsDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISecretsDirectoryPathProvider> ForwardToSecretsDirectoryPathProviderAction(this IServiceAction _,
            IServiceAction<IRivetOrganizationSecretsDirectoryPathProvider> rivetOrganizationSecretsDirectoryPathProviderAction)
        {
            var serviceAction = _.New<ISecretsDirectoryPathProvider>(services => services.ForwardRivetOrganizationSecretsDirectoryPathProviderAsSecretsDirectoryPathProvider(
                rivetOrganizationSecretsDirectoryPathProviderAction));

            return serviceAction;
        }
    }
}
