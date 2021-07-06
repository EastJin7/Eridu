using UnityEngine;
using System.Collections;

public class CloseUI : MonoBehaviour {

    public string closeUI;
    public void OnClickCloseUI()
    {
        UIManager.Instance.ClosePanel(closeUI) ;
    }
}
