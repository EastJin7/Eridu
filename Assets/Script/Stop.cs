using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Stop : MonoBehaviour, IPointerClickHandler
{
    //public LoadScene loadscene;

    void Start () {
        Button stop = GetComponent<Button>();
        //loadscene = GameObject.FindObjectOfType<LoadScene>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnPointerClick(PointerEventData eventData)
    {
        //點擊事件
        //loadscene.LoadLevel();
        GameState.gamepause = true;
    }
}
