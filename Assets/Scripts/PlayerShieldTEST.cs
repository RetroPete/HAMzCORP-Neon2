using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShieldTEST : MonoBehaviour
{
	public GameObject player;
	public GameObject shield;
	
	public Animator anim;
	
	private CircleCollider2D shieldOn;
	
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
		if (Input.GetKey(KeyCode.Keypad5))
        {
			shieldOn.enabled = true;
			anim.Play("player_shield_active");
        }
		if (Input.GetKeyUp(KeyCode.Keypad5))
		{
			shieldOn.enabled = false;
			anim.Play("player_shield_idle");	
        }
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Keypad5) && Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Keypad5))
		{
			shieldOn.enabled = false;
			anim.Play("player_shield_idle");
		}
    }
	
	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log(col.tag);
	}
}