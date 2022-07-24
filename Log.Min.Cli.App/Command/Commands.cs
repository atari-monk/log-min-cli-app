using Config.Wrapper;
using CRUDCommandHelper;

namespace Log.Min.Cli.App;

public abstract class Commands
{
    protected const string InsertCmd = "ins";
    protected const string UpdateCmd = "upd";
    protected const string DeleteCmd = "del";
    protected const string ReadCmdAfterChangeConfigKey = "ReadCmdAfterChange";
    private readonly IConfigReader config;
    protected CmdSettings? CmdSettings;

    public Commands(
        IConfigReader config)
    {
        this.config = config;
        ArgumentNullException.ThrowIfNull(this.config);
        CmdSettings = config.GetConfigSection<CmdSettings>(
            nameof(CmdSettings));
        ArgumentNullException.ThrowIfNull(CmdSettings);
    }

    protected async void ReadAfterChange(Func<Task> readDelegateAsync)
    {
        if (IsReadAfterChangeOff())
            return;
        await readDelegateAsync();
    }

    private bool IsReadAfterChangeOff()
    {
        return CmdSettings == null || CmdSettings.ReadCmdAfterChange == false;
    }

    protected Func<Task> GetReadTask<TArgs>(
        IReadCommand<TArgs> readCommand
        , TArgs model)
    {
        return async () =>
            await Task.Run(
                () => readCommand.Read(model));
    }
}