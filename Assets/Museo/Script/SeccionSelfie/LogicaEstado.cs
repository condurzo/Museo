using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LogicaEstado : MonoBehaviour {
	public GameObject ButonPortrait;
	public GameObject ButonLand;
	public GameObject ChangeCamFront;
	public GameObject ChangeCamBack;
	public GameObject ChangeCamLandFront;
	public GameObject ChangeCamLandBack;
	public GameObject Personaje1Portrait;
	public GameObject Personaje1Landscape;
	public GameObject Personaje2Portrait;
	public GameObject Personaje2Landscape;
	public GameObject SelectorPortrait;
	public GameObject SelectorLandScape;
	public GameObject BackBtnPortrait;
	public GameObject BackBtnLandscape;


	public void BackBtn () {
		Application.LoadLevel ("Juegos");
	}
	
	// Update is called once per frame
	void Update () {
		if (!TakePhoto.SacandoFoto) {
			if (Screen.orientation == ScreenOrientation.Portrait) {
				
				if (!SelectorPersonajes.VerTomarFoto) {
					ButonPortrait.SetActive (true);
					ButonLand.SetActive (false);
					SelectorPortrait.SetActive (true);
					SelectorLandScape.SetActive (false);
					BackBtnPortrait.SetActive (true);
					BackBtnLandscape.SetActive (false);
				} else {
					ButonPortrait.SetActive (false);
					ButonLand.SetActive (false);
					SelectorPortrait.SetActive (false);
					SelectorLandScape.SetActive (false);
					BackBtnPortrait.SetActive (false);
					BackBtnLandscape.SetActive (false);
				}
				Personaje1Landscape.SetActive (false);
				Personaje2Landscape.SetActive (false);
				if (TakePhoto.EstadoCamara) {
					ChangeCamFront.SetActive (true);
					ChangeCamLandFront.SetActive (false);
					ChangeCamBack.SetActive (false);
					ChangeCamLandBack.SetActive (false);

				} else {
					ChangeCamBack.SetActive (true);
					ChangeCamLandBack.SetActive (false);
					ChangeCamFront.SetActive (false);
					ChangeCamLandFront.SetActive (false);

				}

			}
			if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
				if (!SelectorPersonajes.VerTomarFotoLand) {
					ButonPortrait.SetActive (false);
					ButonLand.SetActive (true);
					SelectorPortrait.SetActive (false);
					SelectorLandScape.SetActive (true);
					BackBtnPortrait.SetActive (false);
					BackBtnLandscape.SetActive (true);
				} else {
					ButonPortrait.SetActive (false);
					ButonLand.SetActive (false);
					SelectorPortrait.SetActive (false);
					SelectorLandScape.SetActive (false);
					BackBtnPortrait.SetActive (false);
					BackBtnLandscape.SetActive (false);
				}
				Personaje1Portrait.SetActive (false);
				Personaje2Portrait.SetActive (false);
				if (TakePhoto.EstadoCamara) {
					ChangeCamFront.SetActive (false);
					ChangeCamLandFront.SetActive (true);
					ChangeCamBack.SetActive (false);
					ChangeCamLandBack.SetActive (false);

				} else {
					ChangeCamBack.SetActive (false);
					ChangeCamLandBack.SetActive (true);
					ChangeCamFront.SetActive (false);
					ChangeCamLandFront.SetActive (false);

				}

			}
			if (Screen.orientation == ScreenOrientation.LandscapeRight) {
				BackBtnPortrait.SetActive (false);
				BackBtnLandscape.SetActive (true);
				if (!SelectorPersonajes.VerTomarFotoLand) {
					ButonPortrait.SetActive (false);
					ButonLand.SetActive (true);
					SelectorPortrait.SetActive (false);
					SelectorLandScape.SetActive (true);
					BackBtnPortrait.SetActive (false);
					BackBtnLandscape.SetActive (true);
				} else {
					ButonPortrait.SetActive (false);
					ButonLand.SetActive (false);
					SelectorPortrait.SetActive (false);
					SelectorLandScape.SetActive (false);
					BackBtnPortrait.SetActive (false);
					BackBtnLandscape.SetActive (false);
				}
				Personaje1Portrait.SetActive (false);
				Personaje2Portrait.SetActive (false);
				if (TakePhoto.EstadoCamara) {
					ChangeCamFront.SetActive (false);
					ChangeCamLandFront.SetActive (true);
					ChangeCamBack.SetActive (false);
					ChangeCamLandBack.SetActive (false);
				
				} else {
					ChangeCamBack.SetActive (false);
					ChangeCamLandBack.SetActive (true);
					ChangeCamFront.SetActive (false);
					ChangeCamLandFront.SetActive (false);

				}

			}
		}
	}
}
