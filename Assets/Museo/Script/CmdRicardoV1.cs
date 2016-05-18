using UnityEngine;
using System.Collections;

public class CmdRicardoV1 : MonoBehaviour {
	void Start () {
		CmdPersonajeRicardo ();
		CmdMensajeRicardo ();
		CmdLogoVentana1Ricardo ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void CmdLogoRicardo(){
		iTween.MoveBy (GameObject.Find ("Logoricardo"), iTween.Hash ("y", -3.2, "easeType", "spring", "", "", "delay", .1));
	}
	void CmdPersonajeRicardo(){
		iTween.MoveBy (GameObject.Find ("Personajericardo"), iTween.Hash ("y", 7.2, "easeType", "easeOutCirc", "", "", "delay", .1));
	}
	void CmdMensajeRicardo(){
		iTween.MoveBy (GameObject.Find ("Mensajericardo"), iTween.Hash ("x", -12.2, "easeType", "easeOutCirc", "", "", "delay", .1));
	}
	void CmdLogoVentana1Ricardo(){
		iTween.MoveBy (GameObject.Find ("LogoricardoV1"), iTween.Hash ("y", -4.8, "easeType", "spring", "", "", "delay", .1));
	}

}




