using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SeccionHistoria : MonoBehaviour {

	public Sprite[] Salas;
	public Image ImagenFondo;
	public GameObject PortraitGO;
	public GameObject LandscapeGO;

	void Start(){
		switch (PlayerPrefs.GetInt ("Salas")) {
		case 0: 
			ImagenFondo.GetComponent<Image>().sprite = Salas [0];
			break;
		case 1:
			ImagenFondo.GetComponent<Image>().sprite = Salas [1];
			break;
		case 2:
			ImagenFondo.GetComponent<Image>().sprite = Salas [2];
			break;
		case 3:
			ImagenFondo.GetComponent<Image>().sprite = Salas [3];
			break;
		case 4:
			ImagenFondo.GetComponent<Image>().sprite = Salas [4];
			break;
		case 5:
			ImagenFondo.GetComponent<Image>().sprite = Salas [5];
			break;
		case 6:
			ImagenFondo.GetComponent<Image>().sprite = Salas [6];
			break;
		}
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

	public void VolverBtn(){
		PlayerPrefs.SetInt ("Salas", 0);
		Application.LoadLevel ("Home");
	}

	public void Sala1 () {
		PlayerPrefs.SetInt ("Salas", 1);
		Application.LoadLevel ("Historia");
	}
	public void Sala2 () {
		PlayerPrefs.SetInt ("Salas", 2);
		Application.LoadLevel ("Historia");
	}
	public void Sala3 () {
		PlayerPrefs.SetInt ("Salas", 3);
		Application.LoadLevel ("Historia");
	}
	public void Sala4 () {
		PlayerPrefs.SetInt ("Salas", 4);
		Application.LoadLevel ("Historia");
	}
	public void Sala5 () {
		PlayerPrefs.SetInt ("Salas", 5);
		Application.LoadLevel ("Historia");
	}
	public void Sala6 () {
		PlayerPrefs.SetInt ("Salas", 6);
		Application.LoadLevel ("Historia");
	}
}
