using UnityEngine;
using System.Collections;

public class AttackArea : MonoBehaviour {
	CharaStatus status;

	public AudioClip hitSeClip;
	AudioSource hitSeAudio;
	
	void Start()
	{
		status = transform.root.GetComponent<CharaStatus>();

		hitSeAudio = gameObject.AddComponent<AudioSource>();
		hitSeAudio.clip = hitSeClip;
		hitSeAudio.loop = false;
	}
	
	
	public class AttackInfo
	{
		public float attackPower; 
		public Transform attacker; 
	}
	
	
	AttackInfo GetAttackInfo()
	{			
		AttackInfo attackInfo = new AttackInfo();
		attackInfo.attackPower = status.Power;
		attackInfo.attacker = transform.root;

		return attackInfo;
	}
	
	void OnTriggerEnter(Collider other)
	{
		other.GetComponent<HitArea> ().Damage(5.0f);
	}
	
	
	void OnAttack()
	{
		collider.enabled = true;
	}

	void OnAttackTermination()
	{
		collider.enabled = false;
	}
}
