using UnityEngine;
using System.Collections;

public class PuzzlePiece : MonoBehaviour {
	
	public Vector2 id;
	public Vector2 pos;
	
	public GameObject topLine;
	public GameObject bottomLine;
	public GameObject rightLine;
	public GameObject leftLine;
	
	private Vector3 bottomFinal;
	private Vector3 bottomInitial;
	private Vector3 topFinal;
	private Vector3 topInitial;
	private Vector3 rightFinal;
	private Vector3 rightInitial;
	private Vector3 leftFinal;
	private Vector3 leftInitial;
	
	/*void OnClick(){
		PuzzleController.instance.MovePiece(this);
		
		for (int i = 0; i < transform.childCount; i++) {
			Destroy(transform.GetChild(i).gameObject);
		}
	}*/
	
	void OnPress(bool isDown){
		if(isDown){
			PuzzleController.instance.SelectPiece(this);
			
			for (int i = 0; i < transform.childCount; i++) {
				Destroy(transform.GetChild(i).gameObject);
			}
		}else{
			PuzzleController.instance.DeselectPiece();	
		}
	}
	
	void Start(){		
		bottomInitial = new Vector3(0.5f,-0.5f,-5);
		bottomFinal = new Vector3(-0.5f,-0.5f,-5);
		topInitial = new Vector3(-0.5f,0.5f,-5);
		topFinal = new Vector3(0.5f,0.5f,-5);
		rightInitial = new Vector3(0.5f,0.5f,-5);
		rightFinal = new Vector3(0.5f,-0.5f,-5);
		leftInitial = new Vector3(-0.5f,-0.5f,-5);
		leftFinal = new Vector3(-0.5f,0.5f,-5);
	}
	
	public void BottomAnimation(){
		bottomLine.transform.localPosition = bottomInitial;
		iTween.MoveTo(bottomLine, iTween.Hash("position", bottomFinal, "isLocal", true, "time", 1.0f));
	}
	
	public void TopAnimation(){
		topLine.transform.localPosition = topInitial;
		iTween.MoveTo(topLine, iTween.Hash("position", topFinal, "isLocal", true, "time", 1.0f));
	}
	
	public void LeftAnimation(){
		leftLine.transform.localPosition = leftInitial;
		iTween.MoveTo(leftLine, iTween.Hash("position", leftFinal, "isLocal", true, "time", 1.0f));
	}
	
	public void RightAnimation(){
		rightLine.transform.localPosition = rightInitial;
		iTween.MoveTo(rightLine, iTween.Hash("position", rightFinal, "isLocal", true, "time", 1.0f));
	}
}
