
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public CameraFollow cameraFollow;
    int currentBirdIndex;
    public SlingShot slingShot;
   [HideInInspector] public static GameState gameState;

    private List<GameObject> bricks;
    private List<GameObject> birds;
    private List<GameObject> pigs;
    // Start is called before the first frame update
    void Awake()
    {
        gameState = GameState.START;
        slingShot.enabled = false;
        bricks = new List<GameObject>(GameObject.FindGameObjectsWithTag("Brick"));
        birds = new List<GameObject>(GameObject.FindGameObjectsWithTag("Bird"));
        pigs = new List<GameObject>(GameObject.FindGameObjectsWithTag("Pig"));
    }

    void OnEnable()
    {
        slingShot.birdThrown += SlingShotBirdThrown;
    }

    private void OnDisable()
    {
        slingShot.birdThrown -= SlingShotBirdThrown;
    }

    void AnimateBirdToSlingShot()
    {
        gameState = GameState.BIRD_MOVING_TO_SLINGSHOT;
        birds[currentBirdIndex].transform.positionTo(Vector2.Distance(birds[currentBirdIndex].transform.position/10,slingShot.birdWaitPosition.position)/10f,slingShot.birdWaitPosition.position).
            setOnCompleteHandler((x)=> {
                x.complete();
                x.destroy();
                gameState = GameState.PLAYING;
                slingShot.enabled = true;
                slingShot.birdToThrow = birds[currentBirdIndex];
            });
    }

    bool BricksBirdsPigsStoppedMoving()
    {
        foreach (var item in bricks.Union(birds).Union(pigs))
        {
            if (item != null && item.GetComponent<Rigidbody2D>().velocity.sqrMagnitude > GameVariables.minVelocity)
            {
                return false;
            }
        }

        return true;
    }

    private bool AllPigsAreDestroyed()
    {
        return pigs.All(x=>x==null);
    }

    private void AnimateCameraToStartPosition()
    {
        float duration = Vector2.Distance(Camera.main.transform.position, cameraFollow.startingPosition) / 10f;
        if (duration == 0.0f)
        {
            duration = 0.1f;
        }

        Camera.main.transform.positionTo(duration, cameraFollow.startingPosition).
            setOnCompleteHandler((x) => { cameraFollow.isFollowing = false;
                if (AllPigsAreDestroyed())
                {
                    gameState = GameState.WON;
                }
                else if (currentBirdIndex == birds.Count - 1)
                {
                    gameState = GameState.LOST;
                }
                else
                { slingShot.slingShotState = SlingShotState.IDLE;
                    currentBirdIndex++;
                    AnimateBirdToSlingShot();
                }

            });
    }

    private void SlingShotBirdThrown()
    {
        cameraFollow.birdToFollow = birds[currentBirdIndex].transform;
        cameraFollow.isFollowing=true;

    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.START:
                if (Input.GetMouseButtonUp(0))
                { AnimateBirdToSlingShot(); }
                break;

            case GameState.PLAYING:
                if (slingShot.slingShotState == SlingShotState.BIRD_FLYING && (BricksBirdsPigsStoppedMoving()||Time.time-slingShot.timeSinceThrown>5f))
                {
                    slingShot.enabled = false;
                    AnimateCameraToStartPosition();
                    gameState = GameState.BIRD_MOVING_TO_SLINGSHOT;
                }
                break;

            case GameState.WON:
                

            case GameState.LOST:
                { if (Input.GetMouseButtonDown(0))
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                break;
        }
    }
}
