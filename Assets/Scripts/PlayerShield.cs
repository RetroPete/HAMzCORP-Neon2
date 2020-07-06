using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
	public GameObject player;
	public GameObject shield;
	
	private CircleCollider2D shieldOn;
	
	public Animator anim;
	
    // Start is called before the first frame update
    void Start()
    {
		shieldOn = GetComponent<CircleCollider2D>();
		
		shieldOn.enabled = false;
		
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {	
		if (Input.GetKeyDown(KeyCode.E))
        {
			shieldOn.enabled = true;
			anim.Play("player_shield_active");
        }
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.E))
		{
			shieldOn.enabled = false;
			anim.Play("player_shield_idle");
		}
		if (Input.GetKeyUp(KeyCode.E))
		{
			shieldOn.enabled = false;
			anim.Play("player_shield_idle");
        }
    }
}
