using ConDep.Dsl.Config;

namespace ConDep.Dsl.Operations.Azure.Tests
{
    public class AzureTest : Runbook
    {
        public override void Execute(IOfferOperations dsl, ConDepSettings settings)
        {
            const string location = "West Europe";
            dsl.Local.Azure(azure => azure.ResourceGroup.CreateResourceGroup("resourcegroup-name", location));
        }
    }
}
