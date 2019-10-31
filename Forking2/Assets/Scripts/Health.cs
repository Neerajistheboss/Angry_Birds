using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public float health;
    public  Image healthBar;
    private  float originalHealth;
    private void Start()
    {
        originalHealth = health;
        //healthBar = GetComponentInChildren<Image>();
    }
    public void DealDamage(float damage)
    {
        this.health -= damage;
        
        if (this.health <= 0)
        {
            DestroyObejct();
        }
    }

    private void Update()
    {
        healthBar.fillAmount = this.health / originalHealth;
    }

    public void  DestroyObejct()
    {
        Destroy(this.gameObject);
    }
        
    
}
