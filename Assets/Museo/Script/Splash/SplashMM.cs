using UnityEngine;
using System.Collections;

public class SplashMM : MonoBehaviour {

	public string NameSplash;
	public float Contador;

	void Update () {
		Contador += 1 * Time.deltaTime;
		if (Contador >= 2.5f) {
			Application.LoadLevel (NameSplash);
		}
	}
}
