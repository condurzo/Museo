using UnityEngine;
using System.Collections;

public class HomeProtrait : MonoBehaviour {
	public GameObject LogoHome;

	void Start () {
		iTween.MoveBy(LogoHome, iTween.Hash("y", -5.8, "easeType", "spring", "", "", "delay", .1));
	}



}
