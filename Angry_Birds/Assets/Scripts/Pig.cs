using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    private AudioSource audioSource;
    public  float health = 150f;
    public Sprite spriteShownWhenHurt;
    private float changeSpriteHealth;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        changeSpriteHealth = health - 30f;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent <Rigidbody2D>()== null)
        {
            return;
        }
        if (collision.gameObject.tag == "Bird")
        {
            audioSource.Play();
            Destroy(gameObject,audioSource.clip.length);
        }
        else
        {
            float damage = collision.gameObject.GetComponent<Rigidbody2D>().velocity.sqrMagnitude*10f;
            if (damage >= 10)
            { audioSource.Play(); }

            health -= damage;
            if (health <= changeSpriteHealth)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteShownWhenHurt;
            }

            if (health <= 0f)
            { Destroy(gameObject,audioSource.clip.length); }
        }
    }
}
