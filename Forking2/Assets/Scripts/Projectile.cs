using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed,damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right*speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        Health health = collision.gameObject.GetComponent<Health>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
