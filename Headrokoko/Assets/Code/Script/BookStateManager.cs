using UnityEngine;
using Assets.Code.States;
using Assets.Code.Interfaces;

public class BookStateManager : MonoBehaviour {

	public ISceneState actstate;

	//背景のテクスチャ
	public Texture2D MenuTex;
	public Texture2D BookBackgroundTex;

	//図鑑の各解説ページに遷移するためのボタンに使用するテクスチャ
	public Texture2D[] MonsterTex;

	//各モンスターの解説画像に使用するテクスチャ
	public Texture2D[] MonsterExplanation;

	//アンロック時に使用するテクスチャ
	public Texture2D unlockTex;

	//各モンスターのアンロックの管理フラグ
	public bool[] MonsterLock;
	void OnGUI(){
		actstate.Render();
	}
	// Use this for initialization
	void Start () {
		BookStateManagerInit();
	}
	
	// Update is called once per frame
	void Update () {
		if(actstate != null){
			actstate.StateUpdate();
			Debug.Log(actstate + "実行中");
		}	
	}

	public void StateChange(ISceneState newstate){
		actstate = newstate;
		Debug.Log(newstate + "に遷移");
	}

	public void BookStateManagerInit(){
		actstate = new MenuState(this);
	}
}
