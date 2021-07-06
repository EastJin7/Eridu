using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CloseStory : MonoBehaviour {
    public Toggle toggle;
    // Use this for initialization
    void Awake () {
        toggle.isOn = GameState.drama;
        toggle.onValueChanged.AddListener(TrunStory);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void TrunStory(bool b)
    {
        GameState.drama = b;
    }
}
