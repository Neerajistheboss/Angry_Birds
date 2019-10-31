using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
   // public float timeDelay;
    public float fadeOutTime;
   // public float fadeInTime;
    private Image fadePannel;
    private Color currentColor = Color.black;
    // Start is called before the first frame update
    void Start()
    {
        currentColor.a = 0;
        fadePannel = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");

       // Time.timeScale = 1f;
       // if (fadeOutTime-Time.timeSinceLevelLoad < 0)
        
            if (Time.timeSinceLevelLoad > 2.5f)
            {
                gameObject.SetActive(true);
                Debug.Log(Time.timeSinceLevelLoad);
              float alphaChange = Time.deltaTime*2.5f / fadeOutTime;
            currentColor.a += alphaChange;
            fadePannel.color = currentColor;
            }
        
        //else
        //{ gameObject.SetActive(false); }
    }
}
