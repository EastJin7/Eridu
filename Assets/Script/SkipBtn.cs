using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SkipBtn : MonoBehaviour , IPointerClickHandler
{
    private LoadScene loadscene;
    public Image skippic;
    public World world;
    public AudioClip click;
    // Use this for initialization
    void Start () {
        Button skip = GetComponent<Button>();
        loadscene = GameObject.FindObjectOfType<LoadScene>();
    }
	
	// Update is called once per frame
	void Update () {
        skippic.rectTransform.anchoredPosition = new Vector2(Mathf.PingPong(Time.time * 100, -50f), skippic.rectTransform.anchoredPosition.y);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        world.sm.PlaySE(click);
        loadscene.LoadLevel("slimewar");
        return;
    }
}
