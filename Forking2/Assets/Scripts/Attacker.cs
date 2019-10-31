using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour 
{
    
    private float currentSpeed;
    private GameObject currentTarget;
    private Animator anim;
    [Tooltip("Average number of seconds between appearances")]public float seenEverySeconds;
    // Start is called before the first frame update
    void Start()
    {
       



        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left*currentSpeed*Time.deltaTime);
        if (!currentTarget)
        { anim.SetBool("isAttacking", false); }
        else
            anim.SetBool("isAttacking",true);


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void setSpeed(float speed)
    { currentSpeed = speed; }

    public void StrikeCurrentTarget(float damage)
    {
        
        if (currentTarget)
        {
            Health targetHealth = currentTarget.GetComponent<Health>();
            if (targetHealth)
            {
                targetHealth.DealDamage(damage);
            }
        }
    }
    public void Attack(GameObject obj)
    {
       
        currentTarget = obj;
        
    }
}
