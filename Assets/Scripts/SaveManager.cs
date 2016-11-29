using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveManager : MonoBehaviour
{
    float saveTime = 300;
    public ShopManager item1;
    public ShopManager item2;
    public ShopManager item3;
    public UpgradeManager upgrade1;
    public UpgradeManager upgrade2;
    public UpgradeManager upgrade3;
    public BaseGame baseGame;

    public float gold = 0;
    public float goldPClick = 1;
    public float goldPSec = 0;
    public float clicks = 0;
    public float goldMade = 0;
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
            saveTime = 60;
        }
    }

	public void reset(){
		PlayerPrefs.SetFloat("gold", 0f);
		PlayerPrefs.SetFloat("goldPerClick", 1f);
		PlayerPrefs.SetFloat("goldPerSec", 0f);
		PlayerPrefs.SetFloat("clicks", 0f);
		PlayerPrefs.SetFloat("goldMade", 0f);
		PlayerPrefs.SetInt("item_number1", 0);
        PlayerPrefs.SetInt("item_number2", 0);
        PlayerPrefs.SetInt("item_number3", 0);
        PlayerPrefs.SetInt("upgrade_number1", 0);
        PlayerPrefs.SetInt("upgrade_number2", 0);
        PlayerPrefs.SetInt("upgrade_number3", 0);
        PlayerPrefs.SetInt("diamonds", 0);
		PlayerPrefs.SetInt("purchasedAds", 0);
		PlayerPrefs.Save();
		StartCoroutine(ShowMessage("The game has just been reset.", 10));
        load();
        baseGame.Update();
		Debug.Log("Reset game.");
	}
    public void save()
    {
        PlayerPrefs.SetFloat("gold", baseGame.gold);
        PlayerPrefs.SetFloat("goldPerClick", baseGame.goldPerClick);
        PlayerPrefs.SetFloat("goldPerSec", baseGame.goldPerSec);
        PlayerPrefs.SetFloat("clicks", baseGame.clicks);
        PlayerPrefs.SetFloat("goldMade", baseGame.goldMade);
        PlayerPrefs.SetInt("diamonds", baseGame.diamonds);
        PlayerPrefs.SetInt("purchasedAds", baseGame.boughtAds);
        PlayerPrefs.SetInt("item_number1", item1.count);
        PlayerPrefs.SetInt("item_number2", item2.count);
        PlayerPrefs.SetInt("item_number3", item3.count);
        PlayerPrefs.SetInt("upgrade_number1", upgrade1.count);
        PlayerPrefs.SetInt("upgrade_number2", upgrade2.count);
        PlayerPrefs.SetInt("upgrade_number3", upgrade3.count);
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
		boughtAds = PlayerPrefs.GetInt ("purchasedAds");
		diamonds = PlayerPrefs.GetInt ("diamonds");
        item1.count = PlayerPrefs.GetInt("item_number1");
        item2.count = PlayerPrefs.GetInt("item_number2");
        item3.count = PlayerPrefs.GetInt("item_number3");
        upgrade1.count = PlayerPrefs.GetInt("upgrade_number1");
        upgrade2.count = PlayerPrefs.GetInt("upgrade_number2");
        upgrade3.count = PlayerPrefs.GetInt("upgrade_number3");
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
