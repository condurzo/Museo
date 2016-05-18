using UnityEngine;
using System.Collections;

public class CmdLogo : MonoBehaviour {
	void Start () {
		iTween.MoveBy(gameObject, iTween.Hash("y", -5.8, "easeType", "spring", "", "", "delay", .1));
	}
	
	// Update is called once per frame
	void Update () {

	}
}




