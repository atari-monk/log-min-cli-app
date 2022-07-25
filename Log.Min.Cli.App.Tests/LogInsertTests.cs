using Log.Min.Cli.App.TestApi;
using Log.Min.Data;
using Xunit;
using XUnit.Helper;

namespace Log.Min.Cli.App.Tests;

[Collection(DbTests)]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class LogInsertTests
    : OrderTest
    , IClassFixture<LogFixture>
{
    private LogFixture fixture;

    public LogInsertTests(LogFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(LogData.Insert01)
        , MemberType= typeof(LogData))]
    public void Test04(params string[] cmd)
    {
        fixture.AssertLogCount(fixture.Uow, 0);
        fixture.RunCmd(fixture.Booter, cmd);
        fixture.AssertLogCount(fixture.Uow, 1);
        var logModel = fixture.GetLog(fixture.Uow, elementIndex: 0);
        fixture.AssertLog(
            new LogModel 
            {
                Description = "test"
                , Start = new DateTime(2022, 7, 21, 17, 0, 0)
                , End = new DateTime(2022, 7, 21, 18, 0, 0)
                , Time = new TimeSpan(0, 0, 0, 0)
            }
            , logModel);
    }

    private void SetValue(
        List<string> cmd
        , string key
        , string value)
    {
        cmd[GetIndex(cmd, key)] = value;
    }

    private int GetIndex(List<string> cmd, string value)
    {
        return cmd.IndexOf(value);
    }
}