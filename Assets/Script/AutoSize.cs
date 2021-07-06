using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoSize : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {

        CanvasScaler canvasScaler = GetComponent<CanvasScaler>();

        float screenWidthScale = Screen.width / canvasScaler.referenceResolution.x;
        float screenHeightScale = Screen.height / canvasScaler.referenceResolution.y;

        canvasScaler.matchWidthOrHeight = screenWidthScale > screenHeightScale ? 1 : 0;
    }
    // Update is called once per frame
    void Update () {
	
	}
}
