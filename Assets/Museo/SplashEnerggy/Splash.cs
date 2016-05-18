using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {
	public float Tiempo;
	public AnimacionBolita bolita;
	public AudioClip sonido;
	public bool activeSonido;
	void Start(){

		if(PlayerPrefs.GetInt("UnaVez")==0){
			PlayerPrefs.SetInt("Elijio",1);
			PlayerPrefs.SetInt("UnaVez",1);
		}


		GetComponent<AudioSource>().clip = sonido;
		if(PlayerPrefs.GetInt("Setear")==0){
			PlayerPrefs.SetInt("Mute",1);
			PlayerPrefs.SetInt("Setear",1);
		}
	}

	void Update () {
		if(AnimacionBolita.currentPathPercent>=1){
			bolita.enabled = false;
		}
		if( Tiempo >= 1.3f){
			if(!GetComponent<AudioSource>().isPlaying){
				GetComponent<AudioSource>().Play();
			}
		}

		Tiempo += Time.deltaTime;
		if( Tiempo >= 3.5f){
			System.GC.Collect();
			System.GC.WaitForPendingFinalizers();
			Resources.UnloadUnusedAssets();
			Application.LoadLevel("Home");
		}
	}
}
