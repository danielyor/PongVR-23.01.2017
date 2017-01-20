using UnityEngine;
using System.Collections;

public class AIscript : MonoBehaviour {

	Transform Ball;
	Transform RacketUp;
	public float speed;

	void Update () 
	{
		
		Ball = GameObject.FindGameObjectWithTag ("Ball").transform;
		RacketUp = GameObject.FindGameObjectWithTag ("RacketUp").transform;

		if (Ball.position.z > 0) {
			Debug.Log ("Ball Pos " + Ball.position.z);
			RacketUp.position = new Vector3(RacketUp.position.x, 1, Mathf.Lerp(RacketUp.position.z, Ball.position.z, speed*Time.deltaTime/5));
		}
		else if (Ball.position.z < 0) 
		{
			Debug.Log("Ball Pos " + Ball.position.z);
			RacketUp.position = new Vector3(RacketUp.position.x, 1, Mathf.Lerp(RacketUp.position.z, Ball.position.z, speed*Time.deltaTime/5));
		}
	}
}
