using UnityEngine;
using System.Collections;

public class PuzzleSoundButton : MonoBehaviour {
	
	public string prefix;
	private UISprite sprite;
	
	void Start(){
		sprite = GetComponent<UISprite>() as UISprite;
		UpdateSoundButton();
	}
	
	void OnPress(bool pressed){
		if(pressed){
			if(PuzzleController.soundOn){
				sprite.spriteName = prefix+"OnDown";
			}else{
				sprite.spriteName = prefix+"OffDown";
			}
		}else{
			if(PuzzleController.soundOn){
				PuzzleController.soundOn = false;
				SoundManager.PauseMusic();
				sprite.spriteName = prefix+"OffUp";
			}else{
				PuzzleController.soundOn = true;
				SoundManager.ResumeMusic();
				sprite.spriteName = prefix+"OnUp";	
			}	
		}
	}
	
	void UpdateSoundButton(){
		if(PuzzleController.soundOn){
			sprite.spriteName = prefix+"OnUp";
		}else{
			sprite.spriteName = prefix+"OffUp";
		}	
	}
}
