using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerShieldPurple : MonoBehaviour
{
	public float timer = 0;
	public float waitingTime = 2.2f;
	public int scoreValue;
	
	public GameObject player;
	
	private Animator anim;
	
	private LevelManager theLevelManager;
	
	// Start is called before the first frame update
    void Start()
	{
		GetComponent<CircleCollider2D>().enabled = false;
		
		player.GetComponent<PlayerEnergy>();
		
        anim = GetComponent<Animator>();
		
		theLevelManager = FindObjectOfType<LevelManager>();
	}

    // Update is called once per frame
	void Update()
    {	
		timer += Time.deltaTime;
		
		if (Input.GetKeyDown(KeyCode.J))
        {
			timer = 0;
        }
		
		else if (Input.GetKeyDown(KeyCode.K))
        {
			timer = 0;
        }
		
		else if (Input.GetKeyDown(KeyCode.L))
        {
			if(timer > waitingTime)
			{
			  timer = 0;
			  StartCoroutine(ShieldOnPurple());
			}
        }
    }
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Drone Purple" )
		{
			Destroy();
			
			theLevelManager.AddScore(scoreValue);
		}
		else if (col.gameObject.tag == "Drone")
		{
			theLevelManager.Die();
		}
	}
	
	void Destroy()
	{
		Destroy(GameObject.Find("purple_beam"));
	}	
	
	IEnumerator ShieldOnPurple()
	{
		yield return new WaitForSeconds(.1f);
		
		player.GetComponent<PlayerEnergy>().TakeEnergy(50);
		
		GetComponent<CircleCollider2D>().enabled = true;
		
		anim.Play("player_shield_purple");
		
		yield return new WaitForSeconds(2f);
		
		GetComponent<CircleCollider2D>().enabled = false;
		
		anim.Play("player_shield_idle");
		
		yield return new WaitForSeconds(.1f);
	}
}