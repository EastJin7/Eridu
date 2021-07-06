using UnityEngine;
using System.Collections;

public class FallGround : MonoBehaviour {
    public Rigidbody2D body;
    public zerocontrol player;
    public float falltime;//觸發掉落時間從編輯器上指定
    public float destime;//摧毀時間從編輯器上指定

    void Start () {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindObjectOfType<zerocontrol>();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(fall(falltime));
        }
    }
    IEnumerator fall(float wait)
    {
        yield return new WaitForSeconds(falltime);
        this.body.isKinematic = false;
        yield return new WaitForSeconds(destime);
        this.GetComponent<Collider2D>().enabled = false;
        Destroy(this);
    }
}
