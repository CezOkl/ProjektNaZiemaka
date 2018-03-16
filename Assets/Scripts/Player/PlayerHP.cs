using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour {

    public int playerHP;

	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            playerHP-=collision.gameObject.GetComponent<Damage>().damage;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            playerHP -= 25;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PowerUpHP")
        {
            playerHP += 25;
        }
    }
}
