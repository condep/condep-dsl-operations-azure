using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConDep.Dsl.Builders;
using ConDep.Dsl.Config;
using ConDep.Dsl.Operations.Azure.ResourceGroup;

namespace ConDep.Dsl.Operations.Azure
{
    internal class AzureOperationsBuilder : LocalBuilder, IOfferAzureOperations
    {
        public AzureOperationsBuilder(IOfferLocalOperations localOps, ConDepSettings settings, CancellationToken token) : base(settings, token)
        {
            LocalOperations = localOps;
            ResourceGroup = new AzureResourceGroupOperationsBuilder(this, settings, token);
        }

        public IOfferAzureResourceGroupOperations ResourceGroup { get; private set; }

        public IOfferLocalOperations LocalOperations { get; private set; }

        public override IOfferLocalOperations Dsl
        {
            get { return ((LocalOperationsBuilder)LocalOperations).Dsl; }
        }
    }
}
