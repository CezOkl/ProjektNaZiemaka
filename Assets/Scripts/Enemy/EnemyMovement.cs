using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField]Transform target;
    [SerializeField]float rotationalDamp = 0.5f;
    [SerializeField]float movementSpeed = 10f;
	[SerializeField]float detectionDistance = 20f;
	[SerializeField]float rayCastOffset = 1.5f;
    [SerializeField]GameObject bullet;
    float timer;
    public int nextbullet;
	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = nextbullet;
    }
	
	// Update is called once per frame
	void Update () {
       
        timer -= Time.deltaTime;
		Pathfinding ();
        FindTarget();
        //Turn();
        Move();
        ReadyToShoot();
	}

    void Turn()
    {
		Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
        
    }

	void Pathfinding()
	{

		RaycastHit hit;
		Vector3 raycastOffset = Vector3.zero;

		Vector3 left = transform.position - transform.right * rayCastOffset;
		Vector3 right = transform.position + transform.right * rayCastOffset;
		Vector3 up = transform.position + transform.up * rayCastOffset;
		Vector3 down = transform.position - transform.up * rayCastOffset;

		Debug.DrawRay (left, transform.forward * detectionDistance, Color.cyan);
		Debug.DrawRay (right, transform.forward * detectionDistance, Color.cyan);
		Debug.DrawRay (up, transform.forward * detectionDistance, Color.cyan);
		Debug.DrawRay (down, transform.forward * detectionDistance, Color.cyan);

	
		if (Physics.Raycast (left, transform.forward, out hit, detectionDistance))
		{
			raycastOffset += Vector3.right;
		}

		else if (Physics.Raycast (right, transform.forward, out hit, detectionDistance)) 
		{
			raycastOffset -= Vector3.right;
		}

		if (Physics.Raycast (up, transform.forward, out hit, detectionDistance))
		{
			raycastOffset -= Vector3.up;
		}

		else if (Physics.Raycast (down, transform.forward, out hit, detectionDistance)) 
		{
			raycastOffset += Vector3.up;
		}

		if (raycastOffset != Vector3.zero)
			transform.Rotate (raycastOffset * 5f * Time.deltaTime);
		else Turn ();



	}

    void FindTarget()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void ReadyToShoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, detectionDistance / 2))
        {
            Shooting();
        }
    }

    void Shooting()
    {
        if (timer <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timer = nextbullet;
        }
        

    }


}
