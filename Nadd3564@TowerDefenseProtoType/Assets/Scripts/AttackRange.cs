using UnityEngine;
using System.Collections;

public class AttackRange : MonoBehaviour {

	Animator animator;

	void Start(){
		animator = GetComponentInParent<Animator>();
	}

	void OnTriggerStay(Collider other){
		if(IsEnemy(other.tag)){ 
			AnimatorSetAtkBool(true);
			transform.root.LookAt (other.transform.position);
		} else if (IsNotEnemy(other.tag))
			AnimatorSetAtkBool (false);
	}

	public bool IsEnemy(string tag){
		if(tag == "Enemy")
			return true;
		return false;
	}

	public bool IsNotEnemy(string tag){
		if (tag != "Enemy")
			return true;
		return false;
	}

	public void AnimatorSetAtkBool(bool flg){
		this.animator.SetBool ("Attack", flg);
	}

}