using UnityEngine;
using System.Collections;

public class HistoriaPortrait : MonoBehaviour {

	public GameObject LogoMuseo;

	void Start () {
		iTween.MoveBy(LogoMuseo, iTween.Hash("y", -5.8, "easeType", "spring", "", "", "delay", .1));

	}

	// Update is called once per frame
	void Update () {
	
	}
}
