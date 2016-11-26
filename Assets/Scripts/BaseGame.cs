using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class BaseGame : MonoBehaviour {

    /*------------Variables------------*/

    public Text goldDisplay;
    public Text clickDisplay;
    public Text dpsDisplay;

    public UpgradeManager upgradeManager;
    public SaveManager saveManager;
    public float gold = 0;
    public float goldPerClick = 1;
    public float goldPerSec;
    public float clicks = 0;
    public float goldMade = 0;
    public int diamonds = 0;
    public int boughtAds = 0;
    /*------------End of Variables------------*/

    public void Start()
    {
        gold = saveManager.gold;
        goldPerClick = saveManager.goldPClick;
        goldPerSec = saveManager.goldPSec;
        clicks = saveManager.clicks;
        goldMade = saveManager.goldMade;
        if (boughtAds == 1)
        {
            Debug.Log("Bought No-ads");
        }
    }

    // Updating the display info and gold per sec
	public void Update () {
        goldDisplay.text = "Gold: " + CurCon.GetCurrencyPrefix(gold);
        clickDisplay.text = "Gold / Click: " + CurCon.GetCurrencyPrefix(goldPerClick);
        dpsDisplay.text = "Gold / Sec: " + CurCon.GetCurrencyPrefix(goldPerSec);
        goldPerSec = FindObjectOfType<FancyText>().GetGoldPerSec();
	}


    // Click function
    public void clickOnce()
    {
        gold += goldPerClick;
        clicks++;
        goldMade++;
    }

    
}
