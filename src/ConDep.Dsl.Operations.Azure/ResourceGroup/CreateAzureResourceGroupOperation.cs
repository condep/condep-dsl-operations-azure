using System.Threading;
using ConDep.Dsl.Config;

namespace ConDep.Dsl.Operations.Azure.ResourceGroup
{
    public class CreateAzureResourceGroupOperation : LocalOperation
    {
        public override Result Execute(ConDepSettings settings, CancellationToken token)
        {    
            return new Result(true, false);
        }

        public override string Name { get; }
    }
}