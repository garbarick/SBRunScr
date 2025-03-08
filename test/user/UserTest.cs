namespace SBRunScr.user;

public class UserTest
{
    [Fact]
    public void TestUserFile()
    {
        string name = "test.txt";
        string actual = new User().UserFile(name);
        string expected = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "SBRunScr", name);
        Console.WriteLine($"actual UserFile: {actual}");
        Console.WriteLine($"expected UserFile: {expected}");
        Assert.Equal(expected, actual);
    }
}