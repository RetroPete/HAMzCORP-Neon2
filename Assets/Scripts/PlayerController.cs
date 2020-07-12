using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	float horizontal;
    float vertical;
	
	public float boostSpeed;
	public float autoMove;
	
	public GameObject player;
	
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
		if (Input.GetAxisRaw("Horizontal") >=0)
		{
			horizontal = Input.GetAxisRaw("Horizontal");
			vertical = Input.GetAxisRaw("Vertical");
		}
		
		if (Input.GetKeyDown(KeyCode.Q))
		{
			StartCoroutine(RollUp());
			//transform.Translate(new Vector3(0, 10, 0) * autoMove * Time.deltaTime);
			//player.GetComponent<PlayerEnergy>().TakeEnergy(100);
			//anim.Play("player_roll_up"); 
		}
		
		if (Input.GetKeyDown(KeyCode.E))
		{
			StartCoroutine(RollDown());
			//transform.Translate(new Vector3(0, -10, 0) * autoMove * Time.deltaTime);
			//player.GetComponent<PlayerEnergy>().TakeEnergy(100);
			//anim.Play("player_roll_down"); 
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
		
		transform.Translate(new Vector3(0, 10, 0) * autoMove * Time.deltaTime);
		
		player.GetComponent<PlayerEnergy>().TakeEnergy(100);
		
		anim.Play("player_roll_up"); 
	}
	
	IEnumerator RollDown()
	{
		yield return new WaitForSeconds(.2f);
		
		transform.Translate(new Vector3(0, -10, 0) * autoMove * Time.deltaTime);
		
		player.GetComponent<PlayerEnergy>().TakeEnergy(100);
		
		anim.Play("player_roll_down");
	}
}