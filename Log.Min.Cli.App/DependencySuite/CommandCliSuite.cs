using CommandDotNet.Unity.Helper;
using Unity;

namespace Log.Min.Cli.App;

public class CommandCliSuite 
    : LogSuite
{
    public CommandCliSuite(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override void RegisterProgram() =>
        RegisterSet<AppProgSet<CommandCli>>();
}