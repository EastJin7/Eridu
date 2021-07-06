using UnityEngine;
using System.Collections;

public class HideGround : MonoBehaviour
{
    public zerocontrol player;

    void Start()
    {
        player = GameObject.FindObjectOfType<zerocontrol>();
        this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
    }
}