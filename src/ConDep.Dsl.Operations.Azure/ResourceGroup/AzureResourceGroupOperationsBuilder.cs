using System.Threading;
using ConDep.Dsl.Builders;
using ConDep.Dsl.Config;

namespace ConDep.Dsl.Operations.Azure.ResourceGroup
{
    internal class AzureResourceGroupOperationsBuilder : LocalBuilder, IOfferAzureResourceGroupOperations
    {
        public AzureResourceGroupOperationsBuilder(IOfferAzureOperations azureOps, ConDepSettings settings, CancellationToken token) : base(settings, token)
        {
            AzureOperations = azureOps;
        }

        public IOfferAzureOperations AzureOperations { get; }

        public override IOfferLocalOperations Dsl
        {
            get { return ((AzureOperationsBuilder)AzureOperations).LocalOperations; }
        }
    }
}
