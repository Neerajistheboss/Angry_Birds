using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    private Vector3 slingShotMiddleVector;
    [HideInInspector]public SlingShotState slingShotState;
    public Transform leftSlingShotOrigin, rightSlingShotOrigin;
    public LineRenderer slingShotLineRenderer1, slingShotLineRenderer2,trajectoryLineRenderer;
    [HideInInspector]public GameObject birdToThrow;
    public Transform birdWaitPosition;
    public float throwSpeed;
    [HideInInspector]public float timeSinceThrown;
    public delegate void BirdThrown();
    public event BirdThrown birdThrown;
    private void Awake()
    {
        slingShotLineRenderer1.sortingLayerName = "ForeGround";
        slingShotLineRenderer2.sortingLayerName = "ForeGround";
        trajectoryLineRenderer.sortingLayerName = "ForeGround";

        slingShotState = SlingShotState.IDLE;
        slingShotLineRenderer1.SetPosition(0,leftSlingShotOrigin.position);
        slingShotLineRenderer1.SetPosition(1,birdWaitPosition.position);
        slingShotLineRenderer2.SetPosition(0,rightSlingShotOrigin.position);
        slingShotLineRenderer2.SetPosition(1,birdWaitPosition.position);
        Vector3 middlePoint = (leftSlingShotOrigin.position + rightSlingShotOrigin.position) / 2;
        middlePoint.z = 0f;
        slingShotMiddleVector = middlePoint;

    }

    private void InitialiseBird()
    {
        birdToThrow.transform.position = birdWaitPosition.position;
        slingShotState = SlingShotState.IDLE;
        SetSlingShotLineRenderer(true);
    }

    void SetSlingShotLineRenderer(bool active)
    {
        slingShotLineRenderer1.enabled = active;
        slingShotLineRenderer2.enabled = active;

    }

    void DisplaySlingShotLineRenderers()
    {
        slingShotLineRenderer1.SetPosition(1,birdToThrow.transform.position);
        slingShotLineRenderer2.SetPosition(1, birdToThrow.transform.position);
    }

    void SetTrajectoryLineRendererActive(bool active)
    {
        trajectoryLineRenderer.enabled = active;
    }

    void DisplayTrajectoryLineRenderer(float distance)
    {
        SetTrajectoryLineRendererActive(true);
        Vector3 v2 = slingShotMiddleVector-birdToThrow.transform.position;
        int segmentCount = 15;
        Vector2[] segments = new Vector2[segmentCount];
        segments[0] = birdToThrow.transform.position;
        Vector2 segVelocity = new Vector2(v2.x,v2.y)*throwSpeed*distance;
        for (int i = 1; i < segmentCount; i++)
        {
            float time = i * Time.fixedDeltaTime * 5f;
            segments[i] = segments[0] + segVelocity * time + 0.5f * Physics2D.gravity * Mathf.Pow(time,2);
        }
        
        trajectoryLineRenderer.SetVertexCount(segmentCount);
        for (int i = 0; i < segmentCount; i++)
        { trajectoryLineRenderer.SetPosition(i, segments[i]); }


    }


    private void ThrowBird(float distance)
    {
        Vector3 velocity = slingShotMiddleVector - birdToThrow.transform.position;
        birdToThrow.GetComponent<Bird>().OnThrow();
        birdToThrow.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x,velocity.y)*throwSpeed*distance;
        if (birdThrown!=null)
        {
            birdThrown();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (slingShotState)
        {
            case SlingShotState.IDLE:
                InitialiseBird();
                DisplaySlingShotLineRenderers();
                if (Input.GetMouseButton(0))
                {
                    Vector3 location = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    if (birdToThrow.GetComponent<CircleCollider2D>()==Physics2D.OverlapPoint(location))
                    {
                        slingShotState = SlingShotState.USER_PULLING;
                    }
                }
                break;

            case SlingShotState.USER_PULLING:
                DisplaySlingShotLineRenderers();
                if (Input.GetMouseButton(0))
                {
                    Vector3 location = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    location.z = 0f;

                    if (Vector3.Distance(location, slingShotMiddleVector) > 1.5f)
                    {
                        var maxPosition = (location - slingShotMiddleVector).normalized * 1.5f + slingShotMiddleVector;
                        birdToThrow.transform.position = maxPosition;
                    }
                    else
                    { birdToThrow.transform.position = location; }

                    var distance = Vector3.Distance(slingShotMiddleVector, birdToThrow.transform.position);
                    DisplayTrajectoryLineRenderer(distance);


                }

                else
                {
                    SetTrajectoryLineRendererActive(true);
                    timeSinceThrown = Time.time;
                    float distance = Vector3.Distance(slingShotMiddleVector,birdToThrow.transform.position);
                    if (distance > 1)
                    {
                        SetSlingShotLineRenderer(false);
                        slingShotState = SlingShotState.BIRD_FLYING;
                        ThrowBird(distance);
                    }
                    else
                    {
                        birdToThrow.transform.positionTo(distance/10,birdWaitPosition.position);
                        InitialiseBird();
                    }
                }
                break;
        }
    }
}
