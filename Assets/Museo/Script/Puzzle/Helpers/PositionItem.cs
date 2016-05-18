using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PositionItem : MonoBehaviour {
	
	public string dictItem;
	
	void Start () {
		PositionIt();		
	}
	
	private void PositionIt(){
		if(dictItem != ""){
			Dictionary<string,string> dict;
			dict = DataLoader.instance.Get(dictItem);
			
			if(dict != null){			
				this.transform.localPosition = new Vector3(float.Parse(dict["xPos"]), -float.Parse(dict["yPos"]), this.transform.localPosition.z);
				this.transform.localRotation = Quaternion.Euler(new Vector3(0,0, -float.Parse(dict["rotation"])));
				
				UILabel label = GetComponent<UILabel>();					
				if(label != null){
					int width = Mathf.FloorToInt(float.Parse(dict["width"]));					
					label.lineWidth = width;
				}
			}
		}	
	}
	
	public Vector2 GetPos(){
		if(dictItem != ""){
			Dictionary<string,string> dict;
			dict = DataLoader.instance.Get(dictItem);
			
			if(dict != null){
				Vector2 pos = new Vector2(float.Parse(dict["xPos"]), -float.Parse(dict["yPos"]));		
				return pos;
			}
		}
		return Vector2.zero;
	}
}
