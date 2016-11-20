using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

    /*------------Variables------------*/
    public Color standard;
    public Color affordable;
    public Text errorMsg;
    public BaseGame baseGame;
    public Text itemInfo;
    public float cost;
    public int count = 0;
    public float minePower;
    public string itemName;
    private float baseCost;
    public SaveManager sm;
    /*------------End of Variables------------*/

    // baseCost is the cost.
    void Start()
    {
        baseCost = cost;
        count = sm.upgradeNumbers;
    }

    // Refreshing the iteminfo and the cost. (till i can figure out a better save/load function
    void Update()
    {
        itemInfo.text = itemName + " (" + count + ")\nCost: " + CurCon.Instance.GetCurrencyPrefix(cost) + "\nMining Per Sec: " + CurCon.Instance.GetCurrencyPrefix(minePower);
        cost = Mathf.Round(baseCost * Mathf.Pow(1.12f, count));

        if (baseGame.gold >= cost)
        {
            GetComponent<Image>().color = affordable;
        }
        else
        {
            GetComponent<Image>().color = standard;
        }
    }

    /*------------Buy Function------------*/
    public void PurchasedUpgrade()
    {
        if (baseGame.gold < cost)
        {
            float goldDifference = cost - baseGame.gold;
            StartCoroutine(ShowMessage("You do not have the required amount of Gold to purchase " + itemName + ",\nYou are missing: " + CurCon.Instance.GetCurrencyPrefix(goldDifference) + " Gold.", 10));
        }
        else
        {
            baseGame.gold -= cost;
            count += 1;
            baseGame.goldPerClick += minePower;
            cost = Mathf.Round(baseCost * Mathf.Pow(1.12f, count));
        }
    }
    /*------------End of Buy Function------------*/


    /*------------Error message Popup------------*/
    IEnumerator ShowMessage(string message, float delay)
    {
        errorMsg.text = message;
        errorMsg.enabled = true;
        yield return new WaitForSeconds(delay);
        errorMsg.enabled = false;
    }










    /*------------Better Upgrade Manager------------*/

    /*
    [System.Serializable]
    public class _items
    {
        public int amountOfItems;
        public string itemName;
        public float cost;
        public float addPerSec;
        private int baseCost;




        [System.NonSerialized]
        public int count;
    }*/
    /*------------End of Upgrade Manager 2.0------------*/



}
