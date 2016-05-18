using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Clase que maneja la carga y reproduccion de los diferentes sonidos del juego.

public class SoundManager : MonoBehaviour {
	
	private static Dictionary<string, AudioClip> soundList;
	private static AudioSource source;
	
	void Start(){
		soundList = new Dictionary<string, AudioClip>();
		Object[] audioList = Resources.LoadAll("Sound", typeof(AudioClip));
		int cant = audioList.Length;
		for (int i = 0; i < cant; i++) {
			soundList.Add(audioList[i].name, audioList[i] as AudioClip);
		}
		source = GetComponent<AudioSource>();		
	}
	
	//Reproduce el sonido que es enviado como parametro.
	public static void PlaySound(string soundName, float volume){
		if(PuzzleController.soundOn)
			source.PlayOneShot(soundList[soundName], volume);
	}
	
	public static void PlayMusic(string musicName){
		if(PuzzleController.soundOn){
			source.clip = soundList[musicName];
			source.Play();
		}
	}
	
	public static void PauseMusic(){
		source.Pause();	
	}
	
	public static void ResumeMusic(){
		source.Play();	
	}
}
