using UnityEngine;
using System.Collections;

public class TriggerOn : MonoBehaviour {
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private SoundManager sm;
    [SerializeField]
    private AudioClip open;
    bool isOpen = false;

    void Start()
    {
        target.SetActive(false);
        isOpen = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "NPC" && !isOpen)
        {
            target.SetActive(true);
            sm.PlaySE(open);
            isOpen = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "NPC" && isOpen)
        {
            target.SetActive(false);
            sm.PlaySE(open);
            isOpen = false;
        }
    }

}
