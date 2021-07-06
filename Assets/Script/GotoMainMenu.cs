using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GotoMainMenu : MonoBehaviour, IPointerClickHandler
{
    private LoadScene loadscene;

    // Use this for initialization
    void Start () {
        Button gotomain = GetComponent<Button>();
        loadscene = GameObject.FindObjectOfType<LoadScene>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //點擊事件
        GameState.gamepause = false;//取消暫停狀態
        GameState.gameover = true;//啟動Gameover後的save
        UIManager.Instance.CloseAllPanel();//關閉所有UI
        loadscene.LoadLevel("MainMENU");//讓Loading讀取主畫面
    }
}
