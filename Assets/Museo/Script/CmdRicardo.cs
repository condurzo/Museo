using UnityEngine;
using System.Collections;

public class CmdRicardo : MonoBehaviour {
	
	void Start () {
		CmdLogoRicardo ();
		CmdPersonajeRicardo ();
		CmdMensajeRicardo ();
	}

	void CmdLogoRicardo(){
		iTween.MoveBy (GameObject.Find ("Logoricardo"), iTween.Hash ("y", -3.2, "easeType", "spring", "", "", "delay", .1));
	}
	void CmdPersonajeRicardo(){
		iTween.MoveBy (GameObject.Find ("Personajericardo"), iTween.Hash ("y", 7.2, "easeType", "easeOutCirc", "", "", "delay", .1));
	}
	void CmdMensajeRicardo(){
		iTween.MoveBy (GameObject.Find ("Detallericardo"), iTween.Hash ("x", -12.2, "easeType", "easeOutCirc", "", "", "delay", .1));
	}
}




