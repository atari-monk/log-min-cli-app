namespace Log.Min.Cli.App.Tests;

public class LogData
{
    public static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] { "log", "ins", "test", "21.07.2022 17:00", "21.07.2022 18:00" }
        };
    
    public static IEnumerable<object[]> Update01 =>
        new List<object[]>
        {
            new object[] { "log", "upd", "logid", "-d", "moddified", "-s", "22.07.2022 21:00", "-e", "22.07.2022 21:15" }
        };
}