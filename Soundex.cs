using System;
using System.Text;

public class Soundex
{
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return "0000";
        }

        // Initialize the Soundex code with the first character
        StringBuilder soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));

        char prevCode = GetSoundexCode(name[0]);

        // Append Soundex codes from the rest of the characters
        AppendSoundexCodes(name, soundex, ref prevCode);

        // Pad the Soundex code to ensure it is exactly 4 characters long
        PadSoundexString(soundex);

        return soundex.ToString();
    }

    private static void AppendSoundexCodes(string name, StringBuilder soundex, ref char prevCode)
    {
        for (int index=1; IsValidIndex(index,name,soundex); index++)
        {
            char code = GetSoundexCode(name[index]);
            if (ShouldAppendCode(code, prevCode))
            {
                soundex.Append(code);
                prevCode = code;
            }
        }
    }
   
    private static bool IsValidIndex(int currentIndex, string name, StringBuilder soundex)
    {
            return currentIndex < name.Length && soundex.Length < 4;
    }
    
    private static bool ShouldAppendCode(char code, char prevCode)
    {
        return code != '0' && code != prevCode;
    }

    private static void PadSoundexString(StringBuilder soundex)
    {
        while (soundex.Length < 4)
        {
            soundex.Append('0');
        }
    }
    
    private static readonly (string Characters, char Code)[] SoundexGroups = 
    {
        ("BFPV", '1'),
        ("CGJKQSXZ", '2'),
        ("DT", '3'),
        ("L", '4'),
        ("MN", '5'),
        ("R", '6')
    };
    
    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        foreach (var group in SoundexGroups)
        {
            if (group.Characters.Contains(c))
            {
                return group.Code;
            }
        }
        return '0';
    }
}
