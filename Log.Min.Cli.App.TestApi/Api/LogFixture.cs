using Log.Min.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Log.Min.Cli.App.TestApi;

public class LogFixture
    : LogTestApi
        , IDisposable
{
    public LogBootstraper Booter { get; private set; }

    public ILogUnitOfWork Uow { get; private set; }

    public IDbContextTransaction Transaction { get; private set; }

    public bool KeepData { get; set; } = false;

    public Guid FixtureId { get; private set; }

    public LogFixture()
    {
        Booter = GetBooter();
        Uow = GetUnitOfWork(Booter);
        Transaction = Uow.BeginTransaction();
        FixtureId = Guid.NewGuid();
    }

    public void Dispose()
    {
        if(KeepData == false)
            Transaction.Rollback();
        else
            Transaction.Commit();
    }
}