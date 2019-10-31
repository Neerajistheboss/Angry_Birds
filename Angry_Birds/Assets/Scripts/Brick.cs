using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private AudioSource audioSource;
    private float health = 70f;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>())
        {
            float damage = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10f;
            if (damage > 10)
                audioSource.Play();

            health -= damage;

            if (health <= 0)
                Destroy(gameObject);
        }
    }
}
