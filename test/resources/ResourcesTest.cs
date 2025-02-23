using System.Drawing;
using SBRunScr.resources;

namespace SBRunScr.test.resources;

public class ResourcesTest
{
    [Fact]
    public void TestGetIconSuccess()
    {
        Icon? actual = Resources.GetIcon("main.ico");
        Assert.NotNull(actual);
    }

    [Fact]
    public void TestGetIconFailed()
    {
        Assert.Throws<InvalidDataException>(() => Resources.GetIcon("unknown.ico"));
    }

    [Fact]
    public void TestGetImageSuccess()
    {
        Image? actual = Resources.GetImage("main.ico");
        Assert.NotNull(actual);
    }

    [Fact]
    public void TestGetImageFailed()
    {
        Assert.Throws<InvalidDataException>(() => Resources.GetImage("unknown.ico"));
    }

    [Fact]
    public void TestGetStreamSuccess()
    {
        Stream? actual = Resources.GetStream("main.ico");
        Assert.NotNull(actual);
    }

    [Fact]
    public void TestGetStreamFailed()
    {
        Stream? actual = Resources.GetStream("unknown.ico");
        Assert.Null(actual);
    }
}
