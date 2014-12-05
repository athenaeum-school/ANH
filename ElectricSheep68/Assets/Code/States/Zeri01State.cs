using UnityEngine;

namespace roomstate{
public class Zeri01State : IState { 

		private StateManager manager;

		public Zeri01State(StateManager stateManager) {
			manager = stateManager;
			if (Application.loadedLevelName != "RoomScenen") {
				Application.LoadLevel("RoomScenen");
			}

			}
		public void StateUpdate() {
		
		}
		public void Render() {
			//描画等
			GUI.Box (new Rect(10,10,100,25), string.Format("おなか: "+ 
			                                               manager.zeriData.zeriHungry));
			}
		}
}

