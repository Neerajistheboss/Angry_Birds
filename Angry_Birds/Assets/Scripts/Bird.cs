using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public BirdState birdState { set; get; }

    private TrailRenderer lineRenderer;
    private Rigidbody2D birdRb;
    private CircleCollider2D birdCollider;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        InitaliseVariables();
    }

    void InitaliseVariables()
    {
            lineRenderer = GetComponent<TrailRenderer>();
            birdRb = GetComponent<Rigidbody2D>();
            birdCollider = GetComponent<CircleCollider2D>();
            audioSource = GetComponent<AudioSource>();
        lineRenderer.enabled = false;
        lineRenderer.sortingLayerName = "ForeGround";

        birdRb.isKinematic = true;
        birdCollider.radius = GameVariables.birdColliderRadiusBig;
        birdState = BirdState.BEFORE_THROWN;
    }

    public void OnThrow()
    {
        audioSource.Play();
        lineRenderer.enabled = true;
        birdRb.isKinematic = false;
        birdCollider.radius = GameVariables.birdColliderRadiusNormal;
        birdState = BirdState.THROWN;
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject  );

    }

    private void FixedUpdate()
    {
        if (birdState == BirdState.THROWN && birdRb.velocity.sqrMagnitude <= GameVariables.minVelocity)
        {
            StartCoroutine(DestroyAfterDelay(1f ));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
