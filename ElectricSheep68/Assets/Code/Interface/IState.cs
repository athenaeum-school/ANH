using UnityEngine;
namespace roomstate{
	public interface IState{
		void StateUpdate();
		void Render();
	}
}
