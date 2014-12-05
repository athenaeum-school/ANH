using UnityEngine;
using System.Collections;

namespace roomstate{
public class ZeriData : MonoBehaviour {
	
	private int initZeriHungry = 0;
	private int initZeriEvolvePoint;
	
	[HideInInspector]
	public int zeriHungry;
	[HideInInspector]
	public int zeriEvolvePoint;
	
	void Start() {
	}
	
	void Reset() {
		zeriHungry = initZeriHungry;
		zeriEvolvePoint = initZeriEvolvePoint;
	}
	
	public void SetZeriHungry(int hp) 
	{
		
	}
	
	public void SetZeriEvolve()
	{
		initZeriEvolvePoint = zeriEvolvePoint;
	}
}
}