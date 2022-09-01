using Config.Wrapper;
using DIHelper;
using Unity;

namespace Log.Min.Cli.App;

public class LogBootstraper
    : IBootstraper
{
    private IDependencySuite? suite;
    private IBootstraper? booter;

    public IDependencySuite? Suite => suite;
    public Guid AppId { get; private set; }

    public void CreateApp()
    {
        var unity = new UnityContainer()
            .AddExtension(new Diagnostic());
        var configSuite = new ConfigSuite(unity);
        configSuite.Register();
        suite = new SuiteConfig(
            unity.Resolve<IConfigReader>())
                .GetSuite(unity);
        booter = new Bootstraper(suite);
        booter.CreateApp();
        AppId = Guid.NewGuid();
    }

    public void RunApp(params string[] args)
    {  
        ArgumentNullException.ThrowIfNull(booter);
        booter.RunApp(args);
    }
}