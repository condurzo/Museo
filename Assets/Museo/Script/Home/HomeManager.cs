using UnityEngine;
using System.Collections;

public class HomeManager : MonoBehaviour {

	public GameObject PortraitGO;
	public GameObject LandscapeGO;

	public void CmdJugar(){
		Application.LoadLevel ("Juegos");
	}

	public void CmdFacebook(){
		Application.OpenURL ("http://www.facebook.com");
	}

	public void CmdTwitter(){
		Application.OpenURL ("https://twitter.com");
	}

	public void CmdYoutube(){
		Application.OpenURL ("http://www.youtube.com");
	}

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

}
