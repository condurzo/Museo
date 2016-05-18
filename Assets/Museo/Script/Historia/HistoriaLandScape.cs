using UnityEngine;
using System.Collections;

public class HistoriaLandScape : MonoBehaviour {

	public GameObject LogoMuseo;
	public GameObject HistoriaGO;

	void Start () {
		iTween.MoveBy(LogoMuseo, iTween.Hash("y", -5.8, "easeType", "spring", "", "", "delay", .1));
		iTween.MoveBy(HistoriaGO, iTween.Hash("x", -16, "easeType", "spring", "", "", "delay", .1));

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
