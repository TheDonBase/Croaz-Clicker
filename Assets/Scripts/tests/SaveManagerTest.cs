using System;
using UnityEngine;
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

	/**
	 * @Return dynamic stats
	 * */
	public dynamic reset(){
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
		return load("The game has just been reset.");
	}

	/**
	 * @Parameter(name="stats", type="dynamic")
	 * @Return dynamic stats
	 * */
	public dynamic save(dynamic stats)
	{
		PlayerPrefs.SetFloat("gold",(float)stats.gold);
		PlayerPrefs.SetFloat("goldPerClick", stats.goldPerClick);
		PlayerPrefs.SetFloat("goldPerSec", stats.goldPerSec);
		PlayerPrefs.SetFloat("clicks", stats.clicks);
		PlayerPrefs.SetFloat("goldMade", stats.goldMade);
		PlayerPrefs.SetInt("diamonds", stats.diamonds);
		PlayerPrefs.SetInt("purchasedAds", stats.boughtAds);
		PlayerPrefs.SetInt("item_number1", stats.count);
		PlayerPrefs.SetInt("item_number2", stats.count);
		PlayerPrefs.SetInt("item_number3", stats.count);
		PlayerPrefs.SetInt("upgrade_number1", stats.count);
		PlayerPrefs.SetInt("upgrade_number2", stats.count);
		PlayerPrefs.SetInt("upgrade_number3", stats.count);
		PlayerPrefs.Save();
		stats.Message = "The game has just been saved.";
		return stats;
	}

	/**
	 * @Parameter(name="message", type="string", default=null)
	 * @Return dynamic stats
	 * */
	public dynamic load(string message = null)
	{
		/**
		 *  PlayerPrefs.Get*(string value, string/int/float defaultValue);
		 * */
		dynamic stats;
		stats.Gold = PlayerPrefs.GetFloat("gold");
		stats.GoldPClick = PlayerPrefs.GetFloat ("goldPerClick", 0f); 
		stats.GoldPSec = PlayerPrefs.GetFloat ("goldPerSec");
		stats.Clicks = PlayerPrefs.GetFloat ("clicks");
		stats.GoldMade = PlayerPrefs.GetFloat ("goldMade");
		stats.BoughtAds = PlayerPrefs.GetInt ("purchasedAds");
		stats.Diamonds = PlayerPrefs.GetInt ("diamonds");
		stats.Item1.Count = PlayerPrefs.GetInt("item_number1");
		stats.Item2.Count = PlayerPrefs.GetInt("item_number2");
		stats.Item3.Count = PlayerPrefs.GetInt("item_number3");
		stats.Upgrade1.Count = PlayerPrefs.GetInt("upgrade_number1");
		stats.Upgrade2.Count = PlayerPrefs.GetInt("upgrade_number2");
		stats.Upgrade3.Count = PlayerPrefs.GetInt("upgrade_number3");
		stats.Message = (message == null)? "Loaded Game." : message ;

		return stats;
	}
}