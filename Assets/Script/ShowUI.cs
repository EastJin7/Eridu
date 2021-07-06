using UnityEngine;
using System.Collections;

public class ShowUI : MonoBehaviour
{
    public void OnBtnOpenUI(string panel)
    {
        UIManager.Instance.ShowPanel(panel);
    }
}
