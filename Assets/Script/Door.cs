using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    LoadScene loadscene;
    private zerocontrol player;

    void Start ()
    {
        loadscene = GameObject.FindObjectOfType<LoadScene>();
        player = GameObject.FindObjectOfType<zerocontrol>();
    }

	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.body.position = new Vector3(7f, -0.6f, 0f);
            return;
        }
    }
}
