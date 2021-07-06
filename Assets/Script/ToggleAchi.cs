using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleAchi : MonoBehaviour {
    [SerializeField]
    private GameObject timesPanel, storyPanel, systemPanel, killPanel;
    [SerializeField]
    private Toggle toTimes, toStory, toSystem, toKill;
    [SerializeField]
    private Image timesBack, storyBack, systemBack, killBack;

    void Start ()
    {
        toTimes.onValueChanged.AddListener(OnTimeAchi);
        toStory.onValueChanged.AddListener(OnStoryAchi);
        toSystem.onValueChanged.AddListener(OnSystemAchi);
        toKill.onValueChanged.AddListener(OnKillAchi);
        OnTimeAchi(true);
    }

    //126 58 6
    void OnTimeAchi(bool check)
    {
        timesPanel.SetActive(true);
        timesBack.color = new Color32(165, 122, 89, 255);
        storyPanel.SetActive(false);
        storyBack.color = new Color32(255, 255, 255, 255);
        systemPanel.SetActive(false);
        systemBack.color = new Color32(255, 255, 255, 255);
        killPanel.SetActive(false);
        killBack.color = new Color32(255, 255, 255, 255);

    }
    void OnStoryAchi(bool check)
    {
        storyPanel.SetActive(true);
        storyBack.color = new Color32(165, 122, 89, 255);
        timesPanel.SetActive(false);
        timesBack.color = new Color32(255, 255, 255, 255);
        systemPanel.SetActive(false);
        systemBack.color = new Color32(255, 255, 255, 255);
        killPanel.SetActive(false);
        killBack.color = new Color32(255, 255, 255, 255);
    }
    void OnSystemAchi(bool check)
    {
        systemPanel.SetActive(true);
        systemBack.color = new Color32(165, 122, 89, 255);
        timesPanel.SetActive(false);
        timesBack.color = new Color32(255, 255, 255, 255);
        storyPanel.SetActive(false);
        storyBack.color = new Color32(255, 255, 255, 255);
        killPanel.SetActive(false);
        killBack.color = new Color32(255, 255, 255, 255);
    }
    void OnKillAchi(bool check)
    {
        killPanel.SetActive(true);
        killBack.color = new Color32(165, 122, 89, 255);
        systemPanel.SetActive(false);
        systemBack.color = new Color32(255, 255, 255, 255);
        timesPanel.SetActive(false);
        timesBack.color = new Color32(255, 255, 255, 255);
        storyPanel.SetActive(false);
        storyBack.color = new Color32(255, 255, 255, 255);
    }
}
