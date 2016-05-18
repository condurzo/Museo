using UnityEngine;
using System.Collections;

public class SeccionSelfieLandscape : MonoBehaviour {

	void Start () {
		CmdPersonajeRicardo ();
		CmdMensaje ();
		CmdLogo();
	}

	void CmdPersonajeRicardo(){
		iTween.MoveBy (GameObject.Find ("PersonajeL"), iTween.Hash ("y", 7.2, "easeType", "easeOutCirc", "", "", "delay", .1));
	}
	void CmdMensaje(){
		iTween.MoveBy (GameObject.Find ("MensajeL"), iTween.Hash ("x", -13, "easeType", "easeOutCirc", "", "", "delay", .1));
	}
	void CmdLogo(){
		iTween.MoveBy (GameObject.Find ("LogoL"), iTween.Hash ("y", -4.8, "easeType", "spring", "", "", "delay", .1));
	}
}
