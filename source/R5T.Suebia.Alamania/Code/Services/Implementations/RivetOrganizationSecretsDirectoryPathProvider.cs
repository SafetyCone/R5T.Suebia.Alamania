using System;

using R5T.Alamania;
using R5T.Lombardy;
using R5T.Quadia;

using R5T.T0064;


namespace R5T.Suebia.Alamania
{
    /// <summary>
    /// Provides the Rivet/Data/Secrets directory path as the secrets directory path (usually the Rivet directory is in Dropbox) .
    /// </summary>
    [ServiceImplementationMarker]
    public class RivetOrganizationSecretsDirectoryPathProvider : IRivetOrganizationSecretsDirectoryPathProvider, IServiceImplementation
    {
        public IRivetOrganizationDirectoryPathProvider RivetOrganizationDirectoryPathProvider { get; }
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public RivetOrganizationSecretsDirectoryPathProvider(IRivetOrganizationDirectoryPathProvider rivetOrganizationDirectoryPathProvider, IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.RivetOrganizationDirectoryPathProvider = rivetOrganizationDirectoryPathProvider;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public string GetSecretsDirectoryPath()
        {
            var rivetOrganizationDirectoryPath = this.RivetOrganizationDirectoryPathProvider.GetRivetOrganizationDirectoryPath();

            var secretsDirectoryPath = this.StringlyTypedPathOperator.Combine(rivetOrganizationDirectoryPath, DataDirectory.Name, SecretsDirectory.DirectoryName);
            return secretsDirectoryPath;
        }
    }
}
