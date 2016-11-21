using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {


    /*-------------todo here:--------------*/
    // A new and better ItemManager.
    // Balance the cost.
    // Add more items
    // Multipliers
    // Invidual upgrades
    /*----------End of Todo--------------*/






    /*------------Variables------------*/
    public Text errorMessage;
    public Text itemInfo;
    public BaseGame baseGame;
    public float cost;
    public float addPerSec;
    public int count;
    public string itemName;
    private float baseCost;
    public SaveManager sm;
    /*------------End of Variables------------*/

    // baseCost is the cost.
    void Start()
    {
        baseCost = cost;
        count = sm.itemNumbers;
    }

    // Refreshing the iteminfo and the cost. (till i can figure out a better save/load function
    void Update()
    {
        itemInfo.text = itemName + " (" + count + ")\nCost: " + CurCon.GetCurrencyPrefix(cost) + "\nGold " + CurCon.GetCurrencyPrefix(addPerSec) + " / s";
        cost = Mathf.Round(baseCost * Mathf.Pow(1.12f, count));
    }

    /*------------Buy Function------------*/
    public void PurchasedItem()
    {

        if (baseGame.gold < cost)
        {
            float goldDifference = cost - baseGame.gold;
            StartCoroutine(ShowMessage("You do not have the required amount of Gold,\n To purchase " + itemName + ",\nYou are missing: " + CurCon.GetCurrencyPrefix(goldDifference) + " Gold.", 10));
            Debug.Log("Did not Buy one.");
        }
        else
        {
            baseGame.gold -= cost;
            count += 1;
            cost = Mathf.Round(baseCost * Mathf.Pow(1.12f, count));
            Debug.Log("Bought 1.");
        }
    }
    /*------------End of Buy Function------------*/


    /*------------Error message Popup------------*/
    IEnumerator ShowMessage(string message, float delay)
    {
        errorMessage.text = message;
        errorMessage.enabled = true;
        yield return new WaitForSeconds(delay);
        errorMessage.enabled = false;
    }
}
