using System;
using System.Diagnostics;
using ConDep.Dsl.Builders;
using ConDep.Dsl.Operations.Azure.ResourceGroup;

namespace ConDep.Dsl
{
    public static class AzureResourceGroupExtensions
    {
        /// <summary>
        /// Creates a resourcegroup with given name and location.
        /// </summary>
        /// <param name="resourceGroup"></param>
        /// <param name="name">The name of the resource group.</param>
        /// <param name="location">The location of the resourcegroup.</param>
        /// <returns></returns>
        public static IOfferAzureOperations CreateResourceGroup(this IOfferAzureResourceGroupOperations resourceGroup, string name, string location)
        {
            Debugger.Launch();
            var rgBuilder = resourceGroup as AzureResourceGroupOperationsBuilder;
            var createResourceGroupOperation = new CreateAzureResourceGroupOperation(name, location);
            OperationExecutor.Execute((LocalBuilder)resourceGroup, createResourceGroupOperation);
            return rgBuilder.AzureOperations;
        }
    }
}
