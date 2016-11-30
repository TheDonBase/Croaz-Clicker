using System;
using UnityEngine.UI;
using System.Collections;
using Core;

public class SaveManagerTest : CoreClass
{
	public override void Start(){
		// the required Start method
	}

	public override void Update(){
		// the required Update method
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
}