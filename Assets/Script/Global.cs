using UnityEngine;
using System.Collections;
 
public class Global :MonoBehaviour
{
	public static Global instance;
 
	static Global()
	{
		GameObject go = new GameObject("Globa");
		DontDestroyOnLoad(go);
		instance = go.AddComponent<Global>();
	}
 
	public void DoSomeThings()
	{
		Debug.Log("DoSomeThings");
	}
 
	void Start () 
	{
		Debug.Log("Start");
	}
 
}