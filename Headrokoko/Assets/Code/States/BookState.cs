using UnityEngine;
using System.Collections;
using Assets.Code.Interfaces;

namespace Assets.Code.States{

	public class BookState : ISceneState {
		
		
		private BookStateManager bookmanager;
		private int monsterNum;
		
		public BookState(BookStateManager Bmanager){
			bookmanager = Bmanager;
			Time.timeScale = 0;
		}

		public void StateUpdate(){
			if(Input.GetKeyDown(KeyCode.Space)){
				Debug.Log("menu画面に遷移");
				bookmanager.StateChange(new MenuState(bookmanager));
			}
			
			if(Input.GetKeyDown(KeyCode.F1)){
				Debug.Log("図鑑1をアンロック");
				bookmanager.MonsterLock[0] = true;
			}
			if(Input.GetKeyDown(KeyCode.F2)){
				Debug.Log("図鑑2をアンロック");
				bookmanager.MonsterLock[1] = true;
			}
			if(Input.GetKeyDown(KeyCode.F3)){
				Debug.Log("図鑑3をアンロック");
				bookmanager.MonsterLock[2] = true;
			}
			if(Input.GetKeyDown(KeyCode.F4)){
				Debug.Log("図鑑4をアンロック");
				bookmanager.MonsterLock[3] = true;
			}
			if(Input.GetKeyDown(KeyCode.F5)){
				Debug.Log("図鑑5をアンロック");
				bookmanager.MonsterLock[4] = true;
			}
			if(Input.GetKeyDown(KeyCode.F6)){
				Debug.Log("図鑑6をアンロック");
				bookmanager.MonsterLock[5] = true;
			}
		}
		
		public void Render(){
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),
			                bookmanager.BookBackgroundTex,
			                ScaleMode.StretchToFill);
			if(bookmanager.MonsterLock[0]){
				if(GUI.Button(new Rect((Screen.width/10)*1,(Screen.height/10)*2,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				              bookmanager.MonsterTex[0])){
					bookmanager.StateChange(new Pet1Explanation(bookmanager,0));
				}
			}
			else if(!bookmanager.MonsterLock[0]){	
				if(GUI.Button(new Rect((Screen.width/10)*1,(Screen.height/10)*2,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				              bookmanager.unlockTex)){
				}
			}
			
			if(bookmanager.MonsterLock[1]){
				if(GUI.Button(new Rect((Screen.width/10)*4,(Screen.height/10)*2,
			                       (Screen.width/10)*2,(Screen.height/10)*2),
			              bookmanager.MonsterTex[1])){
					bookmanager.StateChange(new Pet1Explanation(bookmanager,1));
				}
			}
			else if(!bookmanager.MonsterLock[1]){	
				if(GUI.Button(new Rect((Screen.width/10)*4,(Screen.height/10)*2,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				              bookmanager.unlockTex)){
				}
			}

			if(bookmanager.MonsterLock[2]){
				if(GUI.Button(new Rect((Screen.width/10)*7,(Screen.height/10)*2,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				                   bookmanager.MonsterTex[2])){
					bookmanager.StateChange(new Pet1Explanation(bookmanager,2));
				}
			}
			else if(!bookmanager.MonsterLock[2]){	
				if(GUI.Button(new Rect((Screen.width/10)*7,(Screen.height/10)*2,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				              bookmanager.unlockTex)){
				}
			}
			
			if(bookmanager.MonsterLock[3]){
				if(GUI.Button(new Rect((Screen.width/10)*1,(Screen.height/10)*5,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				                   bookmanager.MonsterTex[3])){
					bookmanager.StateChange(new Pet1Explanation(bookmanager,3));
				}
			}
			else if(!bookmanager.MonsterLock[3]){	
				if(GUI.Button(new Rect((Screen.width/10)*1,(Screen.height/10)*5,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				              bookmanager.unlockTex)){
				}
			}
			
			if(bookmanager.MonsterLock[4]){
				if(GUI.Button(new Rect((Screen.width/10)*4,(Screen.height/10)*5,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				                   bookmanager.MonsterTex[4])){
					bookmanager.StateChange(new Pet1Explanation(bookmanager,4));
				}
			}
			else if(!bookmanager.MonsterLock[4]){	
				if(GUI.Button(new Rect((Screen.width/10)*4,(Screen.height/10)*5,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				              bookmanager.unlockTex)){
				}
			}

			if(bookmanager.MonsterLock[5]){
				if(GUI.Button(new Rect((Screen.width/10)*7,(Screen.height/10)*5,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				                   bookmanager.MonsterTex[5])){
					bookmanager.StateChange(new Pet1Explanation(bookmanager,5));
				}
			}
			else if(!bookmanager.MonsterLock[5]){	
				if(GUI.Button(new Rect((Screen.width/10)*7,(Screen.height/10)*5,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				              bookmanager.unlockTex)){
				}
			}

			if(GUI.Button(new Rect((Screen.width/10)*8,(Screen.height/10)*9,
			                       (Screen.width/10)*2,(Screen.height/10)*1),
			              "メニューに戻る")){
				Time.timeScale = 0;
				Debug.Log("menu画面に遷移");
				bookmanager.StateChange(new MenuState(bookmanager));
			}
		}
	}
}
