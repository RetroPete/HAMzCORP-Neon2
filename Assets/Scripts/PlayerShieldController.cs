using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerShieldController : MonoBehaviour
{
	public float timer = 0;
	public float waitingTime = 2.2f;
	
	public GameObject player;
	
	private Animator anim;
	
	// Start is called before the first frame update
    void Start()
	{
		GetComponent<CircleCollider2D>().enabled = false;
		
		player.GetComponent<PlayerEnergy>();
		
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
	void Update()
    {	
		timer += Time.deltaTime;
		
        if (Input.GetKeyDown(KeyCode.Space))
        {
			if(timer > waitingTime)
			{
			  timer = 0;
			  StartCoroutine(ShieldOn());
			}
        }
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
