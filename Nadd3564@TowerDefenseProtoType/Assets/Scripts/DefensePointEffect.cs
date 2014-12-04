using UnityEngine;
using System.Collections;

public class DefensePointEffect : MonoBehaviour {

	public float radius = 1.0f;
	public float angularVelocity = 480.0f;
	public Vector3 destination = new Vector3(0.0f, 0.5f, 0.0f);
	Vector3 position = new Vector3(.0f, 0.5f, 0.0f);
	float angle = 0.0f;

	void Start () {
		setPosition (transform.position);
		position = destination;
	}
	
	void Update () {
		position += (destination - position) / 10.0f;
		angle += angularVelocity * Time.deltaTime;
		Vector3 offset = Quaternion.Euler (0.0f, angle, 0.0f) * 
			new Vector3(0.0f, 0.0f, radius);
		transform.localPosition = position + offset;
	}

	public void setPosition(Vector3 pos){
		destination = pos;
		destination.y = 0.5f;
	}
}
