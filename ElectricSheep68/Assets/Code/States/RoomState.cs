using UnityEngine;

namespace roomstate{
	public class RoomState : IState {
		private StateManager manager;
		
		public RoomState(StateManager stateManager) {
			//初期化
			manager = stateManager;
			Time.timeScale = 0;
		}
		public void StateUpdate(){
			
		}
		public void Render() {
			//描画等
			if(GUI.Button(new Rect(110, 100, 50, 50), "空腹" + manager.zeriData.zeriHungry)) { 
			}
			
		}
	}
}