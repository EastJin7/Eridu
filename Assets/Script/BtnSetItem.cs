using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class BtnSetItem : MonoBehaviour{

    int itemToSet;

    public void SetItemUse(int id)
    {
        itemToSet = id;
        GameState.itemUse = itemToSet ;
    }

}
