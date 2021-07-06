using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AchiView : MonoBehaviour {
    [SerializeField]
    private Text achiName;
    [SerializeField]
    private Text achiContent;
    [SerializeField]
    private Image achiBack;
    [SerializeField]
    private Button Item;
    [SerializeField]
    private int achiId;
    [SerializeField]
    private GetItemUI getPanel;

    void Start()
    {
        achiName.text = AchieveInfo.achiName[achiId];
        achiContent.text = AchieveInfo.achiContent[achiId];
        if(AchieveInfo.achiBoun[achiId])
        {
            achiBack.color = new Color32(154,70,6,255);
        }
        else
        {
            achiBack.color = new Color32(255,141,68,255);
        }
        if(AchieveInfo.achiRece[achiId])
        {
            Item.enabled = false;
        }
    }
    public void Receive()
    {
        if (AchieveInfo.achiBoun[achiId] && !AchieveInfo.achiRece[achiId])
        {
            int cry;
            cry = AchieveInfo.achiward[achiId];
            GameState.crystal += cry;
            getPanel.GetItem("水晶 x " + AchieveInfo.achiward[achiId]);
            AchieveInfo.achiRece[achiId] = true;
        }
    }
}
