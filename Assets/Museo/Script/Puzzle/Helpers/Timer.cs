using UnityEngine;
using System.Collections;

public class Timer
{
	private float timerLimit;
	private string _methodName;
	private float initialTime;
	private GameObject objectTarget;
	
	public bool hasEnded;
	
	public Timer(float time, string method, GameObject target){
		initialTime = 0;
		hasEnded = false;
		timerLimit = time;
		_methodName = method;
		objectTarget = target;	
	}

	public void updateTimer(){
		initialTime += Time.deltaTime;
		if(initialTime >= timerLimit && !hasEnded){
			hasEnded = true;
			if(objectTarget != null){
				objectTarget.SendMessage(methodName, SendMessageOptions.DontRequireReceiver);
			}	
		}
	}
	
    public string methodName{
        get { return _methodName;  }
        set { _methodName = value; }
    }
}
