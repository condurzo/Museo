using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectorPersonajes : MonoBehaviour {
	public static bool VerTomarFoto;
	public GameObject MenuCaras;
	public static bool VerTomarFotoLand;
	public GameObject MenuCarasLand;
	public Image Personaje1Portrait;
	public Image Personaje2Portrait;
	public Image Personaje1Land;
	public Image Personaje2Land;
	public Sprite Personaje1;
	public Sprite Personaje2;
	public Sprite Personaje3;
	public Sprite Personaje4;
	public Sprite Personaje5;
	public Sprite Personaje6;
	public Sprite Personaje7;
	public Sprite Personaje8;
	public Sprite Personaje9;
	public Sprite Personaje10;
	public Sprite Personaje11;

	public void SetPersonaje1 () {
		Personaje1Land.sprite = Personaje1;
		Personaje1Land.gameObject.SetActive (true);
		Personaje1Portrait.sprite = Personaje1;
		Personaje1Portrait.gameObject.SetActive (true);
		Personaje2Portrait.gameObject.SetActive (false);
		MenuCaras.SetActive (false);
		MenuCarasLand.SetActive (false);
		VerTomarFoto = false;
		VerTomarFotoLand = false;
	}
	public void SetPersonaje2 () {
		Personaje1Land.sprite = Personaje2;
		Personaje1Land.gameObject.SetActive (true);
		Personaje1Portrait.sprite = Personaje2;
		Personaje1Portrait.gameObject.SetActive (true);
		Personaje2Portrait.gameObject.SetActive (false);
		MenuCaras.SetActive (false);
		MenuCarasLand.SetActive (false);
		VerTomarFoto = false;
		VerTomarFotoLand = false;
	}
	public void SetPersonaje3 () {
		Personaje2Land.sprite = Personaje3;
		Personaje2Land.gameObject.SetActive (true);
		Personaje2Portrait.sprite = Personaje3;
		Personaje1Portrait.gameObject.SetActive (false);
		Personaje2Portrait.gameObject.SetActive (true);
		MenuCaras.SetActive (false);
		MenuCarasLand.SetActive (false);
		VerTomarFoto = false;
		VerTomarFotoLand = false;
	}
	public void SetPersonaje4 () {
		Personaje1Land.sprite = Personaje4;
		Personaje1Land.gameObject.SetActive (true);
		Personaje1Portrait.sprite = Personaje4;
		Personaje1Portrait.gameObject.SetActive (true);
		Personaje2Portrait.gameObject.SetActive (false);
		MenuCaras.SetActive (false);
		MenuCarasLand.SetActive (false);
		VerTomarFoto = false;
		VerTomarFotoLand = false;
	}
	public void SetPersonaje5 () {
		Personaje2Land.sprite = Personaje5;
		Personaje2Land.gameObject.SetActive (true);
		Personaje2Portrait.sprite = Personaje5;
		Personaje1Portrait.gameObject.SetActive (false);
		Personaje2Portrait.gameObject.SetActive (true);
		MenuCaras.SetActive (false);
		MenuCarasLand.SetActive (false);
		VerTomarFoto = false;
		VerTomarFotoLand = false;
	}
	public void SetPersonaje6 () {
		Personaje2Land.sprite = Personaje6;
		Personaje2Land.gameObject.SetActive (true);
		Personaje2Portrait.sprite = Personaje6;
		Personaje1Portrait.gameObject.SetActive (false);
		Personaje2Portrait.gameObject.SetActive (true);
		MenuCaras.SetActive (false);
		MenuCarasLand.SetActive (false);
		VerTomarFoto = false;
		VerTomarFotoLand = false;
	}
	public void SetPersonaje7 () {
		Personaje1Land.sprite = Personaje7;
		Personaje1Land.gameObject.SetActive (true);
		Personaje1Portrait.sprite = Personaje7;
		Personaje1Portrait.gameObject.SetActive (true);
		Personaje2Portrait.gameObject.SetActive (false);
		MenuCaras.SetActive (false);
		MenuCarasLand.SetActive (false);
		VerTomarFoto = false;
		VerTomarFotoLand = false;
	}
	public void SetPersonaje8 () {
		Personaje1Land.sprite = Personaje8;
		Personaje1Land.gameObject.SetActive (true);
		Personaje1Portrait.sprite = Personaje8;
		Personaje1Portrait.gameObject.SetActive (true);
		Personaje2Portrait.gameObject.SetActive (false);
		MenuCaras.SetActive (false);
		MenuCarasLand.SetActive (false);
		VerTomarFoto = false;
		VerTomarFotoLand = false;
	}
	public void SetPersonaje9 () {
		Personaje1Land.sprite = Personaje9;
		Personaje1Land.gameObject.SetActive (true);
		Personaje1Portrait.sprite = Personaje9;
		Personaje1Portrait.gameObject.SetActive (true);
		Personaje2Portrait.gameObject.SetActive (false);
		MenuCaras.SetActive (false);
		MenuCarasLand.SetActive (false);
		VerTomarFoto = false;
		VerTomarFotoLand = false;
	}
	public void SetPersonaje10 () {
		Personaje2Land.sprite = Personaje10;
		Personaje2Land.gameObject.SetActive (true);
		Personaje2Portrait.sprite = Personaje10;
		Personaje1Portrait.gameObject.SetActive (false);
		Personaje2Portrait.gameObject.SetActive (true);
		MenuCaras.SetActive (false);
		MenuCarasLand.SetActive (false);
		VerTomarFoto = false;
		VerTomarFotoLand = false;
	}
	public void SetPersonaje11 () {
		Personaje2Land.sprite = Personaje11;
		Personaje2Land.gameObject.SetActive (true);
		Personaje2Portrait.sprite = Personaje11;
		Personaje1Portrait.gameObject.SetActive (false);
		Personaje2Portrait.gameObject.SetActive (true);
		MenuCaras.SetActive (false);
		MenuCarasLand.SetActive (false);
		VerTomarFoto = false;
		VerTomarFotoLand = false;
	}
	public void VerMenu(){
		MenuCaras.SetActive (true);
		VerTomarFoto = true;
	}
	public void VerMenuLand(){
		MenuCarasLand.SetActive (true);
		VerTomarFotoLand = true;
	}
}
