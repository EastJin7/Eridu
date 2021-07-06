using UnityEngine;
using System.Collections;

public class ClearEffect : MonoBehaviour {
    public zerocontrol player;
    public Transform target;
    public bool atkright;
    // Use this for initialization

    void Awake () {
        player = GameObject.FindObjectOfType<zerocontrol>();
        this.GetComponent<SpriteRenderer>().enabled = false;
        transform.position = target.position;
        atkright = player.facingRight;
        if (atkright)
        {
            this.transform.position = target.position+new Vector3(0.4f, 0.195f);
        }
        else
        {
            this.transform.position = target.position + new Vector3(-0.4f, 0.195f);
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = target.position;
        atkright = player.facingRight;
        if (atkright)
        {
            this.transform.position = target.position + new Vector3(0.4f, 0.195f);
        }
        else
        {
            this.transform.position = target.position + new Vector3(-0.4f, 0.195f);
        }
        if (player.animStateInfo.normalizedTime >= 0.9f)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
