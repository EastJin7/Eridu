using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {
    public SoundManager sm;
	// Use this for initialization
	void Start () {
        sm = FindObjectOfType<SoundManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
