using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;
using System.Collections.Generic;
using UnityEngine.UI;

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
    /*------------End of Variables------------*/

    public void Start()
    {
        gold = saveManager.gold;
        goldPerClick = goldPerClick;
        goldPerSec = saveManager.goldPSec;
        clicks = saveManager.clicks;
        goldMade = saveManager.goldMade;
    }

    // Updating the display info and gold per sec
	public void Update () {
        goldDisplay.text = "Gold: " + CurCon.Instance.GetCurrencyPrefix(gold);
        clickDisplay.text = "Gold / Click: " + CurCon.Instance.GetCurrencyPrefix(goldPerClick);
        dpsDisplay.text = "Gold / Sec: " + CurCon.Instance.GetCurrencyPrefix(goldPerSec);
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
