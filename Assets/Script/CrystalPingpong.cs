using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CrystalPingpong : MonoBehaviour , IPointerClickHandler
{
    private LoadScene loadscene;
    public GameObject InputPanel;
    public SoundManager sm;
    public AudioClip begin;
    Button crystal;

    void Awake() {
        crystal = GetComponent<Button>();
        loadscene = GameObject.FindObjectOfType<LoadScene>();
        InputPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time*30, -90f), transform.localPosition.z);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameState.playerName==null)
        {
            InputPanel.SetActive(true);
            crystal.enabled = false;
        }
        else
        {
            loadscene.LoadLevel("prologue");
            sm.PlaySE(begin,2f);
         }
    }
}
