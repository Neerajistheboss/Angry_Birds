using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour
{
    Animator foxAnim;
    private Attacker attacker;
    // Start is called before the first frame update
    void Start()
    {
        foxAnim = gameObject.GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<Defender>())
        {
            return;
        }

        if (collision.GetComponent<stone>())
        {
            foxAnim.SetTrigger("jump");
        }
        else
        {
            foxAnim.SetBool("isAttacking",true);
            attacker.Attack(collision.gameObject);
        }
       
    }
}
