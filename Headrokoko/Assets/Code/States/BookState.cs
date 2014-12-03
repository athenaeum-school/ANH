using UnityEngine;
using System.Collections;
using Assets.Code.Interfaces;

namespace Assets.Code.States{

	public class BookState : ISceneState {
		
		
		private BookStateManager bookmanager;
		
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
				bookmanager.pet1lock = true;
			}
			if(Input.GetKeyDown(KeyCode.F2)){
				Debug.Log("図鑑2をアンロック");
				bookmanager.pet2lock = true;
			}
			if(Input.GetKeyDown(KeyCode.F3)){
				Debug.Log("図鑑3をアンロック");
				bookmanager.pet3lock = true;
			}
			if(Input.GetKeyDown(KeyCode.F4)){
				Debug.Log("図鑑4をアンロック");
				bookmanager.pet4lock = true;
			}
			if(Input.GetKeyDown(KeyCode.F5)){
				Debug.Log("図鑑5をアンロック");
				bookmanager.pet5lock = true;
			}
			if(Input.GetKeyDown(KeyCode.F6)){
				Debug.Log("図鑑6をアンロック");
				bookmanager.pet6lock = true;
			}
		}
		
		public void Render(){
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),
			                bookmanager.BookBackgroundTex,
			                ScaleMode.StretchToFill);
			if(bookmanager.pet1lock){
				if(GUI.Button(new Rect((Screen.width/10)*1,(Screen.height/10)*2,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				              bookmanager.pet1tex)){
					bookmanager.StateChange(new Pet1Explanation(bookmanager));
				}
			}
			else if(!bookmanager.pet1lock){	
				if(GUI.Button(new Rect((Screen.width/10)*1,(Screen.height/10)*2,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				              bookmanager.unlockTex)){
				}
			}
			
			if(bookmanager.pet2lock){
				if(GUI.Button(new Rect((Screen.width/10)*4,(Screen.height/10)*2,
			                       (Screen.width/10)*2,(Screen.height/10)*2),
			              bookmanager.pet2tex)){
					bookmanager.StateChange(new Pet2Explanation(bookmanager));
				}
			}
			else if(!bookmanager.pet2lock){	
				if(GUI.Button(new Rect((Screen.width/10)*4,(Screen.height/10)*2,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				              bookmanager.unlockTex)){
				}
			}

			if(bookmanager.pet3lock){
				if(GUI.Button(new Rect((Screen.width/10)*7,(Screen.height/10)*2,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				                   bookmanager.pet3tex)){
					bookmanager.StateChange(new Pet3Explanation(bookmanager));
				}
			}
			else if(!bookmanager.pet3lock){	
				if(GUI.Button(new Rect((Screen.width/10)*7,(Screen.height/10)*2,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				              bookmanager.unlockTex)){
				}
			}
			
			if(bookmanager.pet4lock){
				if(GUI.Button(new Rect((Screen.width/10)*1,(Screen.height/10)*5,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				                   bookmanager.pet4tex)){
					bookmanager.StateChange(new Pet4Explanation(bookmanager));
				}
			}
			else if(!bookmanager.pet4lock){	
				if(GUI.Button(new Rect((Screen.width/10)*1,(Screen.height/10)*5,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				              bookmanager.unlockTex)){
				}
			}
			
			if(bookmanager.pet5lock){
				if(GUI.Button(new Rect((Screen.width/10)*4,(Screen.height/10)*5,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				                   bookmanager.pet5tex)){
					bookmanager.StateChange(new Pet5Explanation(bookmanager));
				}
			}
			else if(!bookmanager.pet5lock){	
				if(GUI.Button(new Rect((Screen.width/10)*4,(Screen.height/10)*5,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				              bookmanager.unlockTex)){
				}
			}

			if(bookmanager.pet6lock){
				if(GUI.Button(new Rect((Screen.width/10)*7,(Screen.height/10)*5,
				                       (Screen.width/10)*2,(Screen.height/10)*2),
				                   bookmanager.pet6tex)){
					bookmanager.StateChange(new Pet6Explanation(bookmanager));
				}
			}
			else if(!bookmanager.pet6lock){	
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
