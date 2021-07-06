using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool moveRight;
    public bool isTouched = false;
    private zerocontrol player;
    float h = 0.5f;

// Use this for initialization
void Start()
    {
        Button move = GetComponent<Button>();
        player = GameObject.FindObjectOfType<zerocontrol>();
        if (moveRight == false) { h = -0.5f; }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //按下事件
        isTouched = true;

    }
    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    //點擊事件
    //    isTouched = true;
    //}

    public void OnPointerUp(PointerEventData eventData)
    {
        //按完事件
        isTouched = false;
    }
    void Update()
    {
        if (isTouched == true)
        {
            player.Move(h);
        }
        if (GameState.gamepause)
        {
            isTouched = false;
        }
    }
}