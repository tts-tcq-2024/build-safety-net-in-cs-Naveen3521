using Xunit;

public class SoundexTests
{
    [Theory]
    [InlineData("", "0000")]
    [InlineData("   ", " 000")]
    public void GenerateSoundex_HandlesEmptyStringWhitespaceString(string name, string expectedValue)
    {
        // Act
        string actual = Soundex.GenerateSoundex(name);
        
        // Assert
        Assert.Equal(expectedValue, actual);
    }

    [Theory]
    [InlineData("A", "A000")]
    [InlineData("BF", "B000")]
    [InlineData("CPG", "C120")]
    public void GenerateSoundex_HandlesCharacterLessThanFour(string input, string expected)
    {
        // Act
        string actual = Soundex.GenerateSoundex(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("Robert", "R163")]
    [InlineData("robeRT", "R163")]
    public void GenerateSoundex_HandlesCaseSensitiveCharacters(string name, string expectedSoundex)
    {
        // Act
        string actualSoundex = Soundex.GenerateSoundex(name);

        // Assert
        Assert.Equal(expectedSoundex, actualSoundex);
    }

    [Theory]
    [InlineData("1234", "1000")]
    [InlineData("#$% ^&", "#000")]
    public void GenerateSoundex_HandlesOnlyNonAlphabeticCharacters(string name, string expectedSoundex)
    {
        // Act
        string actualSoundex = Soundex.GenerateSoundex(name);

        // Assert
        Assert.Equal(expectedSoundex, actualSoundex);
    }

    [Theory]
    [InlineData("J@hn", "J500")]
    [InlineData("Alex1nderSmith", "A425")]
    public void GenerateSoundex_HandlesNameWithSpecialCharacters(string name, string expectedSoundex)
    {
        // Act
        string actualSoundex = Soundex.GenerateSoundex(name);

        // Assert
        Assert.Equal(expectedSoundex, actualSoundex);
    }

    [Theory]
    [InlineData("Aaaa", "A000")]
    [InlineData("Danna", "D500")]
    public void GenerateSoundex_HandlesNamesWithRepeatedCharacters(string name, string expectedSoundex)
    {
        // Act
        string actualSoundex = Soundex.GenerateSoundex(name);

        // Assert
        Assert.Equal(expectedSoundex, actualSoundex);
    }

    [Theory]
    [InlineData("AEIOU", "A000")]
    [InlineData("I", "I000")]
    [InlineData("EAOUI", "E000")]
    public void GenerateSoundex_HandlesNamesWithAllVowels(string name, string expectedSoundex)
    {
        // Act
        string actualSoundex = Soundex.GenerateSoundex(name);

        // Assert
        Assert.Equal(expectedSoundex, actualSoundex);
    }

    [Theory]
    [InlineData("Oli", "O400")]      
    [InlineData("Uri", "U600")]      
    [InlineData("Oce", "O200")]  
    [InlineData("ABACAB", "A121")]
    public void GenerateSoundex_HandlesNamesWithConsonantAndVowels(string name, string expectedSoundex)
    {
        // Act
        string actualSoundex = Soundex.GenerateSoundex(name);

        // Assert
        Assert.Equal(expectedSoundex, actualSoundex);
    }

    [Theory]
    [InlineData(" Samuel", " 254")]
    [InlineData("Samuel ", "S540")]
    [InlineData("Sam uel", "S540")]
    public void GenerateSoundex_HandlesSpacesBetweenString(string name, string expectedSoundex)
    {
        // Act
        string actualSoundex = Soundex.GenerateSoundex(name);

        // Assert
        Assert.Equal(expectedSoundex, actualSoundex);
    }

    [Theory]
    [InlineData("Robert", "R163")]
    [InlineData("Alex", "A420")] 
    public void GenerateSoundex_HandlesCorrectEntry(string name, string expectedSoundex)
    {
        // Act
        string actualSoundex = Soundex.GenerateSoundex(name);

        // Assert
        Assert.Equal(expectedSoundex, actualSoundex);
    }
}
