using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeamEnergy : MonoBehaviour
{
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
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Shield")
		{
			Destroy();
		}
		else if (col.gameObject.tag == "Player")
		{
			theLevelManager.Die();
		}
	}
	
	void Destroy()
	{
		Destroy(GameObject.Find("blue_beam"));
		
		Destroy(GameObject.Find("green_beam"));
		
		Destroy(GameObject.Find("purple_beam"));
		
		Destroy(GameObject.Find("red_beam"));
	}		
}
