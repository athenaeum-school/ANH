using UnityEngine;
using System.Collections;

public class CharaStatus : MonoBehaviour {
	
	public float HP = 100.0f;
	public float MaxHP = 100.0f;
	public float Power = 10.0f;

	public string characterName = "Player";
	
	public bool attacking = false;
	public bool died = false;

	public float getHP(){
		return this.HP;	
	}

	public float DamageHP(float hp){
		return this.HP -= hp;	
	}
}
