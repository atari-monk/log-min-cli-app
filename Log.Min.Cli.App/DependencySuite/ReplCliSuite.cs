using CommandDotNet.Unity.Helper;
using Unity;

namespace Log.Min.Cli.App;

public class ReplCliSuite 
    : LogSuite
{
    public ReplCliSuite(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override void RegisterProgram() =>
        RegisterSet<AppProgSet<ReplCli>>();
}