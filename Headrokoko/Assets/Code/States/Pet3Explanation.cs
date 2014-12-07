using UnityEngine;
using System.Collections;
using Assets.Code.Interfaces;

namespace Assets.Code.States{
	public class Pet3Explanation : ISceneState {
		
		private BookStateManager bookmanager;
		
		public Pet3Explanation(BookStateManager Bmanager){
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
			                bookmanager.MonsterExplanation[2],
			                ScaleMode.StretchToFill);
			if(GUI.Button(new Rect((Screen.width/10)*8,(Screen.height/10)*9,
			                       (Screen.width/10)*2,(Screen.height/10)*1),
			              "一覧に戻る")){
				Time.timeScale = 0;
				Debug.Log("図鑑画面に遷移");
				bookmanager.StateChange(new BookState(bookmanager));
			}
		}
	}
}