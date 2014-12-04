using UnityEngine;
using System.Collections;

public class AttackAreaActivation : MonoBehaviour {
	Collider[] attackAreaColliders; 
	public AudioClip attackSeClip;
	AudioSource attackSeAudio;
	
	void Start () {
		AttackArea[] attackAreas = GetComponentsInChildren<AttackArea>();
		attackAreaColliders = new Collider[attackAreas.Length];
		
		for (int attackAreaCnt = 0; attackAreaCnt < attackAreas.Length; attackAreaCnt++) {
			attackAreaColliders[attackAreaCnt] = attackAreas[attackAreaCnt].collider;
			attackAreaColliders[attackAreaCnt].enabled = false;  
		}

		attackSeAudio = gameObject.AddComponent<AudioSource>();
		attackSeAudio.clip = attackSeClip;
		attackSeAudio.loop = false;
	}
	
	void StartAttackHit()
	{
		foreach (Collider attackAreaCollider in attackAreaColliders)
			attackAreaCollider.enabled = true;
	}

	void Attack()
	{
		foreach (Collider attackAreaCollider in attackAreaColliders)
			attackAreaCollider.enabled = true;
	}

	void EndAttackHit()
	{
		foreach (Collider attackAreaCollider in attackAreaColliders)
			attackAreaCollider.enabled = false;
	}
}
