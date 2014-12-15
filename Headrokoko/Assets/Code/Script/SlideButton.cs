using UnityEngine;
using System.Collections;

public class SlideButton : MonoBehaviour {

	public string stagename;
	public Vector2 InitPos;
	private Vector2 initpos;
	private float OffsetY;
	public Vector3 Startpos;
	public Vector3 EndPos;
	public Vector3 screenpos;
	public Vector3 mousepos;
	public Vector3 scpos;
	private bool pressbool;
	private bool dragbool;

	void Start(){
		initpos = Camera.main.ScreenToWorldPoint(InitPos);
		gameObject.transform.position = initpos;
		OffsetY = initpos.y;
	}

	void Update(){
		if(dragbool){
			GetScreenPos();
			gameObject.transform.position = screenpos;
		}
		else{
			gameObject.transform.position = initpos;
		}
	}

	void OnPress(bool isDown){
		pressbool = isDown;
		dragbool = false;
		Debug.Log("press");
		Startpos = Input.mousePosition;
	}

	void OnDrag(Vector2 delta){
		Debug.Log("drag");
		Debug.Log(delta);
		dragbool = true;
		EndPos = Input.mousePosition;
		if(delta.x > 20){
			Debug.Log("next state");
			Application.LoadLevel(stagename);
		}
	}

	void OnClick(){
		Debug.Log("Click");
		gameObject.transform.position = initpos;
	}

	public void GetScreenPos(){
		//mousepos = Input.mousePosition;
		screenpos = Camera.main.ScreenToWorldPoint(EndPos);
		if(screenpos.x < -0.8f){
			screenpos.x = -0.8f;
		}
		if(screenpos.x > 0.0){
			screenpos.x = 0.0f;
		}
		screenpos.y = OffsetY;
	}
}
