using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Translater 
{
    public static Dictionary<string, string> SymbolNames {get; private set;}

    static Translater()
    {
        SymbolNames = new Dictionary<string, string>();
       SymbolNames.Add("LC_letters_1_0", "A");
       SymbolNames.Add("LC_letters_1_1", "B");
       SymbolNames.Add("LC_letters_1_2", "C");
       SymbolNames.Add("LC_letters_1_3", "D");
       SymbolNames.Add("LC_letters_1_4", "F");
       SymbolNames.Add("LC_letters_1_5", "G");
       SymbolNames.Add("LC_letters_1_6", "J");
       SymbolNames.Add("LC_letters_1_7", "I");
       SymbolNames.Add("LC_letters_1_8", "E");
       SymbolNames.Add("LC_letters_1_9", "H");
       SymbolNames.Add("LC_letters_1_10", "K");
       SymbolNames.Add("LC_letters_1_11", "L");
       SymbolNames.Add("LC_letters_1_12", "M");
       SymbolNames.Add("LC_letters_2_0", "R");
       SymbolNames.Add("LC_letters_2_1", "S");
       SymbolNames.Add("LC_letters_2_2", "U");
       SymbolNames.Add("LC_letters_2_3", "V");
       SymbolNames.Add("LC_letters_2_4", "O");
       SymbolNames.Add("LC_letters_2_5", "Q");
       SymbolNames.Add("LC_letters_2_6", "W");
       SymbolNames.Add("LC_letters_2_7", "T");
       SymbolNames.Add("LC_letters_2_8", "N");
       SymbolNames.Add("LC_letters_2_9", "P");
       SymbolNames.Add("LC_letters_2_10", "X");
       SymbolNames.Add("LC_letters_3_0", "Y");
       SymbolNames.Add("LC_letters_3_1", "Z");
       SymbolNames.Add("SD_NC_Cookies_1_0", "1");
       SymbolNames.Add("SD_NC_Cookies_1_1", "2");
       SymbolNames.Add("SD_NC_Cookies_1_2", "3");
       SymbolNames.Add("SD_NC_Cookies_1_3", "5");
       SymbolNames.Add("SD_NC_Cookies_1_4", "4");
       SymbolNames.Add("SD_NC_Cookies_1_5", "6");
       SymbolNames.Add("SD_NC_Cookies_1_6", "7");
       SymbolNames.Add("SD_NC_Cookies_1_7", "8");
       SymbolNames.Add("SD_NC_Cookies_2", "9");
       SymbolNames.Add("SD_NC_Cookies_3", "10");
    }

    public static string Translate(string name)
    {
        foreach (var symbolName in SymbolNames)
            if (symbolName.Key == name)
                return symbolName.Value;
        return null;
    }
}
