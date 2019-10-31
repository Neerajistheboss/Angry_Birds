using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpwaner : MonoBehaviour
{
    private GameObject defenderParent;
    private StarDisplay starDisplay;
    // Start is called before the first frame update
    void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();

        defenderParent = GameObject.Find("DefenderParent");
        if (!defenderParent)
        {
            defenderParent = new GameObject("DefenderParent");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPointOfMouseClick();
        Vector2 pos = SnapToGrid(rawPos);
        GameObject defender = Button.selectedDefender;


        int defenderCost = defender.GetComponent<Defender>().starCost;
        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        { SpawnDefender(defender, pos); }
        else
        { Debug.Log("Insufficient stars"); }

    }

    void SpawnDefender(GameObject defender,Vector2 pos)
    {
        Quaternion rot = Quaternion.identity;
        GameObject newDefender = Instantiate(defender, pos, rot) as GameObject;
        newDefender.transform.parent = defenderParent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float snapX = Mathf.RoundToInt(rawWorldPos.x);
        float snapY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(snapX,snapY);
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;
        Vector3 weirdTriplet = new Vector3(mouseX,mouseY,distanceFromCamera);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(weirdTriplet);
        return worldPos;
            
    }

}
