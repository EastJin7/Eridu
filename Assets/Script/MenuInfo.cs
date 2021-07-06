using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuInfo : MonoBehaviour {
    public Text playerN;
    public Text coinsA;
    public Text friendA;
    public Text crystalA;
    public SavePlayerPrefs save;

    // Use this for initialization
    void Start () {
        playerN.text = GameState.playerName;
        coinsA.text = GameState.allCoins+"";
        friendA.text = GameState.friendP+"";
        crystalA.text = GameState.crystal + "";
    }
	
	// Update is called once per frame
	void Update () {

    }
    public void Reo()//重新整理
    {
        playerN.text = GameState.playerName;
        coinsA.text = GameState.allCoins + "";
        friendA.text = GameState.friendP + "";
        crystalA.text = GameState.crystal + "";
    }
}
