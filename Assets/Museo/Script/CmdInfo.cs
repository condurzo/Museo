using UnityEngine;
using System.Collections;

public class CmdInfo : MonoBehaviour {
	// Use this for initialization
	void Start () {
		iTween.MoveBy(gameObject, iTween.Hash("x", -12, "easeType", "spring", "", "", "delay", .1));
	}
	
	// Update is called once per frame
	void Update () {

	}
}
