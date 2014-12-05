using UnityEngine;
using System;

namespace roomstate{
	
	[Serializable]
	public class StateManagerController{
		
		public IRoomManager statecontroller;
		public StateManager statemanager;
		
		public StateManagerController(){
			GameObject obj = new GameObject("ZeriData");
			statemanager = obj.AddComponent<StateManager>();
			Debug.Log (statemanager);
		}
		
		public void SetStateManagerController(IRoomManager statemanagercontroller){
			this.statecontroller = statemanagercontroller;
		}
		
		public string GetStateName(){
			string statename = statemanager.activeState.ToString();
			return statename;
		}
		
	}
}