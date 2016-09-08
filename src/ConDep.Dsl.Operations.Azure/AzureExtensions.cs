using System;
using ConDep.Dsl.Builders;
using ConDep.Dsl.Operations.Azure;

namespace ConDep.Dsl
{
    public static class AzureExtensions
    {
        /// <summary>
        /// Provide operations for Amazon AWS
        /// </summary>
        /// <param name="local"></param>
        /// <param name="azure">The Microsoft Azure operations</param>
        /// <returns></returns>
        public static IOfferLocalOperations Azure(this IOfferLocalOperations local, Action<IOfferAzureOperations> azure)
        {
            var builder = local as LocalOperationsBuilder;
            var azureBuilder = new AzureOperationsBuilder(local, builder.Settings, builder.Token);

            if (azure != null)
            {
                azure(azureBuilder);
            }

            return local;
        }
    }
}
