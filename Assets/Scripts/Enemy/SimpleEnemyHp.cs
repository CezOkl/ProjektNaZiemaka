using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyHp : MonoBehaviour {

    public int HP;
    public int hitPower;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hitPower = collision.gameObject.GetComponent<Damage>().damage;
            DecreseHp();
        }
    }
    public void DecreseHp()
    {
        HP = HP - hitPower;
    }
}
