using Log.Min.Data;
using Xunit;

namespace Log.Min.Cli.App.TestApi;

public abstract class LogTestApi
    : AppTestApi
{
    protected static IEnumerable<LogModel>? GetLog(
        ILogUnitOfWork? unitOfWork)
    {
        return unitOfWork?.Log?.Get();
    }

    public void AssertLogCount(
        ILogUnitOfWork? repo
        , int expected)
    {
        var actual = GetLog(repo)?.Count();
        Assert.True(expected == actual);
    }

    public LogModel GetLog(
        ILogUnitOfWork? repo
        , int elementIndex)
    {
        var data = GetLog(repo)?.ElementAt(elementIndex);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }

    public void AssertLog(
        LogModel expected
        , LogModel acctual)
    {
        Assert.True(acctual?.Id > 0);
        Assert.True(acctual?.Description == expected.Description);
        Assert.True(acctual?.Start == expected.Start);
        Assert.True(acctual?.End == expected.End);
        Assert.True(acctual?.Time == expected.Time);
    }
}