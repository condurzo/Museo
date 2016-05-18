using UnityEngine;
using System.Collections;

public class RootReset : MonoBehaviour {

	void ResetRoot(int size){
		UIRoot root = GetComponent<UIRoot>();
		if(root != null){
			root.manualHeight = size;
		}	
	}
}
