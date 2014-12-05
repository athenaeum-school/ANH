using UnityEngine;
using Assets.Code.States;
using Assets.Code.Interfaces;

public class BookStateManager : MonoBehaviour {

	public ISceneState actstate;

	//背景のテクスチャ
	public Texture2D MenuTex;
	public Texture2D BookBackgroundTex;

	//図鑑の各解説ページに遷移するためのボタンに使用するテクスチャ
	public Texture2D pet1tex;
	public Texture2D pet2tex;
	public Texture2D pet3tex;
	public Texture2D pet4tex;
	public Texture2D pet5tex;
	public Texture2D pet6tex;

	//各モンスターの解説画像に使用するテクスチャ
	public Texture2D pet1texExplanation;
	public Texture2D pet2texExplanation;
	public Texture2D pet3texExplanation;
	public Texture2D pet4texExplanation;
	public Texture2D pet5texExplanation;
	public Texture2D pet6texExplanation;

	//アンロック時に使用するテクスチャ
	public Texture2D unlockTex;

	//各モンスターのアンロックの管理フラグ
	public bool pet1lock = false;
	public bool pet2lock = false;
	public bool pet3lock = false;
	public bool pet4lock = false;
	public bool pet5lock = false;
	public bool pet6lock = false;

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
