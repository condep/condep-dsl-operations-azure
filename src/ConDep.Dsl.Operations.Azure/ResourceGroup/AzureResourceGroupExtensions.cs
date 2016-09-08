using System;
using ConDep.Dsl.Builders;
using ConDep.Dsl.Operations.Azure.ResourceGroup;

namespace ConDep.Dsl
{
    public static class AzureResourceGroupExtensions
    {
        public static IOfferAzureOperations CreateResourceGroup(this IOfferAzureResourceGroupOperations resourceGroup, string name, string location)
        {
            var rgBuilder = resourceGroup as AzureResourceGroupOperationsBuilder;
            var createResourceGroupOperation = new CreateAzureResourceGroupOperation();
            OperationExecutor.Execute((LocalBuilder)resourceGroup, createResourceGroupOperation);
            return rgBuilder.AzureOperations;
        }
    }
}
