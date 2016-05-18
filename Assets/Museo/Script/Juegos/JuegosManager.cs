using UnityEngine;
using System.Collections;

public class JuegosManager : MonoBehaviour {

	public GameObject PortraitGO;
	public GameObject LandscapeGO;


	void Update(){
		if (Screen.orientation == ScreenOrientation.Portrait) {
			PortraitGO.SetActive (true);
			LandscapeGO.SetActive (false);
		}
		if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
			PortraitGO.SetActive (false);
			LandscapeGO.SetActive (true);
		}
		if (Screen.orientation == ScreenOrientation.LandscapeRight) {
			PortraitGO.SetActive (false);
			LandscapeGO.SetActive (true);
		}
	}
	void GoToSelfie(){
		Application.LoadLevel ("Selfie");
	}

	void SelfieSeccion (){
		Application.LoadLevel ("Ventana3");
	}
	void PuzzleSeccion (){
		Application.LoadLevel ("PuzzleScene");
	}
	void GoToVentana2(){
		Application.LoadLevel ("Ventana2");
	}
}
