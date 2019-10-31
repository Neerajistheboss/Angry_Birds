using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhino : MonoBehaviour
{
    Animator rhinodAnim;
    private Defender defender;
    // Start is called before the first frame update
    void Start()
    {
        rhinodAnim = gameObject.GetComponent<Animator>();
        defender = GetComponent<Defender>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.GetComponent<Attacker>())
        {
            return;
        }


        rhinodAnim.SetBool("isAttacking", true);
        defender.Attack(collision.gameObject);


    }
}
