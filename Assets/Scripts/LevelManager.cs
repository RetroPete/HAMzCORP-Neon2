using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	public int scoreCount;
	public PlayerController player;
	public Text score;
	public Text finalScore;
	public GameObject gameOverUI;
	
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
		
		if(PlayerPrefs.HasKey("ScoreCount"))
		{
			scoreCount = PlayerPrefs.GetInt("ScoreCount");
		}

		score.text = "Score: " + scoreCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void Die()
	{
		gameOverUI.SetActive(true);
		
		player.gameObject.SetActive(false);
	}

	public void AddScore(int scoreToAdd)
	{
		scoreCount += scoreToAdd;
		score.text = "Score: " + scoreCount;
		finalScore.text = "Beams Destroyed: " + scoreCount;
	}
}
