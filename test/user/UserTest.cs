namespace SBRunScr.user;

public class UserTest
{
    [Fact]
    public void TestUserFile()
    {
        string actual = new User().UserFile();
        string expected = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "SBRunScr", "settings.db");
        Console.WriteLine($"actual UserFile: {actual}");
        Console.WriteLine($"expected UserFile: {expected}");
        Assert.Equal(expected, actual);
    }
}