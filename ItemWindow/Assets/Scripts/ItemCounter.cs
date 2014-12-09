using UnityEngine;
using System.Collections;
using System;


[RequireComponent(typeof(UIButton))]
public class ItemCounter : MonoBehaviour
{
	private int count = 0;
	//押しっぱなし判定間隔
	public float intervalAction = 0.1f;
	public bool callActionFirstPress;
	float nextTime = 0f;
	public UILabel Label;
	public bool pressed { get; private set; }

	
	void Update ()
	{
		Pressing ();
	}
	

	void OnPress (bool pressed)
	{
		this.pressed = pressed;
		SetNextTime ();
		//if(pressed && callActionFirstPress)
			//Debug.Log("Pressing");
	}

	public void LabelIncrement(){	
		ClickCounter (this.Label);
	}

	public void ClickCounter(UILabel label){
		++count;
		int i;
		for(i = 0; i < count; i++) {
			label.text = i.ToString() + "/99";
			if(gThanCount(i)) 
				break; 
		}
	}

	public void Pressing(){
		if (pressed && IsLessThanTime()) {
			SetNextTime();
			ClickCounter(this.Label);
		}
	}

	public void SetNextTime(){
		nextTime = Time.realtimeSinceStartup + intervalAction;
	}
	
	public bool IsLessThanTime(){
		if(nextTime < Time.realtimeSinceStartup)
			return true;
		return false;
	}
	
	public bool gThanCount(int i){
		if(i >= 99)
			return true;
		return false;
	}

}
