using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    /*------------Variables------------*/
    public Color standard;
    public Color affordable;
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
        itemInfo.text = itemName + " (" + count + ")\nCost: " + CurCon.Instance.GetCurrencyPrefix(cost) + "\nGold " + CurCon.Instance.GetCurrencyPrefix(addPerSec) + " / s";
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
    public void PurchasedItem()
    {

        if (baseGame.gold < cost)
        {
            float goldDifference = cost - baseGame.gold;
            StartCoroutine(ShowMessage("You do not have the required amount of Gold,\n To purchase " + itemName + ",\nYou are missing: " + CurCon.Instance.GetCurrencyPrefix(goldDifference) + " Gold.", 10));
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

    /*------------Better Item Manager------------*/


    /*
    [System.Serializable]
    public class _items
    {
        public int amountOfItems;
        public string itemName;
        public float cost;
        public float addPerSec;
        private int baseCost;
      
      
      
      
       [System.NotSerializable]
       public int count;
    }
    /*------------End of Item Manager 2.0------------*/














































}
