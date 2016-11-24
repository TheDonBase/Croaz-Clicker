using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

    public void openAdWindow()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void openGameWindow()
    {
        SceneManager.LoadScene("GameScene");
    }

	public void openStoreWindow()
    {
        SceneManager.LoadScene("StoreScene");
    }
		
}
