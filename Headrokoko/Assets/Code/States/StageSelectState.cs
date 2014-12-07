using UnityEngine;
using System.Collections;
using Assets.Code.Interfaces;

namespace Assets.Code.States{
	public class StageSelectState : ISceneState {

		private BookStateManager bookmanager;
		private bool initbool = true;

		public StageSelectState(BookStateManager bmanager){
			bookmanager = bmanager;
			Time.timeScale = 0;
		}

		void Init(){

		}

		public void Render(){
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),bookmanager.StageSelectTex,ScaleMode.StretchToFill);
			if(GUI.Button(new Rect((Screen.width/10) * 1,(Screen.height/10) * 4,(Screen.width/10) * 2,(Screen.height/10) * 1),"Stage1")){
				Application.LoadLevel("Stage1");
				Debug.Log("ステージ１");
				GoNextState();
			}
			else if(GUI.Button(new Rect((Screen.width/10) * 1,(Screen.height/10) * 5,(Screen.width/10) * 2,(Screen.height/10) * 1),"Stage2")){
				Application.LoadLevel("Stage2");
				Debug.Log("ステージ2");
				GoNextState();
			}
			else if(GUI.Button(new Rect((Screen.width/10) * 1,(Screen.height/10) * 6,(Screen.width/10) * 2,(Screen.height/10) * 1),"Stage3")){
				Application.LoadLevel("Stage3");
				Debug.Log("ステージ3");
				GoNextState();
			}
			else if(GUI.Button(new Rect((Screen.width/10) * 1,(Screen.height/10) * 7,(Screen.width/10) * 2,(Screen.height/10) * 1),"Stage4")){
				Application.LoadLevel("Stage4");
				Debug.Log("ステージ4");
				GoNextState();
			}
		
		}

		public void StateUpdate(){
			if(initbool){
				initbool = false;
				Init();
			}
		}

		public void GoNextState(){
			Time.timeScale = 1;
		}
	}
}