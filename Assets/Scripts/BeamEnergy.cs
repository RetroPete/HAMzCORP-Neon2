using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeamEnergy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
			SceneManager.LoadScene("Level_1");
		}
	}
	
	void Destroy()
	{
		Destroy(GameObject.Find("beam_blue"));
		Destroy(GameObject.Find("beam_green"));
		Destroy(GameObject.Find("beam_purple"));
		Destroy(GameObject.Find("beam_red"));
	}		
}
