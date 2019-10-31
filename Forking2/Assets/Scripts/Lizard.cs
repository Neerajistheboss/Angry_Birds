using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
{
    Animator lizardAnim;
    private Attacker attacker;
    // Start is called before the first frame update
    void Start()
    {
        lizardAnim = gameObject.GetComponent<Animator>();
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

       
            lizardAnim.SetBool("isAttacking", true);
            attacker.Attack(collision.gameObject);
       

    }
}
