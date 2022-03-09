using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBG : MonoBehaviour
{
    
    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public float duration = 3.0F;
    // Start is called before the first frame update
   
    
    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        GetComponent<Image>().color = Color.Lerp(color1, color2, t);
    }
    
}
