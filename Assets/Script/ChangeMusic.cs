using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeMusic : MonoBehaviour {
    public SoundManager sm;
    public Slider BGMSlider;
    public Slider SeSlider;

    // Use this for initialization
    void Start ()
    {
        sm = GameObject.FindObjectOfType<SoundManager>();
        sm.bgm.volume = GameState.BGMVolume;
        sm.se.volume = GameState.seVolume;
        BGMSlider.value = GameState.BGMVolume;
        SeSlider.value = GameState.seVolume;
	}
    public void ChangeBGM()
    {
        GameState.BGMVolume = BGMSlider.value;
        sm.bgm.volume = GameState.BGMVolume;
    }
    public void ChangeSE()
    {
        GameState.seVolume = SeSlider.value;
        sm.se.volume = GameState.seVolume;
    }
}
