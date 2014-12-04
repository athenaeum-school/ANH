using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public float gameSpeed = 1.0f;
	
	void Start () 
	{
		Physics.gravity = new Vector3(0, -500.0f, 0);
	}
	
	void Update () 
	{
		Time.timeScale = gameSpeed;
	}
}