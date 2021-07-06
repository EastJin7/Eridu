using UnityEngine;
using System.Collections;

public class ForTest : MonoBehaviour
{

    void Start()
    {
        Debug.Log("測試模式");
        GameState.skill1Lv = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameState.coins += 100;
            GameState.crystal += 20;
            GameState.allCoins += 200;
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            GameState.victory = true;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("Crystal", 0);
        }
    }

}
