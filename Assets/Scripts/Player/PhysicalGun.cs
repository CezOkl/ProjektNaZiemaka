using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalGun : MonoBehaviour {

    Rigidbody rb;
    public int speed;
    float time = 10f;
    
	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward* speed;
        
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
        Debug.Log(rb.velocity);
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<SphereCollider>().isTrigger = false;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag=="Enemy")
        {
          //  collision.gameObject.GetComponent<SimpleEnemyHp>().DecreseHp();
        }
        else if (collision.gameObject.tag=="base")
        {

        }

        Destroy(this.gameObject);

    }
}
