using Xunit;
using XUnit.Helper;

namespace Log.Min.Cli.App.TestApi;

[Collection("Serial1")]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class FixtureTests
    : OrderTest
    , IClassFixture<LogFixture>
{
    private LogFixture fixture;

    public FixtureTests(LogFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public void Test01()
    {
        Test();
    }

    private void Test()
    {
        fixture.AssertLogCount(fixture.Uow, 0);
    }

    [Fact]
    public void Test02()
    {
        Test();
    }
}