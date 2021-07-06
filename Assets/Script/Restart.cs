using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour, IPointerClickHandler
{
    protected Scene scene;
	// Use this for initialization
	void Start () {
        Button restart = GetComponent<Button>();
        scene = SceneManager.GetActiveScene();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        //點擊事件
        GameState.gamepause = false;
        GameState.gameover = true;
        UIManager.Instance.CloseAllPanel();//關閉所有UI
        SceneManager.LoadSceneAsync(scene.name);
    }
}
