using Log.Min.Cli.App.TestApi;
using Log.Min.Data;
using Xunit;
using XUnit.Helper;

namespace Log.Min.Cli.App.Tests;

[Collection(DbTests)]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class LogUpdateTests
    : OrderTest
    , IClassFixture<LogFixture>
{
    private LogFixture fixture;

    public LogUpdateTests(LogFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(LogData.Insert01), MemberType= typeof(LogData))]
    public void Test01(params string[] cmd)
    {
        fixture.RunCmd(fixture.Booter, cmd);
    }

    [Theory]
    [MemberData(nameof(LogData.Update01), MemberType= typeof(LogData))]
    public void Test04(params string[] cmd)
    {
        fixture.AssertLogCount(fixture.Uow, 1);
        var logOld = fixture.GetLog(fixture.Uow, elementIndex: 0);
        fixture.AssertLog(
            new LogModel 
            {
                Description = "test"
                , Start = new DateTime(2022, 7, 21, 17, 0, 0)
                , End = new DateTime(2022, 7, 21, 18, 0, 0)
                , Time = new TimeSpan(0, 0, 0, 0)
            }
            , logOld);
        var command = new List<string>(cmd);
        SetValue(command, "logid", logOld.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        fixture.AssertLogCount(fixture.Uow, 1);
        var logNew = fixture.GetLog(fixture.Uow, elementIndex: 0);
        fixture.AssertLog(
            new LogModel 
            {
                Description = "moddified"
                , Start = new DateTime(2022, 7, 22, 21, 0, 0)
                , End = new DateTime(2022, 7, 22, 21, 15, 0)
                , Time = new TimeSpan(0, 0, 15, 0)
            }
            , logNew);
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