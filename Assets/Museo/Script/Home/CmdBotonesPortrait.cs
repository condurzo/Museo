using UnityEngine;
using System.Collections;

public class CmdBotonesPortrait : MonoBehaviour {

	public static int botonactivo;

	void Start () {
		botonactivo=0;
		iTween.MoveBy(gameObject, iTween.Hash("y", 3, "easeType", "spring", "", "", "delay", .1));
	}
	void CmdHistoria(){
		Application.LoadLevel ("Historia");
	}

	void Cmdexposiciones(){
		if (botonactivo!=2) {
			botonactivo = FncVerifica(botonactivo);
			botonactivo = 2;
			GameObject.Find ("2ExpoTabletaP").transform.position = new Vector3(16.5f, 1, -1f);
			iTween.MoveBy (GameObject.Find ("2ExpoTabletaP"), iTween.Hash ("x", -16, "easeType", "spring", "", "", "delay", .1));
		}
	}


	void CmdActividades(){
		if (botonactivo!=3) {
			botonactivo= FncVerifica (botonactivo);
			botonactivo = 3;
			GameObject.Find ("3ActiTabletaP").transform.position = new Vector3(16.5f, 1, -1f);
			iTween.MoveBy (GameObject.Find ("3ActiTabletaP"), iTween.Hash ("x", -16, "easeType", "spring", "", "", "delay", .1));
		}
	}

	void CmdComollegar(){
		if (botonactivo!=4) {
			botonactivo= FncVerifica (botonactivo);
			botonactivo = 4;
			GameObject.Find ("4ComoTabletaP").transform.position = new Vector3(16.5f, 1, -1f);
			iTween.MoveBy (GameObject.Find ("4ComoTabletaP"), iTween.Hash ("x",-16, "easeType", "spring", "", "", "delay", .1));
		}
	}


	void CmdHorarioytarifario(){
		if (botonactivo!=5) {
			botonactivo= FncVerifica (botonactivo);
			botonactivo = 5;
			GameObject.Find ("5HoraTabletaP").transform.position = new Vector3(16.5f, 1, -1f);
			iTween.MoveBy (GameObject.Find ("5HoraTabletaP"), iTween.Hash ("x", -16, "easeType", "spring", "", "", "delay", .1));
		}
	}

	void CmdContacto(){
		if (botonactivo!=6) {
			botonactivo= FncVerifica (botonactivo);
			botonactivo = 6;
			GameObject.Find ("6ContTabletaP").transform.position = new Vector3(16.5f, 1, -1f);
			iTween.MoveBy (GameObject.Find ("6ContTabletaP"), iTween.Hash ("x", -16, "easeType", "spring", "", "", "delay", .1));
		}
	}

	int FncVerifica(int limpia){
		if(limpia==2) {
			iTween.MoveBy (GameObject.Find ("2ExpoTabletaP"), iTween.Hash ("x", 16, "easeType", "spring", "", "", "delay", .1));
		}
		if(limpia==3) {
			iTween.MoveBy (GameObject.Find ("3ActiTabletaP"), iTween.Hash ("x", 16, "easeType", "spring", "", "", "delay", .1));
		}		
		if(limpia==4) {
			iTween.MoveBy (GameObject.Find ("4ComoTabletaP"), iTween.Hash ("x", 16, "easeType", "spring", "", "", "delay", .1));
		}			
		if(limpia==5) {
			iTween.MoveBy (GameObject.Find ("5HoraTabletaP"), iTween.Hash ("x", 16, "easeType", "spring", "", "", "delay", .1));
		}			
		if(limpia==6) {
			iTween.MoveBy (GameObject.Find ("6ContTabletaP"), iTween.Hash ("x", 16, "easeType", "spring", "", "", "delay", .1));
		}			

		return limpia;
	}
}




