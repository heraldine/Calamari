using Calamari.Extensibility;
using Calamari.Extensibility.FileSystem;
using Calamari.Integration.FileSystem;
using Calamari.Integration.Processes;
using Calamari.Integration.Scripting;

namespace Calamari.Deployment.Conventions
{
    /// <summary>
    /// This convention is used to detect PreDeploy.ps1, Deploy.ps1 and PostDeploy.ps1 scripts.
    /// </summary>
    public class PackagedScriptConvention : PackagedScriptRunner, IInstallConvention
    {
        public PackagedScriptConvention(string scriptFilePrefix, ICalamariFileSystem fileSystem, IScriptEngine scriptEngine, ICommandLineRunner commandLineRunner) : 
            base(scriptFilePrefix, fileSystem, scriptEngine, commandLineRunner)
        {
        }

        public void Install(RunningDeployment deployment)
        {
            RunScripts(deployment);
            if (deployment.Variables.GetFlag(SpecialVariables.DeleteScriptsOnCleanup, true))
            {
                DeleteScripts(deployment);
            }
        }
    }
}