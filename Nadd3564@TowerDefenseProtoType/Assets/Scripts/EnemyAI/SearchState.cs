using UnityEngine;
using System.Collections;

public class SearchState : FSMState
{
	public SearchState(Transform[] wp) 
	{ 
		waypoints = wp;
		stateID = FSMStateID.Searching;
		
		npcRotSpeed = 1.0f;
		npcSpeed = 0.5f;
	}
	
	public override void Reason(Transform player, Transform npc)
	{
		
		if (Vector3.Distance(npc.position, player.position) <= 2.0f)
		{
			Debug.Log("Switch to Attack State");
			npc.GetComponent<EnemyController>().SetTransition(Transition.ReachPlayer);
		}
	}
	
	public override void Act(Transform player, Transform npc)
	{
		if (Vector3.Distance(npc.position, destPos) <= 50.0f)
		{
			Debug.Log("Reached to the destination point\ncalculating the next point");
			FindNextPoint();
		}
		
		//ターゲットに回転
		Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
		npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * npcRotSpeed);
		
		//前進
		npc.GetComponent<CharaMove> ().SendMessage ("SetDestination", destPos);
	}
}