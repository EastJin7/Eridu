using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Attank : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    public zerocontrol player;
    private Animator anim;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindObjectOfType<zerocontrol>();
        anim = GetComponent<Animator>();
        Button atk = GetComponent<Button>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //點擊事件
        if (player.grounded)
        {
            player.Atk();
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //    //點擊事件
        //    if (player.grounded)
        //    {
        //        player.Atk();
        //    }
    }
}