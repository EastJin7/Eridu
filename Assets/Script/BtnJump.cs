using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class BtnJump : MonoBehaviour/*, IPointerDownHandler*/
{
    public zerocontrol player;
    private Animator anim;
    Button button;
    Image image;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindObjectOfType<zerocontrol>();
        //Button jump = GetComponent<Button>();
        button = transform.Find("Button").GetComponent<Button>();
        //image = transform.Find("Image").GetComponent<Image>();
        //EventTriggerListener.Get(image.gameObject).onDown = OnButtonDown;
        EventTriggerListener.Get(button.gameObject).onDown = OnButtonDown;
    }
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    //點擊事件
    //    if (player.grounded)
    //    {
    //        player.Jump();
    //    }
    //}
    private void OnButtonDown(GameObject go)
    {
        if (go == button.gameObject)
        {
            Debug.Log("DoSomeThings");
        }
    }
}