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

    public void save()
    {
        PlayerPrefs.SetFloat("gold", baseGame.gold);
        PlayerPrefs.SetFloat("goldPerClick", baseGame.goldPerClick);
        PlayerPrefs.SetFloat("goldPerSec", baseGame.goldPerSec);
        PlayerPrefs.SetFloat("clicks", baseGame.clicks);
        PlayerPrefs.SetFloat("goldMade", baseGame.goldMade);
        PlayerPrefs.SetInt("itemNumbers", item.count);
        PlayerPrefs.SetInt("upgradeNumbers", upgrade.count);
        PlayerPrefs.Save();
        StartCoroutine(ShowMessage("The game has just been saved.", 10));
        Debug.Log("Saved game.");
    }

    public void load()
    {
        // todo load system.
      
            gold = PlayerPrefs.GetFloat("gold");
            if (!PlayerPrefs.HasKey("goldPerClick"))
            {
                goldPClick = 1;
            } else {
            goldPClick = PlayerPrefs.GetFloat("goldPerClick");
            }
            goldPSec = PlayerPrefs.GetFloat("goldPerSec");
       
            clicks = PlayerPrefs.GetFloat("clicks");
       
            goldMade = PlayerPrefs.GetFloat("goldMade");
       
            itemNumbers = PlayerPrefs.GetInt("itemNumbers");
        
            upgradeNumbers = PlayerPrefs.GetInt("upgradeNumbers");
            
            Debug.Log("Loaded game.");
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        infoMsg.text = message;
        infoMsg.enabled = true;
        yield return new WaitForSeconds(delay);
        infoMsg.enabled = false;
    }
}
