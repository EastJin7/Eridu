using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleSkill : MonoBehaviour {
    [SerializeField]
    private GameObject passive, power, pease;
    [SerializeField]
    private Toggle toPass, toPower, toPease;
    [SerializeField]
    private Image passBack, powerBack, peaseBack;

    void Start () {
        toPass.onValueChanged.AddListener(OnPass);
        toPower.onValueChanged.AddListener(OnPower);
        toPease.onValueChanged.AddListener(OnPease);
        OnPass(true);
    }
	

    void OnPass(bool check)
    {
        passive.SetActive(true);
        passBack.color = new Color32(165, 122, 89, 255);
        power.SetActive(false);
        powerBack.color = new Color32(255, 255, 255, 255);
        pease.SetActive(false);
        peaseBack.color = new Color32(255, 255, 255, 255);
    }
    void OnPower(bool check)
    {
        power.SetActive(true);
        powerBack.color = new Color32(165, 122, 89, 255);
        passive.SetActive(false);
        passBack.color = new Color32(255, 255, 255, 255);
        pease.SetActive(false);
        peaseBack.color = new Color32(255, 255, 255, 255);
    }
    void OnPease(bool check)
    {
        pease.SetActive(true);
        peaseBack.color = new Color32(165, 122, 89, 255);
        passive.SetActive(false);
        passBack.color = new Color32(255, 255, 255, 255);
        power.SetActive(false);
        powerBack.color = new Color32(255, 255, 255, 255);
    }
}
