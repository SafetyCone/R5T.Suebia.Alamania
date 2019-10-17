using System;

using R5T.Lombardy;


namespace R5T.Suebia.Alamania
{
    public class AlamaniaSecretsFilePathProvider : ISecretsFilePathProvider
    {
        public ISecretsDirectoryPathProvider SecretsDirectoryPathProvider { get; }
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public AlamaniaSecretsFilePathProvider(ISecretsDirectoryPathProvider secretsDirectoryPathProvider, IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.SecretsDirectoryPathProvider = secretsDirectoryPathProvider;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public string GetSecretsFilePath(string fileName)
        {
            var secretsDirectoryPath = this.SecretsDirectoryPathProvider.GetSecretsDirectoryPath();

            var secretsFilePath = this.StringlyTypedPathOperator.GetFilePath(secretsDirectoryPath, fileName);
            return secretsFilePath;
        }
    }
}
