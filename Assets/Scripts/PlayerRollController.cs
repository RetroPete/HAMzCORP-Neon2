using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerRollController : MonoBehaviour
{
	public float rollSpeed;
	
	public GameObject player;
	
	private Animator anim;
	
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<PlayerEnergy>();
		
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		
		if (Input.GetKeyDown(KeyCode.Q))
		{
			StartCoroutine(RollUp());
		}
		
		if (Input.GetKeyDown(KeyCode.E))
		{
			StartCoroutine(RollDown());
		}
    }
	
	IEnumerator RollUp()
	{
		yield return new WaitForSeconds(.2f);
		
		transform.Translate(new Vector2(0, 1) * rollSpeed);
		
		player.GetComponent<PlayerEnergy>().TakeEnergy(100);
		
		anim.Play("player_roll_up"); 
	}
	
	IEnumerator RollDown()
	{
		yield return new WaitForSeconds(.2f);
		
		transform.Translate(new Vector2(0, -1) * rollSpeed);
		
		player.GetComponent<PlayerEnergy>().TakeEnergy(100);
		
		anim.Play("player_roll_down");
	}
}