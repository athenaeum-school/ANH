using UnityEngine;
using System.Collections;

public class AttackState : FSMState
{
	public AttackState(Transform[] wp) 
	{ 
		waypoints = wp;
		stateID = FSMStateID.Attacking;
		npcRotSpeed = 1.0f;
		npcSpeed = 0.5f;
		FindNextPoint();
	}
	
	public override void Reason(Transform player, Transform npc)
	{
		//プレーヤーとの距離を確認
		float dist = Vector3.Distance(npc.position, player.position);
		if (dist >= 0.0f && dist < 2.0f)
		{
			//ターゲット地点に回転
			Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
			npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * npcRotSpeed);
			
			//前進
			npc.GetComponent<CharaMove> ().SendMessage ("SetDestination", destPos);
		}
		//距離が遠すぎる場合
		else if (dist >= 2.1f)
		{
			Debug.Log("Switch to Search State");
			npc.GetComponent<EnemyController>().SetTransition(Transition.LostPlayer);
		}  
	}
	
	public override void Act(Transform player, Transform npc)
	{
		//ターゲット地点をプレーヤーポジションに設定
		destPos = player.position;

		npc.GetComponent<EnemyAnimation> ().AnimatorSetAtkBool ();
	}
}