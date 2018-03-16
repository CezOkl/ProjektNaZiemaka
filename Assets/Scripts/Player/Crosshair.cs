using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    public Camera cam;
    public Transform crosshair;
    public int speed;

	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 screenPosition = cam.WorldToScreenPoint(transform.position);
        crosshair.transform.position = Vector3.Lerp(crosshair.transform.position, screenPosition, speed * Time.deltaTime);
	}

}
