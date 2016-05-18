using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
	
	private Vector3 touchPosition;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer){
			touchPosition = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0);
		}else if(Application.platform == RuntimePlatform.WindowsEditor 
			|| Application.platform == RuntimePlatform.WindowsPlayer 
			|| Application.platform == RuntimePlatform.WindowsWebPlayer){
			touchPosition = Input.mousePosition;
		}			
		
		Vector3 realPosition = Camera.main.ScreenToWorldPoint(touchPosition);
		
		Debug.Log(realPosition);
	}
}
