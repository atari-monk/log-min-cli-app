using CommandDotNet;
using CommandDotNet.Unity.Helper;
using Config.Wrapper;
using Serilog;

namespace Log.Min.Cli.App;

public class CommandCli 
    : AppProgUnity<CommandCli>
{
    [Subcommand]
    public LogCommands? LogCommands { get; set; }

    public CommandCli(
        ILogger log
        , IConfigReader config) 
            : base(log, config)
    {
    }
}