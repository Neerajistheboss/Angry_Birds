using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{

    private float currentSpeed;
    private GameObject currentTarget;
    private StarDisplay starDisplay;
    private Animator anim;

    public int starCost = 100;

    private void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        anim = gameObject.GetComponent<Animator>();


        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
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


    private void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        if (!currentTarget)
        { anim.SetBool("isAttacking", false); }
        else
            anim.SetBool("isAttacking", true);
    }

    public void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }


    public void Attack(GameObject obj)
    {

        currentTarget = obj;

    }

}
