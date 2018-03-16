using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField]float movementSpeed = 50f;
	[SerializeField]float turnSpeed = 60f;
	Transform myT;

	void Awake()
	{
		myT = transform;
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Thrust ();
		Turn ();
	}


	void Turn()
	{
		float yaw = turnSpeed * Time.deltaTime * Input.GetAxis ("Horizontal");
		float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
		float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");
		myT.Rotate (-pitch, yaw, -roll);
	}

	void Thrust()
	{
		//if(Input.GetAxis("Vertical") > 0)
		myT.position += myT.forward * movementSpeed * Time.deltaTime;
	}
}
