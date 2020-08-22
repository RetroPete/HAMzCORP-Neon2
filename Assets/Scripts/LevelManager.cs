using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	public float waitToRespawn;
	
	public int scoreCount;
	
	public bool respawnCoActive;
	
	public PlayerController player;
	
	public Text score;
	
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
	
	public IEnumerator RespawnCo()
	{
		player.gameObject.SetActive(false);
		
		yield return new WaitForSeconds(waitToRespawn);
		
		scoreCount = 0;
		score.text = "Score: " + scoreCount;
		
		player.gameObject.SetActive(true);
	}

	public void AddScore(int scoreToAdd)
	{
		scoreCount += scoreToAdd;
		score.text = "Score: " + scoreCount;
	}
}
