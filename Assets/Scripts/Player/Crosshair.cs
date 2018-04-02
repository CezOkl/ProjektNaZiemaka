using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour {

   
    public Transform crosshair;
    public Image crosshairImage;
    public int crosshairDistance;
    public int maxDistance;
    RaycastHit hit;
    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        RayCrosshair();
        if (hit.transform != null)
        {
            if (hit.transform.tag =="Enemy")
            {
                crosshairImage.GetComponent<Image>().color = Color.red;
            }
            else
            {
                crosshairImage.GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            crosshairImage.GetComponent<Image>().color = Color.white;
        }
    }

    void RayCrosshair()
    {
    
        Physics.Raycast(this.gameObject.transform.position, Vector3.forward, out hit, maxDistance);
     
        Debug.DrawRay(this.gameObject.transform.position, transform.forward*maxDistance, Color.green);
       // Debug.Log(hit.point);
        crosshair.position = transform.position + transform.forward * crosshairDistance;
    }
}
