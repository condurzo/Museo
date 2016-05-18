using UnityEngine;

public class UIButtonSoundCustom : MonoBehaviour
{
	public enum Trigger{
		OnClick,
		OnMouseOver,
		OnMouseOut,
		OnPress,
		OnRelease,
	}

	public string audioClip;
	public Trigger trigger = Trigger.OnClick;
	public float volume = 1f;

	void OnClick (){
		if (enabled && trigger == Trigger.OnClick && PuzzleController.soundOn){
			SoundManager.PlaySound(audioClip, volume);
		}
	}
}