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
	
	private LevelManager theLevelManager;
	
	private Animator anim;
	
	private Rigidbody2D rb;
	
	// Start is called before the first frame update
    void Start()
    {
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
}
