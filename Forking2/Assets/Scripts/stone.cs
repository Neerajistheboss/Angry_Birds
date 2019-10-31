using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

       Lizard attacker = collision.gameObject.GetComponent<Lizard>();
        if (attacker)
            anim.SetBool("isAttacked", true);
        else anim.SetBool("isAttacked",false);
      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("isAttacked",false);
    }

   
}
