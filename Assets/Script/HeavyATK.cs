using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HeavyATK : MonoBehaviour, IPointerDownHandler
{
    public zerocontrol player;

    void Start()
    {
        player = GameObject.FindObjectOfType<zerocontrol>();
        Button HAtk = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //點擊事件
        if (player.grounded)
        {
            player.HAtkPress();
        }
    }
    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    if(player.grounded)
    //    {
    //        player.HAtkPress();
    //    }
    //}
}
