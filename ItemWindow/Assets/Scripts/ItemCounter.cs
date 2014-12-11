using UnityEngine;
using System.Collections;
using System;


[RequireComponent(typeof(UIButton))]
public class ItemCounter : MonoBehaviour
{
	private int count = 0;
	//押しっぱなし判定の間隔
	public float intervalAction = 0.1f;
	public bool callActionFirstPress;
	float nextTime = 0f;
	public UILabel Label;
	public bool pressed { get; private set; }
	public bool dragged { get; private set; }
	
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

	void OnDrag(Vector2 delta){
		CheckDragged (delta);
	}

	void CheckDragged(Vector2 delta){
		if(delta != null)
			SetDragged(true);
		else
			SetDragged(false);
	}

	public UILabel GetLabel(){
		return this.Label;
	}

	void SetDragged(bool flg){
		this.dragged = flg;
	}

	public void LabelIncrement(){	
		ClickCounter (GetLabel());
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
		if (pressed && IsNotDragWithTime()) {
			SetNextTime();
			ClickCounter(GetLabel());
		}
	}

	public void SetNextTime(){
		nextTime = Time.realtimeSinceStartup + intervalAction;
	}

	public bool IsNotDragWithTime(){
		if(!dragged && IsLessThanTime())
			return true;
		return false;
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
