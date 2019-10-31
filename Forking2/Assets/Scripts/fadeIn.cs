using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeIn : MonoBehaviour
{
   
    public float fadeInTime;
    private Image fadePannel;
    private Color currentColor = Color.black;
    // Start is called before the first frame update
    void Start()
    {
        currentColor.a = 1;
        fadePannel = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update from fadeIn");

        if (Time.timeSinceLevelLoad <fadeInTime)
        {
            Debug.Log(Time.timeSinceLevelLoad);
            float alphaChange = Time.deltaTime / fadeInTime;
            currentColor.a -= alphaChange;
            fadePannel.color = currentColor; 
        }
        else
        { gameObject.SetActive(false); }
    }
}
