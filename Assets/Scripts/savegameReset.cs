using UnityEngine;
using System.Collections;

public class savegameReset : MonoBehaviour {
    
    public void resetSavegame()
    {
        PlayerPrefs.SetFloat("gold", 0);
        PlayerPrefs.SetFloat("goldPerClick", 1);
        PlayerPrefs.SetFloat("goldPerSec", 0);
        PlayerPrefs.SetFloat("clicks", 0);
        PlayerPrefs.SetFloat("goldMade", 0);
        PlayerPrefs.SetInt("itemNumbers", 0);
        PlayerPrefs.SetInt("upgradeNumbers", 0);
        PlayerPrefs.SetInt("diamonds", 0);
        PlayerPrefs.Save();
    }
}
