using System.Drawing;
using SBRunScr.resources;

namespace SBRunScr.test.resources;

public class ResourcesTest
{
    [Fact]
    public void TestGetIconSuccess()
    {
        Icon actual = Resources.GetIcon("main");
        Assert.NotNull(actual);
    }

    [Fact]
    public void TestGetIconFailed()
    {
        Assert.Throws<InvalidDataException>(() => Resources.GetIcon("unknown"));
    }

    [Fact]
    public void TestGetIconAsImageSuccess()
    {
        Image actual = Resources.GetIconAsImage("main");
        Assert.NotNull(actual);
    }

    [Fact]
    public void TestGetIconAsImageFailed()
    {
        Assert.Throws<InvalidDataException>(() => Resources.GetIconAsImage("unknown"));
    }

    [Fact]
    public void TestGetStreamSuccess()
    {
        Stream? actual = Resources.GetStream("ico", "main");
        Assert.NotNull(actual);
    }

    [Fact]
    public void TestGetStreamFailed()
    {
        Stream? actual = Resources.GetStream("ico", "unknown");
        Assert.Null(actual);
    }

    [Fact]
    public void TestGetSqlSuccess()
    {
        string actual = Resources.GetSql("createTableLists");
        Assert.NotNull(actual);
    }

    [Fact]
    public void TestGetSqlFailed()
    {
        Assert.Throws<InvalidDataException>(() => Resources.GetSql("unknown"));
    }
}
