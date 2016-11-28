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
    public Text diamondDisplay;

    public UpgradeManager upgradeManager;
    public SaveManager saveManager;
    public float gold = 0;
    public float goldPerClick = 1;
    public float goldPerSec;
    public float clicks = 0;
    public float goldMade = 0;
    public int diamonds = 0;
    public int boughtAds = 0;
    private float timer = 300;
    /*------------End of Variables------------*/

    public void Start()
    {
		saveManager.load ();
        gold = saveManager.gold;
        goldPerClick = saveManager.goldPClick;
        goldPerSec = saveManager.goldPSec;
        clicks = saveManager.clicks;
        goldMade = saveManager.goldMade;
        diamonds = saveManager.diamonds;
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
        diamondDisplay.text = "Diamonds: " + diamonds;
        goldPerSec = FindObjectOfType<FancyText>().GetGoldPerSec();

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show("video", new ShowOptions() { resultCallback = HandleAdResult });
            }
            timer = 300;
        }
    }


    // Click function
    public void clickOnce()
    {
        gold += goldPerClick;
        clicks++;
        goldMade++;
    }

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Player Watched it.");
                break;
            case ShowResult.Skipped:
                Debug.Log("Player Skipped it.");

                break;
            case ShowResult.Failed:
                Debug.Log("Played Failed it.");
                break;
        }
    }
    
}
