using UnityEngine;
using System.Collections;

public class HitArea : MonoBehaviour {
	EnemyController enemy;

	void Start(){
		enemy = GetComponentInParent<EnemyController>();
	}

	public void Damage(float damage)
	{
		enemy.Damage (damage);
	}
}
