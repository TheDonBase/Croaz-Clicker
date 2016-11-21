using UnityEngine;
using System.Collections;

public class CurCon
{

    // Making the text better looking.
    public static string GetCurrencyPrefix(float valueToConvert)
    {
        string converted;
        if (valueToConvert >= 1000000000)
        {
            converted = (valueToConvert / 1000000000f).ToString("f3") + " B";
        }
        else if (valueToConvert >= 1000000)
        {
            converted = (valueToConvert / 1000000f).ToString("f3") + " M";
        }
        else if (valueToConvert >= 1000)
        {
            converted = (valueToConvert / 1000f).ToString("f3") + " K";
        }
        else
        {
            converted = "" + valueToConvert.ToString("f1");
        }
        return converted;
    }
}