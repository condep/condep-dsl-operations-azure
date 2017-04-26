using System.Threading;
using ConDep.Dsl.Config;

namespace ConDep.Dsl.Operations.Azure.ResourceGroup
{
    public class CreateAzureResourceGroupOperation : LocalOperation
    {
        private readonly string _name;
        private readonly string _location;

        public CreateAzureResourceGroupOperation(string name, string location)
        {
            _name = name;
            _location = location;
        }

        public override Result Execute(ConDepSettings settings, CancellationToken token)
        {
            var psExecutor = new ConDep.Dsl.Remote.PowerShellExecutor();
            dynamic result = psExecutor.ExecuteLocal(new ServerConfig {Name = "localhost"}, @"Write-Host ""Halloen""");
            return new Result(true, false);
        }

        //public override Result Execute(IOfferRemoteOperations remote, ServerConfig server, ConDepSettings settings, CancellationToken token)
        //{
        //var psExecutor = new PowerShellExecutor();
        //dynamic result = psExecutor.ExecuteLocal(server, @"Write-Host ""Halloen""");

        //var subscriptionId = settings.Config.OperationsConfig.Azure.SubscriptionId;
        //var username = settings.Config.OperationsConfig.Azure.Username;
        //var password = settings.Config.OperationsConfig.Azure.Password;

        //using (PowerShell pwInstance = PowerShell.Create())
        //{
        //                pwInstance.AddScript(String.Format(@"
        //$subscriptionId = ""{0}""
        //$secpasswd = ConvertTo-SecureString “{2}” -AsPlainText -Force
        //$credentials = New-Object System.Management.Automation.PSCredential(“{1}”, $secpasswd)
        //Add - AzureRmAccount-Credential $credentials
        //Set - AzureRmContext-SubscriptionID $subscriptionId

        //New -AzureRmResourceGroup -Name {3} -Location {4} -Force
        //", subscriptionId, username, password, _name, _location));

        //pwInstance.AddScript("Write-Host hei på deg");
        //dynamic result = pwInstance.Invoke();
        //}
        //return new Result(true, false);
        //}

        public override string Name { get { return "Create Azure Resource Group: " + _name; } }
    }
}