using UnityEngine;
using System.Collections;

namespace roomstate{
	public class StateManager : MonoBehaviour,IRoomManager
	{
		public IState activeState;
		public StateManagerController statecontroller;
		[HideInInspector]
		public ZeriData zeriData;
		public static StateManager instance;
		
		public void OnEnable(){
			statecontroller.SetStateManagerController(this);
		}
		
		void Awake()
		{
			if (instance == null) {
				instance = this;
				DontDestroyOnLoad (gameObject);
			} else { 
				DestroyImmediate (gameObject);                
			}
		}
		
		void OnGUI()
		{
			activeState.Render();
		}
		
		void Start()
		{
			activeState = new RoomState(this);
			Debug.Log("scene State " + activeState);
			zeriData = GetComponent<ZeriData> ();
		}
		void Update()
		{
			if(activeState != null)
				activeState.StateUpdate();
		}
		public string SwitchState(roomstate.IState newState)
		{
			activeState = newState;
			return activeState.ToString();
		}
		public string FormatState(){
			return statecontroller.GetStateName();
		}
	}
}