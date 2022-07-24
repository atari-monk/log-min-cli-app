using CommandDotNet;
using Config.Wrapper;
using CRUDCommandHelper;
using Log.Min.Lib;

namespace Log.Min.Cli.App;

[Command(MainCommand)]
public class LogCommands
    : Commands
{
    private const string MainCommand = "log";

    private readonly IReadCommand<LogFilterArgs> read;
    private readonly IInsertCommand<LogInsertArgs> insert;
    private readonly IUpdateCommand<LogUpdateResetArgs> update;
    private readonly IDeleteCommand<DeleteArgs> delete;

    public LogCommands(
        IReadCommand<LogFilterArgs> read
        , IInsertCommand<LogInsertArgs> insert
        , IUpdateCommand<LogUpdateResetArgs> update
        , IDeleteCommand<DeleteArgs> delete
        , IConfigReader config)
            : base(config)
    {
        this.read = read;
        this.insert = insert;
        this.update = update;
        this.delete = delete;
    }

    [DefaultCommand()]
    public void Read(LogFilterArgs model)
    {
        read.Read(model);
    }

    [Command(InsertCmd)]
    public void Insert(LogInsertArgs model)
    {
        insert.Insert(model);
        ReadAfterChange(GetReadTask());
    }

    private Func<Task> GetReadTask()
    {
        return GetReadTask<LogFilterArgs>(
            read
            , new LogFilterArgs());
    }

    [Command(UpdateCmd)]
    public void Update(LogUpdateResetArgs model)
    {
        update.Update(model);
        ReadAfterChange(GetReadTask());
    }

    [Command(DeleteCmd)]
    public void Delete(DeleteArgs model)
    {
        delete.Delete(model);
        ReadAfterChange(GetReadTask());
    }
}