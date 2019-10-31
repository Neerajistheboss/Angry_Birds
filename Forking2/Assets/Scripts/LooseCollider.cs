using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseCollider : MonoBehaviour
{
    LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelManager.LoadLevel("Loose");
    }
}
