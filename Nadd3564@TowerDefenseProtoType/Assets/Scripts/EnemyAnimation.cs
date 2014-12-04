using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour {
	Animator animator;
	Vector3 prePosition;
	Vector3 delta_position;

	void Start () {
		this.animator = GetComponent<Animator> ();
		SetPrePosition ();
	}
	
	void Update () {
		AnimatorSetSpdFloat ();
		SetPrePosition ();
	}

	public void SetPrePosition(){
		prePosition = transform.position;
	}

	public void AnimatorSetAtkBool(){
		this.animator.SetBool ("Attack", true);
	}

	public void AnimatorSetSpdFloat(){
		this.animator.SetFloat ("Speed", delta_position.magnitude / Time.deltaTime);
	}
}
