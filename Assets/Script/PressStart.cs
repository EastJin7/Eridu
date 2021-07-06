using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PressStart : MonoBehaviour {
    //private GUIText press;
    private Text press;
    private Color colorStart = Color.white;
    private Color colorEnd=Color.grey;
    private float duration = 1.2f;

    // Use this for initialization
    void Start () {
        //press = GetComponent<GUIText>();
        press = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        press.color=Color.Lerp(colorStart, colorEnd, lerp);
        //press.material.color = Color.Lerp(colorStart, colorEnd, lerp);
    }
}
