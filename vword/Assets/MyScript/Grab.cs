using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
	public AudioSource soundThrown;
	public AudioSource soundHit;
	public AudioSource soundHit2;

	Vector3 startPosition = Vector3.zero;

	public GameObject pointMeter;

	Vector3 step;

	// Start is called before the first frame update
	void Start()
    {
		startPosition = transform.position;
		step = new Vector3(0, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 currentPosition = transform.position;
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.name == "Target")
		{
			soundHit.Play();
			Rigidbody rigidBody = GetComponent<Rigidbody>();
			rigidBody.position = startPosition;
			rigidBody.velocity = Vector3.zero;
			rigidBody.angularVelocity = Vector3.zero;

			pointMeter.transform.position = pointMeter.transform.position + step;
		}

		if (other.name == "Target2")
		{
			soundHit2.Play();
			Rigidbody rigidBody = GetComponent<Rigidbody>();
			rigidBody.position = startPosition;
			rigidBody.velocity = Vector3.zero;
			rigidBody.angularVelocity = Vector3.zero;

			pointMeter.transform.position = pointMeter.transform.position + step*2;
		}
	}

	//when objects are in the air
	public void OnTriggerExit(Collider other)
	{
		if ( other.name == "LeftHandAnchor" || other.name == "RightHandAnchor")
		{
			//soundThrown.Play();
		}
	}
	
}
