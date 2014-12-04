using UnityEngine;
using System.Collections;


public class CharaMove : MonoBehaviour {

	const float GravityPower = 9.8f; 
	const float StoppingDistance = 0.6f;
	
	Vector3 velocity = Vector3.zero; 
	CharacterController characterController; 
	public bool arrived = false; 
	
	bool forceRotate = false;
	Vector3 forceRotateDirection;
	public Vector3 destination; 	
	public float walkSpeed = 6.0f;
	public float rotationSpeed = 360.0f;
	
	
	
	void Start () {
		characterController = GetComponent<CharacterController>();
		destination = transform.position;
	}



	void Update () {
		
		if (characterController.isGrounded) {
			Vector3 destinationXZ = destination; 
			destinationXZ.y = transform.position.y;

			Vector3 direction = (destinationXZ - transform.position).normalized;
			float distance = Vector3.Distance(transform.position,destinationXZ);
			
			Vector3 currentVelocity = velocity;
			
			if (lessThanStopDist(distance))
				arrived = true;
			
			CalcMoveVelocity(direction);

			velocity = Vector3.Lerp(currentVelocity, velocity,Mathf.Min (Time.deltaTime * 5.0f ,1.0f));
			velocity.y = 0;

			RotManager(direction);
			
		}
		
		velocity += Vector3.down * GravityPower * Time.deltaTime;
		
		Vector3 snapGround = Vector3.zero;
		if (characterController.isGrounded)
			snapGround = Vector3.down;
		
		characterController.Move(velocity * Time.deltaTime+snapGround);
		
		lessThanMagnitude ();
		
		forceRotStop ();
	}




	public bool lessThanStopDist(float distance){
		if (arrived || distance < StoppingDistance)
			return true;
		return false;
	}
	
	void CalcMoveVelocity(Vector3 direction){
		if (this.arrived)
			velocity = Vector3.zero;
		else 
			velocity = direction * walkSpeed;
	}

	void RotManager(Vector3 direction){
		if (!forceRotate) {
			if (velocity.magnitude > 0.1f && !arrived) { 
				Quaternion characterTargetRotation = Quaternion.LookRotation(direction);
				transform.rotation = Quaternion.RotateTowards(transform.rotation,characterTargetRotation,rotationSpeed * Time.deltaTime);
			}
		} else {
			Quaternion characterTargetRotation = Quaternion.LookRotation(forceRotateDirection);
			transform.rotation = Quaternion.RotateTowards(transform.rotation,characterTargetRotation,rotationSpeed * Time.deltaTime);
		}
	}

	void lessThanMagnitude(){
		if (characterController.velocity.magnitude < 0.1f)
			arrived = true;
	}
	
	void forceRotStop(){
		if (forceRotate && Vector3.Dot(transform.forward,forceRotateDirection) > 0.99f)
			forceRotate = false;
	}

	public void SetDestination(Vector3 destination)
	{
		arrived = false;
		this.destination = destination;
	}
	
	public void SetDirection(Vector3 direction)
	{
		forceRotateDirection = direction;
		forceRotateDirection.y = 0;
		forceRotateDirection.Normalize();
		forceRotate = true;
	}
	
	public void StopMove()
	{
		destination = transform.position; 
	}
	
	public bool Arrived()
	{
		return arrived;
	}
	
	
}
