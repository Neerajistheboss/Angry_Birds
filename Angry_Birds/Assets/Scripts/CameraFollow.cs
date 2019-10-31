using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class NewBehaviourScript : MonoBehaviour
public class CameraFollow : MonoBehaviour
{
   [HideInInspector] public Vector3 startingPosition;

    public float minCameraX = 0f;
    public float maxCameraX = 14f;
   [HideInInspector] public bool isFollowing;
    [HideInInspector] public Transform birdToFollow;
    // Start is called before the first frame update
    void Awake()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            if (birdToFollow != null)
            {
                var birdPostion = birdToFollow.position;
                float x = Mathf.Clamp(birdPostion.x, minCameraX, maxCameraX);
                transform.position = new Vector3(x, startingPosition.y, startingPosition.z);
            }

            else
            {
                isFollowing = false;
                transform.Translate(Vector3.Slerp(transform.position,startingPosition,2f));
            }
        }
    }
}
