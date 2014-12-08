using UnityEngine;
using System.Collections;
using Assets.Code.Interfaces;

namespace Assets.Code.States{
	public class Pet1Explanation : ISceneState {
		
		private BookStateManager bookmanager;
		private GUIStyle TitleStyle;
		private GUIStyleState Titlestylestate;
		private GUIStyle SentenceStyle;
		private GUIStyleState SentenceStylestate;

		private int MonsterNum;
		public string[] Title = {"スライム","指つきスライム","人型スライム","有翼スライム","スライムブレイン","悟りスライム"};
		public string Sentence = "特に特殊能力もレアリティもないモンスター。" +"\n"+
			"たまたま引いたガチャから出てきて主人公をがっかりさせる";
		
		public Pet1Explanation(BookStateManager Bmanager,int num){
			bookmanager = Bmanager;
			MonsterNum = num;
			Time.timeScale = 0;
			TitleStyle = new GUIStyle();
			Titlestylestate = new GUIStyleState();
			SentenceStyle = new GUIStyle();
			SentenceStylestate = new GUIStyleState();

		}
		
		public void StateUpdate(){
			if(Input.GetKeyDown(KeyCode.Space)){
				Debug.Log("図鑑画面に遷移");
				bookmanager.StateChange(new BookState(bookmanager));
			}
		}
		
		public void Render(){
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),
			                bookmanager.ExplanationBackgroundTex,
			                ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect(0,-Screen.height/10 * 1,
			                         Screen.width,Screen.height),
			                bookmanager.MonsterTex[MonsterNum]);

			TitleStyle.fontSize = 30;
			TitleStyle.fontStyle = FontStyle.Bold;
			Titlestylestate.textColor = Color.blue;
			TitleStyle.normal = Titlestylestate;
			GUI.Label(new Rect(0,0,Screen.width/2,Screen.height/10),Title[MonsterNum],TitleStyle);

			SentenceStyle.fontSize = 15;
			SentenceStyle.fontStyle = FontStyle.Bold;
			SentenceStylestate.textColor = Color.white;
			SentenceStyle.normal = SentenceStylestate;
			GUI.Label(new Rect(0,Screen.height/10 * 7,Screen.width,Screen.height/10),Sentence,SentenceStyle);

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