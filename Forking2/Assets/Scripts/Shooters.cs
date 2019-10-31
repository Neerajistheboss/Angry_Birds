using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooters : MonoBehaviour
{
    public GameObject projectile;
    GameObject projectileParent;
    public GameObject gun;
    Animator animator;
    private spawner myLaneSpawner;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.FindObjectOfType<Animator>();

        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();


    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking",false);
        }
    }


    void SetMyLaneSpawner()
    {
        spawner[] spawnerArray = GameObject.FindObjectsOfType<spawner>();
        foreach (spawner spawnerr in spawnerArray)
        {
            if (spawnerr.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawnerr;
                return;
            }
        }

        Debug.LogError(name+"cant find spwaner in lane");
    }

    bool IsAttackerAheadInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        foreach (Transform attacker in myLaneSpawner.transform)
        {
            if (attacker.transform.position.x > transform.position.x&&attacker.transform.position.x<=9.5f)
            { return true; }
        }

        return false;//attacker behind the defender 
    }

    private void Fire()
    {
      GameObject newProjectile=  Instantiate(projectile) as GameObject ;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }

}
