using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanGun : MonoBehaviour {
    public int maxDistance;
    public GameObject littleBullet;
    public float timer;
   public  float _currentTime;
    

	// Use this for initialization
	void Start () {
        _currentTime = timer;
	}
	
	// Update is called once per frame
	void Update () {
        if (_currentTime <= timer)
        {
            _currentTime = _currentTime + Time.deltaTime;
        }

        if (_currentTime>=timer && Input.GetKeyDown(KeyCode.LeftControl))
        {
            _currentTime = 0;
            Fire();
        }

    }

    void Fire()
    {
        RaycastHit hit;
        Instantiate(littleBullet, this.gameObject.transform.position, this.gameObject.transform.rotation);

        if (Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.forward, out hit, maxDistance))
            {
                if (hit.collider.tag == "Enemy")
                {
                    
                   // hit.collider.GetComponent<SimpleEnemyHp>().DecreseHp();
                }
               
            }
            Debug.DrawLine(this.gameObject.transform.position, this.gameObject.transform.forward, Color.green, 1f);
        }
    
}
