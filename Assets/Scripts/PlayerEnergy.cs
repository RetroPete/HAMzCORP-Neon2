using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{
	public int maxEnergy = 1000;
	public int currentEnergy;
	public EnergyBar energyBar;
	
	private LevelManager theLevelManager;
	
    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = maxEnergy;
		
		energyBar.SetMaxEnergy(maxEnergy);
		
		theLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.D))
		{
			TakeEnergy(1);
		}
    }
	
	public void GiveEnergy(int regen)
	{
		currentEnergy += regen;
		
		energyBar.SetEnergy(currentEnergy);
		
		if (currentEnergy > maxEnergy)
			currentEnergy = maxEnergy;
	}
	
	public void TakeEnergy(int deplete)
	{
		currentEnergy -= deplete;
		
		energyBar.SetEnergy(currentEnergy);
		
		if (currentEnergy <= 0)
		{
			currentEnergy = 0;
			theLevelManager.Die();
		}	
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Beam")
		{
			GiveEnergy(75);
		}
	}
}
