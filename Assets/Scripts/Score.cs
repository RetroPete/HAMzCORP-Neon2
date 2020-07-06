using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
	public int scoreValue;
	
	private LevelManager theLevelManager;
	
    // Start is called before the first frame update
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name == "Shield")
        {
            theLevelManager.AddScore(scoreValue);
        }
	}
}
