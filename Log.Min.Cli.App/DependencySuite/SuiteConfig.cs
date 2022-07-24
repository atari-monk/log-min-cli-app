using CLIHelper;
using CommandDotNet.Helper;
using Config.Wrapper;
using DIHelper;
using Unity;

namespace Log.Min.Cli.App;

public class SuiteConfig
{
    private readonly IConfigReader configReader;

    public SuiteConfig(
        IConfigReader configReader)
    {
        this.configReader = configReader;
    }

    public IDependencySuite GetSuite(IUnityContainer unity)
    {
        var settings = configReader.GetConfigSection<CommandDotNetSettings>(
            nameof(CommandDotNetSettings));
        ArgumentNullException.ThrowIfNull(settings);
        var runMode = configReader.GetConfigSection<RunMode>(nameof(RunMode));
        ArgumentNullException.ThrowIfNull(runMode);
        if(runMode.Test)
            return new TestCliSuite(unity);
        if(settings.UseRepl)
            return new ReplCliSuite(unity);
        else
            return new CommandCliSuite(unity);
    }
}