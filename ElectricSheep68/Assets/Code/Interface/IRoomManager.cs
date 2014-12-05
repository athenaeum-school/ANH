using System;

namespace roomstate{
	public interface IRoomManager{
		
		string SwitchState(IState istate);
		string FormatState();
		
	}
}

