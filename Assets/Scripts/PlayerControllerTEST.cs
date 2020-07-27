using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerControllerTEST : MonoBehaviour
{
	private float horizontal = 0;
    private float vertical = 0;
	
	public float boostSpeed;
	public float autoMove;
	
	public GameObject player;
	public GameObject boostButton;
	
	
	private Rigidbody2D rb;
	
	private Animator anim;
	
	private LevelManager theLevelManager;
	
	// Start is called before the first frame update
    void Start()
    {
		player.GetComponent<PlayerEnergy>();
		
        rb = GetComponent<Rigidbody2D>();
		
		anim = GetComponent<Animator>();
		
		theLevelManager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(new Vector3(0, .5f, 0) * autoMove * Time.deltaTime);
		}
		
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(new Vector3(0, -.5f, 0) * autoMove * Time.deltaTime);
		}
		
		if (Input.GetKeyDown(KeyCode.D))
        {
			horizontal = 1;
        }
		
		if (Input.GetKeyUp(KeyCode.D))
		{
			horizontal = 0;
        }
		
		if (Input.GetKeyDown(KeyCode.Q))
		{
			StartCoroutine(RollUp());
		}
		
		if (Input.GetKeyDown(KeyCode.E))
		{
			StartCoroutine(RollDown());
		}
		
		
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

		anim.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
    }
	
	void FixedUpdate()
	{
		rb.velocity = new Vector2(autoMove + horizontal * boostSpeed, vertical);
	}
	
	IEnumerator RollUp()
	{
		yield return new WaitForSeconds(.2f);
		
		transform.Translate(new Vector3(0, 30, 0) * autoMove * Time.deltaTime);
		
		player.GetComponent<PlayerEnergy>().TakeEnergy(100);
		
		anim.Play("player_roll_up"); 
	}
	
	IEnumerator RollDown()
	{
		yield return new WaitForSeconds(.2f);
		
		transform.Translate(new Vector3(0, -30, 0) * autoMove * Time.deltaTime);
		
		player.GetComponent<PlayerEnergy>().TakeEnergy(100);
		
		anim.Play("player_roll_down");
	}
}
