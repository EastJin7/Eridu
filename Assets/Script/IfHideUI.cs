using UnityEngine;
using System.Collections;

public class IfHideUI : MonoBehaviour
{

    public void OnBtnHideUI(string panel, bool ifhide)
    {
        UIManager.Instance.TogglePanel(panel, ifhide);
    }
}
