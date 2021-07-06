using UnityEngine;

public class UIRootHandler : MonoBehaviour
{//必須掛在Canvas下
    void Awake()
    {
        UIManager.Instance.m_Canvas = gameObject;//呼叫UIManager叫他生成畫布和物件
    }
}