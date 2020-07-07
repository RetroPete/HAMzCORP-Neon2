using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerEnergy : MonoBehaviour
{
	public int maxEnergy = 1000;
	public int currentEnergy;
	
	public EnergyBar energyBar;
	
    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = maxEnergy;
		
		energyBar.SetMaxEnergy(maxEnergy);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad5))
		{
			TakeEnergy(1);
		}
		
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
			Die();
		}	
	}
	
	void Die()
	{
		SceneManager.LoadScene("Level_1");
	}
}
