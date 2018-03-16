using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    

    public GameObject bullet;
    public float timer;
    public float _currentTime;
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

        if (_currentTime>=timer && Input.GetKeyDown(KeyCode.Space))
        {
            _currentTime = 0f;
            SpawnBullet();
        }
	}

    void SpawnBullet()
    {
        Instantiate(bullet, this.gameObject.transform.position,this.gameObject.transform.rotation);
    }
}
