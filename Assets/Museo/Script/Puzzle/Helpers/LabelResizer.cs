using UnityEngine;
using System.Collections;

public class LabelResizer : MonoBehaviour {
	
	public bool useObjectWidth;
	public Transform objectTarget;
	public int offset;
	
	void Start(){
		ResizeLabel();	
	}
	
	void ResizeLabel(){
		UILabel label = this.gameObject.GetComponent<UILabel>();		
		label.MakePixelPerfect();
		
		if(useObjectWidth && objectTarget != null){
			int width = (int)objectTarget.localScale.x;
			label.lineWidth = width - offset;
			AuxFunctions.ResizeTextField(label);
		}else{		
			if(label.lineWidth > 0){		
				AuxFunctions.ResizeTextField(label);
			}else{
				float scale = this.transform.localScale.x;
				this.transform.localScale = new Vector3(scale / 2,scale / 2,0);	
			}
		}
	}
}
