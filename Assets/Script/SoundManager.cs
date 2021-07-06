using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    public AudioSource bgm;//定義音樂檔案
    public AudioSource se;//定義音樂檔案

    public void PlaySE(AudioClip au)//一個接收AudioClip變數au的函式
    {
        se.PlayOneShot(au);//接收之後讓se播放變數au的音效
    }

    public void PlaySE(AudioClip au, float value)
    {
        se.PlayOneShot(au, value);
    }
}
