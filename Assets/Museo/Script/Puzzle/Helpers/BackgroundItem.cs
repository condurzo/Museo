using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class BackgroundItem : MonoBehaviour {
	
	public bool isInverted;
	public List<GameObject> items;
	// Use this for initialization
	void Start () {
		if(isInverted){
			this.gameObject.SendMessage("MakePixelPerfect");
			this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
			GetComponent<UIWidget>().pivot = AuxFunctions.GetInversedPivot(GetComponent<UIWidget>().pivot);
		}
	}
}
