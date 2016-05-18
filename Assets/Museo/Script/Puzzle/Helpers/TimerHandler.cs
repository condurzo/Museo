using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimerHandler : MonoBehaviour 
{	
	public static TimerHandler instance;
	private List<Timer> timersList;
	
	private bool running;
	
	void Awake(){
		instance = this;
	}
	
	public void StartTimerHandler(){
		running = true;
		timersList = new List<Timer>();	
	}
	
	public void AddTimer(float time, string method, GameObject target){
		Timer timer = new Timer(time, method, target);
		timersList.Add(timer);
	}
	
	public void StopAllTimers(){
		running = false;
		timersList.Clear();		
	}
	
	public void ClearAllTimers(){
		running = false;
		timersList.Clear();
		running = true;
	}
	
	public void StopTimer(string method){
		for (int i = 0; i < timersList.Count; i++){
			if(timersList[i].methodName == method){
				timersList[i].hasEnded = true;
			}
		}
	}
	
	void Update(){
		if(!running) return;
		if(timersList.Count > 0){
			for (int i = 0; i < timersList.Count; i++){
				if(!timersList[i].hasEnded){
					timersList[i].updateTimer();
				}else{
					timersList.RemoveAt(i);
					i--;
				}
			}
		}
	}
}
