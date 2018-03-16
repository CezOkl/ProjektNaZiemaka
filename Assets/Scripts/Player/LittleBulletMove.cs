using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBulletMove : MonoBehaviour {

    public int speed;
    public float time;
    public ParticleSystem explosion;
   
	// Use this for initialization
	void Start () {

        this.gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
		
	}
	
	// Update is called once per frame
	void Update () {
        time = time - Time.deltaTime;
        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
           
            explosion.Play();
            explosion.enableEmission = true;
            Destroy(this.gameObject);
        }
    }
}
