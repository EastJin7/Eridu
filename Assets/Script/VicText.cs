using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class VicText : MonoBehaviour {
    public zerocontrol player;
    public Text passTime;
    public Text kill;
    public Text clear;
    public Text lv;
    public Text coins;
    public AudioClip vic;
    public World world;
    string level;
    int score=60;
    int plus=0;

	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<zerocontrol>();
        world = GameObject.FindObjectOfType<World>();
        world.sm.PlaySE(vic,0.5f);
        SimpleScore();
        PrintVic();
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    void SimpleScore()
    {
        if (GameState.sword < 50) { plus = plus+10; }
        if (GameState.sword < 30) { plus = plus+10; }
        if (GameState.sword < 10) { plus = plus+10; }
        if (GameState.cleara > 5 || GameState.killa > 5) { plus = plus+10; }
        if (GameState.noKilla > 3){ plus = plus-20;}
        if (GameState.noKilla > 5) { plus = plus -20; }
        if (player.nowHp > 50) { plus += 10; }
        if (player.nowHp > 70) { plus += 10; }
        if (player.nowHp == 100) { plus += 10; }
        score = score + plus;
        if (score <= 30) { level = "F"; }
        if (score > 30) { level = "E"; }
        if (score > 40) { level = "D"; }
        if (score > 50) { level = "C"; }
        if (score > 60) { level = "B"; }
        if (score > 70) { level = "A"; }
        if (score > 80) { level = "S"; }
        if (score > 90) { level = "S+"; }
        if (score > 100) { level = "S++"; }
        if (level == "E") { GameState.coins += 10; }
        if(level == "D") { GameState.coins += 20; }
        if(level == "C") { GameState.coins += 30; }
        if(level == "B") { GameState.coins += 40; }
        if(level == "A") { GameState.coins += 50; }
        if(level == "S") { GameState.coins += 60; }
        if(level == "S+") { GameState.coins += 70; }
        if(level == "S++") { GameState.coins += 100; }


    }
    void PrintVic()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(GameState.gametime);
        string timeText = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        passTime.text = timeText;
        kill.text = GameState.killa + "";
        clear.text = GameState.cleara + "";
        lv.text = level;
        coins.text = GameState.coins+"";
    }
}
