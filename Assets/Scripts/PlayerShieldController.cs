using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerShieldController : MonoBehaviour
{
	public Animator anim;
	
	public GameObject player;
	
	public float timer = 0;
	public float waitingTime = 2.2f;
	
	//public GameObject player;
	//public GameObject shield;
	
	//public Animator anim;
	
	//private CircleCollider2D shieldOn;
	
	
	// Start is called before the first frame update
    void Start()
	{
		GetComponent<CircleCollider2D>().enabled = false;
		
		player.GetComponent<PlayerEnergy>();
		
		//shieldOn = GetComponent<CircleCollider2D>();
		
		//shieldOn.enabled = false;
		
        //anim = GetComponent<Animator>();
	}

    // Update is called once per frame
	//void Update()
    //{	
		//if (Input.GetKey(KeyCode.Keypad5))
        //{
		//	shieldOn.enabled = true;
		//	anim.Play("player_shield_active");
        //}
		//if (Input.GetKeyUp(KeyCode.Keypad5))
		//{
		//	shieldOn.enabled = false;
		//	anim.Play("player_shield_idle");	
        //}
		//if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Keypad5) && Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Keypad5))
		//{
		//	shieldOn.enabled = false;
		//	anim.Play("player_shield_idle");
		//}
    //}
	
    public void shieldy()
    {
		timer += Time.deltaTime;
		
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
			if(timer > waitingTime)
			{
			  timer = 0;
			  StartCoroutine(ShieldOn());
			}
        }
		
		//if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.Keypad5) && Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKey(KeyCode.D))
		//{
		//	GetComponent<CircleCollider2D>().enabled = false;
		//	anim.Play("player_shield_idle");
		//}
    }
	
	IEnumerator ShieldOn()
	{
		yield return new WaitForSeconds(.1f);
		
		player.GetComponent<PlayerEnergy>().TakeEnergy(50);
		
		GetComponent<CircleCollider2D>().enabled = true;
		
		anim.Play("player_shield_active");
		
		yield return new WaitForSeconds(2f);
		
		GetComponent<CircleCollider2D>().enabled = false;
		
		anim.Play("player_shield_idle");
		
		yield return new WaitForSeconds(.1f);
	}
}
