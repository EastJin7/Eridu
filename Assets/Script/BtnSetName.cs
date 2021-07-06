using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnSetName : MonoBehaviour
{
    //private LoadScene loadscene;

    void Awake()
    {
        Button setName = GetComponent<Button>();
        //loadscene = GameObject.FindObjectOfType<LoadScene>();
    }
    public void EnterPlayerName(Text enterText)
    {
        GameState.playerName = enterText.text;
        PlayerPrefs.SetString("PlayerName", GameState.playerName);
        //loadscene.LoadLevel("prologue");
        AsyncOperation async = SceneManager.LoadSceneAsync("prologue"); 
    }
}
