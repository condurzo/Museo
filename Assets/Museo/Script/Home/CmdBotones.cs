using UnityEngine;
using System.Collections;

public class CmdBotones : MonoBehaviour {
	public static int botonactivo;

	void Start () {
		botonactivo=0;
		iTween.MoveBy(gameObject, iTween.Hash("y", 3, "easeType", "spring", "", "", "delay", .1));
	}
	
	void Cmdexposiciones(){
		if (botonactivo!=2) {
			botonactivo = FncVerifica(botonactivo);
			botonactivo = 2;
		    GameObject.Find ("2ExpoTableta").transform.position = new Vector3(14.47f, 1.67f, -1f);
			iTween.MoveBy (GameObject.Find ("2ExpoTableta"), iTween.Hash ("x", -10.7, "easeType", "spring", "", "", "delay", .1));
		}
	}


	void CmdActividades(){
		if (botonactivo!=3) {
		    botonactivo= FncVerifica (botonactivo);
			botonactivo = 3;
			GameObject.Find ("3ActiTableta").transform.position = new Vector3(14.47f, 1.67f, -1f);
			iTween.MoveBy (GameObject.Find ("3ActiTableta"), iTween.Hash ("x", -10.7, "easeType", "spring", "", "", "delay", .1));
		}
	}

	void CmdComollegar(){
		if (botonactivo!=4) {
			botonactivo= FncVerifica (botonactivo);
			botonactivo = 4;
			GameObject.Find ("4ComoTableta").transform.position = new Vector3(14.47f, 1.67f, -1f);
			iTween.MoveBy (GameObject.Find ("4ComoTableta"), iTween.Hash ("x", -10.6, "easeType", "spring", "", "", "delay", .1));
		}
	}


	void CmdHorarioytarifario(){
		if (botonactivo!=5) {
			botonactivo= FncVerifica (botonactivo);
			botonactivo = 5;
			GameObject.Find ("5HoraTableta").transform.position = new Vector3(14.47f, 1.67f, -1f);
			iTween.MoveBy (GameObject.Find ("5HoraTableta"), iTween.Hash ("x", -10.7, "easeType", "spring", "", "", "delay", .1));
		}
	}

	void CmdContacto(){
		if (botonactivo!=6) {
			botonactivo= FncVerifica (botonactivo);
			botonactivo = 6;
			GameObject.Find ("6ContTableta").transform.position = new Vector3(14.47f, 1.67f, -1f);
			iTween.MoveBy (GameObject.Find ("6ContTableta"), iTween.Hash ("x", -10.7, "easeType", "spring", "", "", "delay", .1));
		}
	}

	int FncVerifica(int limpia){
			if(limpia==2) {
				iTween.MoveBy (GameObject.Find ("2ExpoTableta"), iTween.Hash ("x", 10.7, "easeType", "spring", "", "", "delay", .1));
			}
			if(limpia==3) {
				iTween.MoveBy (GameObject.Find ("3ActiTableta"), iTween.Hash ("x", 10.7, "easeType", "spring", "", "", "delay", .1));
			}		
			if(limpia==4) {
				iTween.MoveBy (GameObject.Find ("4ComoTableta"), iTween.Hash ("x", 10.6, "easeType", "spring", "", "", "delay", .1));
			}			
			if(limpia==5) {
				iTween.MoveBy (GameObject.Find ("5HoraTableta"), iTween.Hash ("x", 10.7, "easeType", "spring", "", "", "delay", .1));
			}			
			if(limpia==6) {
				iTween.MoveBy (GameObject.Find ("6ContTableta"), iTween.Hash ("x", 10.7, "easeType", "spring", "", "", "delay", .1));
			}			

		return limpia;
	}
}




