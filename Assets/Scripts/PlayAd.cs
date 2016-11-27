using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class PlayAd : MonoBehaviour {

    private int oldDiamonds;
    private int newDiamonds;
    private int diamondsToAdd;

    public void Start()
    {
        oldDiamonds = PlayerPrefs.GetInt("diamonds");
        newDiamonds = 5;
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
        }
    }

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Player Watched it. + 5 diamonds");
                diamondsToAdd += oldDiamonds + newDiamonds;
                PlayerPrefs.SetInt("diamonds", diamondsToAdd);
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
