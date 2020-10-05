using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
	public Text scoreText;
	public int scoreCount;
	
    void onEnable ()
	{
		scoreText.text = "Score: " + scoreCount;
	}
}
