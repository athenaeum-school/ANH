using UnityEngine;
using System.Collections;

public class ApproachState : FSMState
{
	public ApproachState(Transform[] wp) 
	{ 
		waypoints = wp;
		stateID = FSMStateID.Approaching;
		
		npcRotSpeed = 1.0f;
		npcSpeed = 1.0f;
		
		FindNextPoint();
	}
	
	public override void Reason(Transform player, Transform npc)
	{
		destPos = player.position;
		
		float dist = Vector3.Distance(npc.position, destPos);
		if (dist <= 2.0f)
		{
			Debug.Log("Switch to Attack state");
			npc.GetComponent<EnemyController>().SetTransition(Transition.ReachPlayer);
		}
		else if (dist >= 2.1f)
		{
			Debug.Log("Switch to Search state");
			npc.GetComponent<EnemyController>().SetTransition(Transition.LostPlayer);
		}
	}
	
	public override void Act(Transform player, Transform npc)
	{
		destPos = player.position;
		
		Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
		npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * npcRotSpeed);
		
		npc.Translate(Vector3.forward * Time.deltaTime * npcSpeed);
	}
}