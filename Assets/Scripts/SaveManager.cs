using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveManager : MonoBehaviour
{
    float saveTime = 300;
    public UpgradeManager upgrade;
    public ShopManager item;
    public BaseGame baseGame;
    public float gold = 0;
    public float goldPClick = 1;
    public float goldPSec = 0;
    public float clicks = 0;
    public float goldMade = 0;
    public int itemNumbers = 0;
    public int upgradeNumbers = 0;
    public int boughtAds = 0;
    public int diamonds = 0;
    public Text infoMsg;


    public void Start()
    {
        load();
    }

    public void Update()
    {
        saveTime -= Time.deltaTime;
        if (saveTime <= 0)
        {
            save();
            saveTime = 300;
        }
    }

	public void reset(){
		PlayerPrefs.SetFloat("gold", 0f);
		PlayerPrefs.SetFloat("goldPerClick", 1f);
		PlayerPrefs.SetFloat("goldPerSec", 0f);
		PlayerPrefs.SetFloat("clicks", 0f);
		PlayerPrefs.SetFloat("goldMade", 0f);
		PlayerPrefs.SetInt("itemNumbers", 0);
		PlayerPrefs.SetInt("upgradeNumbers", 0);
		PlayerPrefs.SetInt("diamonds", 0);
		PlayerPrefs.SetInt("purchasedAds", 0);
		PlayerPrefs.Save();
		StartCoroutine(ShowMessage("The game has just been reset.", 10));
		Debug.Log("Reset game.");
	}
    public void save()
    {
        PlayerPrefs.SetFloat("gold", baseGame.gold);
        PlayerPrefs.SetFloat("goldPerClick", baseGame.goldPerClick);
        PlayerPrefs.SetFloat("goldPerSec", baseGame.goldPerSec);
        PlayerPrefs.SetFloat("clicks", baseGame.clicks);
        PlayerPrefs.SetFloat("goldMade", baseGame.goldMade);
        PlayerPrefs.SetInt("itemNumbers", item.count);
        PlayerPrefs.SetInt("upgradeNumbers", upgrade.count);
        PlayerPrefs.SetInt("diamonds", baseGame.diamonds);
        PlayerPrefs.SetInt("purchasedAds", baseGame.boughtAds);
        PlayerPrefs.Save();
        StartCoroutine(ShowMessage("The game has just been saved.", 10));
        Debug.Log("Saved game.");
    }

    public void load()
    {
		/**
		 *  PlayerPrefs.Get*(string value, string/int/float defaultValue);
		 * */
        // todo load system.
		gold = PlayerPrefs.GetFloat("gold");
		goldPClick = PlayerPrefs.GetFloat ("goldPerClick", 0f); 
		goldPSec = PlayerPrefs.GetFloat ("goldPerSec");
		clicks = PlayerPrefs.GetFloat ("clicks");
		goldMade = PlayerPrefs.GetFloat ("goldMade");
		itemNumbers = PlayerPrefs.GetInt ("itemNumbers");
		upgradeNumbers = PlayerPrefs.GetInt ("upgradeNumbers");
		boughtAds = PlayerPrefs.GetInt ("purchasedAds");
		diamonds = PlayerPrefs.GetInt ("diamonds");
		Debug.Log ("Loaded game.");
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        infoMsg.text = message;
        infoMsg.enabled = true;
        yield return new WaitForSeconds(delay);
        infoMsg.enabled = false;
    }
}
