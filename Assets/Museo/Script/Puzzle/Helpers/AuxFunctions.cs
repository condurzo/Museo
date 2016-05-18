using UnityEngine;
using System.Collections;

public class AuxFunctions : MonoBehaviour {

	public static UIWidget.Pivot GetInversedPivot(UIWidget.Pivot pivot){
		if(pivot == UIWidget.Pivot.TopLeft){
			return UIWidget.Pivot.BottomRight;
		}else if(pivot == UIWidget.Pivot.Left){
			return UIWidget.Pivot.Right;
		}else if(pivot == UIWidget.Pivot.BottomLeft){
			return UIWidget.Pivot.TopRight;
		}else if(pivot == UIWidget.Pivot.Top){
			return UIWidget.Pivot.Bottom;
		}else if(pivot == UIWidget.Pivot.Bottom){
			return UIWidget.Pivot.Top;
		}else if(pivot == UIWidget.Pivot.TopRight){
			return UIWidget.Pivot.BottomLeft;
		}else if(pivot == UIWidget.Pivot.Right){
			return UIWidget.Pivot.Left;
		}else if(pivot == UIWidget.Pivot.BottomRight){
			return UIWidget.Pivot.TopLeft;
		}
		
		return UIWidget.Pivot.Center;
	}
	
	public static UIWidget.Pivot GetFrontPivot(UIWidget.Pivot pivot){
		if(pivot == UIWidget.Pivot.TopLeft){
			return UIWidget.Pivot.TopRight;
		}else if(pivot == UIWidget.Pivot.TopRight){
			return UIWidget.Pivot.TopLeft;
		}
		
		return UIWidget.Pivot.Center;
	}
	
	public static Vector3 GetColliderCenter(UIWidget.Pivot pivot, Vector3 size){
		if(pivot == UIWidget.Pivot.TopLeft){
			return new Vector3(size.x / 2, -size.y / 2,0);
		}else if(pivot == UIWidget.Pivot.Left){
			return new Vector3(size.x / 2,0,0);
		}else if(pivot == UIWidget.Pivot.BottomLeft){
			return new Vector3(size.x / 2, size.y / 2,0);
		}else if(pivot == UIWidget.Pivot.Top){
			return new Vector3(0,-size.y / 2,0);
		}else if(pivot == UIWidget.Pivot.Bottom){
			return new Vector3(0,size.y / 2,0);
		}else if(pivot == UIWidget.Pivot.TopRight){
			return new Vector3(-size.x / 2, -size.y / 2,0);
		}else if(pivot == UIWidget.Pivot.Right){
			return new Vector3(-size.x / 2,0,0);
		}else if(pivot == UIWidget.Pivot.BottomRight){
			return new Vector3(-size.x / 2, size.y / 2,0);
		}else if(pivot == UIWidget.Pivot.Center){
			return new Vector3(0, 0, 0);	
		}
		
		return size;	
	}
	
	public static void ResizeTextField(UILabel label){
		int lineW = label.lineWidth;
		float labelSize = label.font.CalculatePrintedSize(label.text, true, UIFont.SymbolStyle.None).x * label.transform.localScale.x;
		int iterator = 1;
		while(labelSize > lineW){
			label.transform.localScale = new Vector3(label.transform.localScale.x - iterator, label.transform.localScale.y - iterator, 0);
			iterator += 1;			
			labelSize = label.font.CalculatePrintedSize(label.text, true, UIFont.SymbolStyle.None).x * label.transform.localScale.x;
		}		
	}
}
