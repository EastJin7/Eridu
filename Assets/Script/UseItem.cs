using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class UseItem : MonoBehaviour, IPointerClickHandler {
    int itemId;
    int lastTime;
    [SerializeField]
    private zerocontrol player;
    [SerializeField]
    private Text itemAmount;
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private Image sprite;
    bool canUse = true;

    // Use this for initialization
    void Start()
    {
        itemId = GameState.itemUse;
        player = GameObject.FindObjectOfType<zerocontrol>();
        itemAmount.text = ItemInfo.itemOwn[itemId] + "";
        sprite.sprite = sprites[itemId];
    }

    void Use(int id)
    {
        itemId = id;
        if (ItemInfo.itemOwn[itemId] >= 1)
        {
            switch (itemId)
            {
                case 0:
                    canUse = player.Cure(20);
                    player.hud.Coruscate();
                    break;
                case 1:
                    player.Invincible();
                    break;
                case 2:
                    player.PlusDefence(4);
                    break;
            }
            if (canUse)
            {
                ItemInfo.itemOwn[itemId] -= 1;
            }
            canUse = true;
            itemAmount.text = ItemInfo.itemOwn[itemId] + "";
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        itemId = GameState.itemUse;
        Use(itemId);
    }
    public void UseThis()
    {
        itemId = GameState.itemUse;
        Use(itemId);
    }
}
