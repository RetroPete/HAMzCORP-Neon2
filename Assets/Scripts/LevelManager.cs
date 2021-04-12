using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	public int scoreCount;
	public PlayerController playerController;
	public BeamSpawn beamSpawn;
	public Text score;
	public Text finalScore;
	public GameObject gameOverUI;
	
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
		
		beamSpawn = FindObjectOfType<BeamSpawn>();
		
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
		playerController.Die();
		
		StartCoroutine(Death());	
	}

	public void AddScore(int scoreToAdd)
	{
		scoreCount += scoreToAdd;
		score.text = "Score: " + scoreCount;
		finalScore.text = "Beams Destroyed: " + scoreCount;
	}
	
	IEnumerator Death()
	{
		yield return new WaitForSeconds(1.5f);
		
		beamSpawn.gameObject.SetActive(false);
		
		playerController.gameObject.SetActive(false);
		
		yield return new WaitForSeconds(.2f);
		
		gameOverUI.SetActive(true);
	}
}
