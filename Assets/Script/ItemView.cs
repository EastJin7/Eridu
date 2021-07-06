using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemView : MonoBehaviour {
    [SerializeField]
    private int itemId;
    [SerializeField]
    private Text itemA;
    [SerializeField]
    private ShopManager shop;
    [SerializeField]
    private Image itemImage;
    private int amount;

    // Use this for initialization
    void Start () {
        Reo();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Reo()
    {
        amount = ItemInfo.itemOwn[itemId];
        itemA.text = amount + "";
        if (amount == 0)
        {
            itemImage.color = new Color32(47,47,47,255);
        }
        else
        {
            itemImage.color = new Color32(255, 255, 255, 255);
        }
    }
}
