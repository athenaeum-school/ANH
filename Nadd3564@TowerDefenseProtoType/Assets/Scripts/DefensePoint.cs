using UnityEngine;
using System.Collections;

public class DefensePoint : MonoBehaviour {
	public float hp = 3.0f;


	void Update(){
		TowerBreak ();
	}

	void OnTriggerEnter(Collider other){
		damage (other.tag);
	}

	void damage(string tag){
		if(tag == "enemyAttack")
			this.hp--;
	}

	void TowerBreak(){
		if(this.hp <= 0.0f)
			Destroy(this);
	}
}
