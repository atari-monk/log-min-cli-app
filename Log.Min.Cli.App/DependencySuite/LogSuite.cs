using CLIHelper.Unity;
using Config.Wrapper.Unity;
using DIHelper.Unity;
using Log.Min.Lib;
using Log.Min.Table;
using Serilog.Wrapper.Unity;
using Unity;

namespace Log.Min.Cli.App;

public class LogSuite 
    : UnityDependencySuite
{
    public LogSuite(
        IUnityContainer container) 
        : base(container) 
    {
    }

    protected override void RegisterAppData()
    {
        RegisterSet<SerilogSet>();
        RegisterSet<AppConfigSet>();
    }

    protected override void RegisterDatabase()=> 
        RegisterSet<AppDatabase>();

    protected override void RegisterConsoleInput() => 
        RegisterSet<CliIOSet>();

    protected override void RegisterConsoleOutput() => 
        RegisterSet<LogTableSet>();

    protected override void RegisterDataMappings()
    {
        RegisterSet<AppMappings>();
        RegisterSet<DataFilter>();        
    }

    protected override void RegisterCommands() => 
        RegisterSet<AppCommands>();
}