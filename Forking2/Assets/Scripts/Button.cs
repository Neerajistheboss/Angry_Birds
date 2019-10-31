using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject defenderPrefab;
    private Button[] buttonArray;
    public static GameObject selectedDefender;
    // Start is called before the first frame update
    void Start()
    {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponentInChildren<SpriteRenderer>().color = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponentInChildren<SpriteRenderer>().color = Color.black;
        }
        GetComponentInChildren<SpriteRenderer>().color = Color.white;

        selectedDefender = defenderPrefab;
    }
}
