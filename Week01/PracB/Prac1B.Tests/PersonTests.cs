using Xunit;

public class PersonTests
{
    [Fact]
    public void FullName_ReturnsExpectedFormat()
    {
        Person person = new Person("John", "Smith", 20);

        string result = person.FullName();

        Assert.Equal("Smith, John", result);
    }

    [Fact]
    public void IsAdult_ReturnsTrue_WhenAge18OrMore()
    {
        Person person = new Person("John", "Smith", 18);

        bool result = person.IsAdult();

        Assert.True(result);
    }
}