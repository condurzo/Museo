using UnityEngine;
using System.Collections;

public class CmdPrincipal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void CmdHistoria(){
				Application.LoadLevel ("Historia");

		}
	void CmdJugar(){
		Application.LoadLevel ("Ricardo");
		
	}


	void CmdFacebook(){
		Application.OpenURL ("http://www.facebook.com");
		
	}

	void CmdTwitter(){
		Application.OpenURL ("https://twitter.com");
		
	}

	void CmdYoutube(){
		Application.OpenURL ("http://www.youtube.com");
		
	}

	
	void CmdVentana1Ricardo(){
		Application.LoadLevel ("Ventana1");
		
	}

	void CmdVentana2Ricardo(){
		Application.LoadLevel ("Ventana2");
		
	}


}
