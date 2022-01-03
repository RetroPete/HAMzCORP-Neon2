﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeamController : MonoBehaviour
{
	public float speed;
	public float destroyTime;
	
	public GameObject beam;
	
	private Rigidbody2D rb;
	private Vector2 screenBounds;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
		
        rb.velocity = new Vector2(-speed, 0);
		
        screenBounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
		Destroy(GameObject.Find("drone_blue(Clone)"), destroyTime);
		
		Destroy(GameObject.Find("drone_green(Clone)"), destroyTime);
		
		Destroy(GameObject.Find("drone_purple(Clone)"), destroyTime);
		
		Destroy(GameObject.Find("drone_red(Clone)"), destroyTime);
    }
}
