using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class FancyText : MonoBehaviour {

    /*------------Variables------------*/
    public BaseGame baseGame;
    public ShopManager[] items;
    /*------------End of Variables------------*/

    void Start()
    {
        StartCoroutine(AutoTick());
    }

        public float GetGoldPerSec()
        {
            float goldPerSec = 0;
            foreach(ShopManager item in items) 
            {
                goldPerSec += item.addPerSec * item.count * item.multiplier;
            }
            return goldPerSec;
        }

        public void AutoGoldPerSec()
        {
            baseGame.gold += GetGoldPerSec() / 100;
            baseGame.goldMade += GetGoldPerSec() / 100;
        }

        IEnumerator AutoTick()
        {
            while (true)
        {
            AutoGoldPerSec();
            yield return new WaitForSeconds(0.01f);
        }
    }
}
