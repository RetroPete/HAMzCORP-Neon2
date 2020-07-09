using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSpawn : MonoBehaviour
{
	public float respawnTime = 3f;
	
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
			beams[i].transform.position = new Vector3(15 + player.transform.position.x + offset.x, Random.Range(-1.5f,1.5f), offset.z);
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
