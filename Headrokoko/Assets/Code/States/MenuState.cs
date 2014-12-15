using UnityEngine;
using System.Collections;
using Assets.Code.Interfaces;

namespace Assets.Code.States{
	public class MenuState : ISceneState {

		private BookStateManager bookmanager;

		public MenuState(BookStateManager Bmanager){
			bookmanager = Bmanager;
			Time.timeScale = 0;
		}

		public void StateUpdate(){
			if(Input.GetKeyDown(KeyCode.Space)){
				Debug.Log("図鑑画面に遷移");
				bookmanager.StateChange(new BookState(bookmanager));
			}
		}

		public void Render(){
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),
			                bookmanager.MenuTex,
			                ScaleMode.StretchToFill);
			if(GUI.Button(new Rect((Screen.width/10)*6,(Screen.height/10)*8,
			                       (Screen.width/10)*2,(Screen.height/10)*1),
			                        "BOOK")){
				Time.timeScale = 0;
				Debug.Log("図鑑画面に遷移");
				bookmanager.StateChange(new BookState(bookmanager));
			}

			else if(GUI.Button(new Rect((Screen.width/10)*1,(Screen.height/10)*8,
			                       (Screen.width/10)*2,(Screen.height/10)*1),
			              "StageSelect")){
				Time.timeScale = 0;
				Debug.Log("ステージセレクトに遷移");
				//bookmanager.StateChange(new StageSelectState(bookmanager));
				Application.LoadLevel("StageSlerectScene");
			}
		}
	}
}