using UnityEngine;
using System.Collections;

public class JuegosPortrait : MonoBehaviour {


	void Start () {
		CmdLogo();
		CmdPersonajeRicardo ();
		CmdMensaje();
		CmdBotones ();
	}

	void CmdLogo(){
		iTween.MoveBy (GameObject.Find ("LogoP"), iTween.Hash ("y", -3.2, "easeType", "spring", "", "", "delay", .1));
	}
	void CmdPersonajeRicardo(){
		iTween.MoveBy (GameObject.Find ("PersonajeP"), iTween.Hash ("y", 7.2, "easeType", "easeOutCirc", "", "", "delay", .1));
	}
	void CmdMensaje(){
		iTween.MoveBy (GameObject.Find ("DetalleP"), iTween.Hash ("x", 12.5f, "easeType", "easeOutCirc", "", "", "delay", .1));
	}
	void CmdBotones(){
		iTween.MoveBy (GameObject.Find ("BotonesP"), iTween.Hash ("x", -12.8f, "easeType", "easeOutCirc", "", "", "delay", .1));
	}
}




