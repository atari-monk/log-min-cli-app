using DIHelper.Unity;
using Log.Min.Data;
using Unity;

namespace Log.Min.Cli.App;

public class AppDatabase 
    : UnityDependencySet
{
    public AppDatabase(
        IUnityContainer container) 
            : base(container)
    {
    }

    public override void Register()
    {
        Container
            .RegisterSingleton<LogDbContext>()
            .RegisterSingleton<ILogRepo, LogRepo>()
            .RegisterSingleton<ILogUnitOfWork, LogUnitOfWork>();
    }
}