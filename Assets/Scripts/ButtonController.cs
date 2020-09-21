using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
	public GameObject player;
	
    // Start is called before the first frame update
    void Start()
	
	{
         //player = GameObject.FindWithTag ("Player");
		 
		 player.GetComponent<PlayerController>();
		 
		 player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(new Vector3(0, .5f, 0) * player.GetComponent<PlayerController>().autoMove * Time.deltaTime);
		}
		
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(new Vector3(0, -.5f, 0) * player.GetComponent<PlayerController>().autoMove * Time.deltaTime);
		}
		
		if (Input.GetKeyDown(KeyCode.D))
        {
			player.GetComponent<PlayerController>().horizontal = 1;
        }
		
		if (Input.GetKeyUp(KeyCode.D))
		{
			player.GetComponent<PlayerController>().horizontal = 0;
        }
		
		if (Input.GetKeyDown(KeyCode.Q))
		{
			//player.GetComponent<PlayerController>().StartCoroutine(RollUp());
		}
		
		if (Input.GetKeyDown(KeyCode.E))
		{
			//player.GetComponent<PlayerController>().StartCoroutine(RollDown());
		}
    }
	
	public void Idle()
	{
		player.GetComponent<PlayerController>().vertical = 0;
		player.GetComponent<Animator>().SetInteger("Idle", 0);
		//transform.Translate(new Vector3(0, 0, 0) * player.GetComponent<PlayerController>().autoMove * Time.deltaTime);
		
	}
	
	public void MoveUp()
	{
		player.GetComponent<PlayerController>().vertical = 5;
		player.GetComponent<Animator>().SetInteger("Up", 1);
		//transform.Translate(new Vector3(0, 5, 0) * player.GetComponent<PlayerController>().autoMove * Time.deltaTime);
	}
		
	public void MoveDown()
	{
		player.GetComponent<PlayerController>().vertical = -5;
		player.GetComponent<Animator>().SetInteger("Down", -1);
		//transform.Translate(new Vector3(0, -5, 0) * player.GetComponent<PlayerController>().autoMove * Time.deltaTime);
	}
		
	public void BoostOn()
    {
		player.GetComponent<PlayerController>().horizontal = 1;
    }
		
	public void BoostOff()
	{
		player.GetComponent<PlayerController>().horizontal = 0;
    }
	
	public void MoveUpUp()
	{
		//player.GetComponent<PlayerController>().StartCoroutine(RollUp());
    }
	
	public void MoveDownDown()
	{
		//player.GetComponent<PlayerController>().StartCoroutine(RollDown());
    }
}
