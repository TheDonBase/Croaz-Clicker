using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class PlayAd : MonoBehaviour {

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
