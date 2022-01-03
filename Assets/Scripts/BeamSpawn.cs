﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeamSpawn : MonoBehaviour
{
	public float respawnTime;
	
	public GameObject player;
	public GameObject[] beamPrefabs;
	
	private GameObject[] beams;
	private Vector3 offset;
	
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        StartCoroutine(beamWave());
    }
	
	// Update is called once per frame
    void Update()
    {	
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
		
        pos.y = Mathf.Clamp01(pos.y);
		
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    private void spawnBeam()
    {
        beams = new GameObject[beamPrefabs.Length];
		
        int i = Random.Range (0, beamPrefabs.Length);
        {
			beams[i] = Instantiate(beamPrefabs[i]) as GameObject;
			
			beams[i].transform.position = new Vector3(50 + player.transform.position.x + offset.x, Random.Range(-5,5), offset.z);
		}
    }
	
	IEnumerator beamWave()
	{
        while(true)
		{
            yield return new WaitForSeconds(respawnTime);
			
            spawnBeam();
        }
    }
}
