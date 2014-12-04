using UnityEngine;
using System.Collections;

public class FSM : MonoBehaviour 
{
	protected Transform playerTransform;
	protected Transform defensePoint;
	
	protected Vector3 destPos;
	
	protected GameObject[] pointList;
	
	protected float shootRate;
	protected float elapsedTime;
	
	public Transform turret { get; set; }
	public Transform bulletSpawnPoint { get; set; }
	
	protected virtual void Initialize() { }
	protected virtual void FSMUpdate() { }
	protected virtual void FSMFixedUpdate() { }
	
	void Start () 
	{
		Initialize();
	}
	
	void Update () 
	{
		FSMUpdate();
	}
	
	void FixedUpdate()
	{
		FSMFixedUpdate();
	}    
}