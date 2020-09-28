using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void NewGame()
	{
		SceneManager.LoadScene("Level_1");

		PlayerPrefs.SetInt("ScoreCount", 0);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
