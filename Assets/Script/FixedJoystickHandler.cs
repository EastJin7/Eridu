using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FixedJoystickHandler : ScrollRect , IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    protected float radius; // 搖桿最大半徑

    private RectTransform selfTransform;//本物件的Transform
    private bool isTouched = false;//是否正在觸摸虛擬搖桿
    private Vector2 defaultPosition; //虛擬搖桿的默認位置
    private Vector2 movedAxis;//虛擬搖桿的移動方向
    public Vector2 MovedAxis
    {
        get
        {
            if (movedAxis.magnitude < radius)
                return movedAxis.normalized / radius;
            return movedAxis.normalized;
        }
    }
    public delegate void TouchBegin(Vector2 vec);//宣告觸碰開始
    public event TouchBegin OnJoyStickTouchBegin;//註冊觸碰開始事件
    public delegate void TouchMove(Vector2 vec);//宣告觸碰過程的移動事件
    public event TouchMove OnJoyStickTouchMove;//註冊觸碰過程事件
    public delegate void TouchEnd();//宣告觸碰結束事件
    public event TouchEnd OnJoyStickTouchEnd;//註冊觸碰結束事件
    public float ResetSpeed = 5.0f; //虛擬搖桿回歸速度

    protected override void Start()
    {

        this.radius = (transform as RectTransform).sizeDelta.x * 0.5f;//規範與錨定點的相對距離
        selfTransform = this.GetComponent<RectTransform>();
        defaultPosition = selfTransform.anchoredPosition;//       初始化虛擬搖桿方向
    }
        public void OnPointerDown(PointerEventData eventData)//點下時
    {
        isTouched = true;
        movedAxis = GetMoveAxis(eventData);
        if (this.OnJoyStickTouchBegin != null)
            this.OnJoyStickTouchBegin(MovedAxis);
    }
    public void OnPointerUp(PointerEventData eventData)//點完時
    {
        isTouched = false;
        selfTransform.anchoredPosition = defaultPosition;//回到默認位置
        movedAxis = Vector2.zero;//歸零
        if (this.OnJoyStickTouchEnd != null)
            this.OnJoyStickTouchEnd();
    }
    public override void OnDrag(PointerEventData eventData)//拖曳時
    {
        base.OnDrag(eventData);
//        base.content.anchoredPosition = Vector3.ClampMagnitude(base.content.anchoredPosition, this.radius);//規範拖曳的座標與原點的位置
        movedAxis = GetMoveAxis(eventData);
        if (this.OnJoyStickTouchMove != null)
            this.OnJoyStickTouchMove(MovedAxis);
    }

    void Update()
    {
        //當虛擬搖桿移動到最大半徑時搖桿無法拖動
        //為了確保被控制物體可以繼續移動
        //在這里手動觸發OnJoyStickTouchMove事件
        if (isTouched && movedAxis.magnitude >= radius)
        {
            if (this.OnJoyStickTouchMove != null)
                this.OnJoyStickTouchMove(MovedAxis);
        }
        
        if (selfTransform.anchoredPosition.magnitude > defaultPosition.magnitude)
            selfTransform.anchoredPosition -= MovedAxis * Time.deltaTime * ResetSpeed;//鬆開後虛擬搖桿回到默認位置
    }
    private Vector2 GetMoveAxis(PointerEventData eventData)//回傳搖桿偏移量
    {
        //獲取手指位置的世界坐標
        Vector3 worldPosition;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(selfTransform,
                 eventData.position, eventData.pressEventCamera, out worldPosition))
            selfTransform.position = worldPosition;
        //獲取搖桿的偏移量
        Vector2 moveAxis = selfTransform.anchoredPosition - defaultPosition;
        //搖桿偏移量限制
        if (moveAxis.magnitude >= radius)
        {
            moveAxis = moveAxis.normalized * radius;
            selfTransform.anchoredPosition = moveAxis;
        }
        return moveAxis;
    }
}


