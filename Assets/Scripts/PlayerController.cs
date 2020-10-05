using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float horizontal;
    public float vertical;
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
		
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

		anim.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
		
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
    }
	
	void FixedUpdate()
	{
		rb.velocity = new Vector2(autoMove + horizontal * boostSpeed, vertical);
	}
}
