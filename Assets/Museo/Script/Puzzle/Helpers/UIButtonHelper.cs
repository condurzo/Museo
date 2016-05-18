using UnityEngine;
using System.Collections;

public class UIButtonHelper : MonoBehaviour {

	public bool resizeText = false;
	public bool useChildSize = false;
	
	void Start(){
		ResizeButton();	
	}
	
	public void ResizeButton(){
		if(useChildSize){
			Transform background = GetComponentInChildren<UISprite>().transform;
			Vector3 tempSize = background.localScale;
			BoxCollider tempCol = GetComponent<BoxCollider>();
			if(tempCol){
				tempCol.center = AuxFunctions.GetColliderCenter(background.GetComponent<UISprite>().pivot, tempSize);
				tempCol.size = tempSize;
			}
			if(resizeText){
				UILabel label = GetComponentInChildren<UILabel>();
				label.transform.localPosition = AuxFunctions.GetColliderCenter(background.GetComponent<UISprite>().pivot, tempSize);
				AuxFunctions.ResizeTextField(label);
			}else{
				UILabel label = GetComponentInChildren<UILabel>();
				if(label != null)
					label.transform.localPosition = AuxFunctions.GetColliderCenter(background.GetComponent<UISprite>().pivot, tempSize);
			}	
		}else{
			Vector3 tempSize = Vector3.one;
			BoxCollider tempCol = GetComponent<BoxCollider>();
			if(tempCol){
				tempCol.center = AuxFunctions.GetColliderCenter(GetComponent<UISprite>().pivot, tempSize);
			}
		}
	}
}
