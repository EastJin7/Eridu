using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {
    //放在主角身上，負責進行獲取金錢、道具的處理
    int coins = 0;
    public AudioClip pickup;
    public SoundManager sm;

    void Update()
    {
        if(GameState.victory)
        {
            SaveAll();
        }
    }
    public void CoinPlus(int money)
    {
        sm.PlaySE(pickup);
        coins += money;
    }
    void SaveAll()
    {
        GameState.coins = coins;
    }
}
