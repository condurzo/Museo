using UnityEngine;
using System.Collections;

public class SeccionSelfiePortrait : MonoBehaviour {

	void Start () {
		CmdPersonajeRicardo ();
		CmdMensaje ();
		CmdLogo();
	}
	 
	void CmdPersonajeRicardo(){
		iTween.MoveBy (GameObject.Find ("PersonajeP"), iTween.Hash ("y", 7.2, "easeType", "easeOutCirc", "", "", "delay", .1));
	}
	void CmdMensaje(){
		iTween.MoveBy (GameObject.Find ("MensajeP"), iTween.Hash ("x", -14, "easeType", "easeOutCirc", "", "", "delay", .1));
	}
	void CmdLogo(){
		iTween.MoveBy (GameObject.Find ("LogoP"), iTween.Hash ("y", -4.8, "easeType", "spring", "", "", "delay", .1));
	}
}
