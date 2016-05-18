using UnityEngine;
using System.Collections;

public class OffsetPos : MonoBehaviour {
	void Start(){
		this.transform.localPosition = new Vector3(this.transform.localScale.x / 2, this.transform.localScale.x / 2, 0);	
	}
}
