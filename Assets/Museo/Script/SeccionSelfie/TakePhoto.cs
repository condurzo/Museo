using UnityEngine;
using System.Collections;
using Vuforia;

public class TakePhoto : MonoBehaviour {
	public GameObject Selector;
	public GameObject SelectorLand;
	public GameObject Cam1;
	public GameObject Cam2;
	public GameObject ChangeCamFront;
	public GameObject ChangeCamBack;
	public GameObject ChangeCamLandFront;
	public GameObject ChangeCamLandBack;
	public static bool SacandoFoto;
	public static bool EstadoCamara;
	public GameObject BackBtnPortrait;
	public GameObject BackBtnLandscape;
	CaptureAndSave snapShot ;



	void Awake(){
		CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_FRONT);
	}
	void Start(){
		snapShot = GameObject.FindObjectOfType<CaptureAndSave> ();
	}
	public void Take () {
		SacandoFoto = true;
		Cam1.SetActive (false);
		Cam2.SetActive (false);
		ChangeCamFront.SetActive (false);
		ChangeCamBack.SetActive (false);
		ChangeCamLandFront.SetActive (false);
		ChangeCamLandBack.SetActive (false);
		Selector.SetActive (false);
		SelectorLand.SetActive (false);
		BackBtnPortrait.SetActive (false);
		BackBtnLandscape.SetActive (false);
		Invoke ("TomarFoto",1);
	}

	void TomarFoto(){
		snapShot.CaptureAndSaveToAlbum();
		Invoke ("Activar", 1);
	}

	void Activar(){
		Cam1.SetActive (true);
		Cam2.SetActive (true);
		ChangeCamFront.SetActive (true);
		ChangeCamBack.SetActive (true);
		ChangeCamLandFront.SetActive (true);
		ChangeCamLandBack.SetActive (true);
		Selector.SetActive (true);
		SelectorLand.SetActive (true);
		BackBtnPortrait.SetActive (true);
		BackBtnLandscape.SetActive (true);
		SacandoFoto = false;
	}

	public void _ChangeCamBack(){
		EstadoCamara = true;
		RestartCamera(CameraDevice.CameraDirection.CAMERA_BACK);

	}
	public void _ChangeCamFront(){
		EstadoCamara = false;
		RestartCamera(CameraDevice.CameraDirection.CAMERA_FRONT);
	}
	private void RestartCamera(CameraDevice.CameraDirection direction){
		CameraDevice.Instance.Stop(); 
		CameraDevice.Instance.Deinit();
		CameraDevice.Instance.Init(direction); 
		CameraDevice.Instance.Start(); 
	}
}
