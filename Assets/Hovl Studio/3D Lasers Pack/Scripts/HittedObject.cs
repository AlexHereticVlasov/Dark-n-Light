using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HittedObject : MonoBehaviour 
{
    public float startHealth = 100;
    private float health;
    public Image healthBar;
	
	private void Start () 
    {
        health = startHealth;
	}

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
