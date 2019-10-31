using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] attackerPrefabArray;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject thisAttacker in attackerPrefabArray)
        {
            if (isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
    }


    bool isTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();
        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnPerSeconds = 1 / meanSpawnDelay;
        if ( (Time.deltaTime > meanSpawnDelay))
        {
            Debug.Log("Spawn rate capped by frame rate");
        }

        float threshold = spawnPerSeconds * Time.deltaTime/5f;
        if (Random.value < threshold)
        { return true; }
        else return false;
    }

    void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position; 
    }

}
