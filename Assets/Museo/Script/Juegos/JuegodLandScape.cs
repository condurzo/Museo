using UnityEngine;
using System.Collections;

public class JuegodLandScape : MonoBehaviour {


	void Start () {
		CmdLogo ();
		CmdPersonajeRicardo ();
		CmdMensaje ();
		CmdBotones ();
	}

	void CmdLogo(){
		iTween.MoveBy (GameObject.Find ("LogoL"), iTween.Hash ("y", -3.2, "easeType", "spring", "", "", "delay", .1));
	}
	void CmdPersonajeRicardo(){
		iTween.MoveBy (GameObject.Find ("PersonajeL"), iTween.Hash ("y", 7.2, "easeType", "easeOutCirc", "", "", "delay", .1));
	}
	void CmdMensaje(){
		iTween.MoveBy (GameObject.Find ("DetalleL"), iTween.Hash ("x", -12.2, "easeType", "easeOutCirc", "", "", "delay", .1));
	}
	void CmdBotones(){
		iTween.MoveBy (GameObject.Find ("BotonesL"), iTween.Hash ("x", -12.2, "easeType", "easeOutCirc", "", "", "delay", .1));
	}
}




