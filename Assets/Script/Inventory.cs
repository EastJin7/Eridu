using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    GameObject inventoryPanel;
    GameObject slotPanel;
    public GameObject inventorySlot;
    public GameObject inventoryItem;

    int slotAmount;
    //public List<ItemInfo> items = new List<ItemInfo>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        slotAmount = 10;
        inventoryPanel = GameObject.Find("ItemPanel");
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;

        for(int i=0; i<slotAmount; i++)
        {
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
        }
    }
    //public void AddItem(int id)
    //{
    //    Item itemToAdd = database.FetcItemById(id);
    //    for (int i = 0; i < items.Count; i++)
    //    {
    //        if (items[i].ID == -1)
    //        {
    //            items[i] - itemToAdd;
    //            GameObject itemObj -Instantiate(inventoryItem);
    //            itemObj.transform.SetParent(slots[i].transform);
    //            itemObj.GetComponent<Image>().sprite = itemToAdd.Sprites;
    //            itemObj.transform.position = Vector2.zero;
    //            itemObj.name = itemToAdd.Title;
    //            break;
    //        }
    //    }
    //}
}
