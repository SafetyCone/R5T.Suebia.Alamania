using System;

using R5T.Alamania;
using R5T.Lombardy;
using R5T.Ostrogothia;


namespace R5T.Suebia.Alamania
{
    /// <summary>
    /// Provides the Rivet/Data/Secrets directory path as the secrets directory path (usually the Rivet directory is in Dropbox) .
    /// </summary>
    public class RivetOrganizationSecretsDirectoryPathProvider : IRivetOrganizationSecretsDirectoryPathProvider
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

            var secretsDirectoryPath = this.StringlyTypedPathOperator.Combine(rivetOrganizationDirectoryPath, OrganizationDirectories.DataDirectoryName, SecretsDirectory.DirectoryName);
            return secretsDirectoryPath;
        }
    }
}
