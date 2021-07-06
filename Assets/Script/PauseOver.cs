using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PauseOver : MonoBehaviour, IPointerClickHandler
{

	// Use this for initialization
	void Start () {
        Button restart = GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        //點擊事件
        GameState.gamepause = false;
    }
}
