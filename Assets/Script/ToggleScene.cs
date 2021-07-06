using UnityEngine;
using UnityEngine.UI;

public class ToggleScene : MonoBehaviour
{
    [SerializeField]
    private GameObject coPanel, crPanel, frPanel, itemPanel;
    [SerializeField]
    private Toggle toCoinShop, toCryShop,toFriShop , toItem;
    [SerializeField]
    private Image CoBack, CryBack, FriBack, ItemBack;

    void Start()
    {
        toCoinShop.onValueChanged.AddListener(OnCoinShop);
        toCryShop.onValueChanged.AddListener(OnCrystalShop);
        toFriShop.onValueChanged.AddListener(OnFriendShop);
        toItem.onValueChanged.AddListener(OnItem);
        OnCoinShop(true);
    }

    void OnCoinShop(bool check)
    {
        coPanel.SetActive(true);
        CoBack.color = new Color32(23,72,139,255);
        crPanel.SetActive(false);
        CryBack.color = new Color32(37,101,189,255);
        frPanel.SetActive(false);
        FriBack.color = new Color32(37, 101, 189, 255);
        itemPanel.SetActive(false);
        ItemBack.color = new Color32(37, 101, 189, 255);
    }
    void OnCrystalShop(bool check)
    {
        crPanel.SetActive(true);
        CryBack.color = new Color32(23, 72, 139, 255);
        coPanel.SetActive(false);
        CoBack.color = new Color32(37, 101, 189, 255);
        frPanel.SetActive(false);
        FriBack.color = new Color32(37, 101, 189, 255);
        itemPanel.SetActive(false);
        ItemBack.color = new Color32(37, 101, 189, 255);
    }
    void OnFriendShop(bool check)
    {
        frPanel.SetActive(true);
        FriBack.color = new Color32(23, 72, 139, 255);
        coPanel.SetActive(false);
        CoBack.color = new Color32(37, 101, 189, 255);
        crPanel.SetActive(false);
        CryBack.color = new Color32(37, 101, 189, 255);
        itemPanel.SetActive(false);
        ItemBack.color = new Color32(37, 101, 189, 255);
    }
    void OnItem(bool check)
    {
        itemPanel.SetActive(true);
        ItemBack.color = new Color32(23, 72, 139, 255);
        coPanel.SetActive(false);
        CoBack.color = new Color32(37, 101, 189, 255);
        crPanel.SetActive(false);
        CryBack.color = new Color32(37, 101, 189, 255);
        frPanel.SetActive(false);
        FriBack.color = new Color32(37, 101, 189, 255);
    }
}