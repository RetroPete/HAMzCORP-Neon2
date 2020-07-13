using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldController : MonoBehaviour
{
	public Animator anim;
	
	public GameObject player;
	
	public float timer = 0;
	public float waitingTime = 2.2f;
	
	
	// Start is called before the first frame update
    private void Start()
	{
		GetComponent<CircleCollider2D>().enabled = false;
		
		player.GetComponent<PlayerEnergy>();
	}

    // Update is called once per frame
    void Update()
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
