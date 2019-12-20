using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pickup : MonoBehaviour
{
	OVRCameraRig cameraRig = null;
	public Vector3 startPosition = Vector3.zero;
	public Vector3 currentPosition = Vector3.zero;
	public Vector3 endPosition = Vector3.zero;
	public AudioSource soundWin;
	public AudioSource soundHit;
	private float dist;
	// Start is called before the first frame update
	void Start()
	{
		dist = 10;
		startPosition = transform.position;
		cameraRig = GetComponent<OVRCameraRig>();
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 currentPosition = transform.position;
		dist = Vector3.Distance(cameraRig.transform.localPosition, currentPosition);
		//startPosition = transform.position;
		//endPosition = startPosition + new Vector3(0, 2f, 0);

		//while (dist < 1f)
		//{
		//	soundWin.Play();
		//Destroy(gameObject);
		//	transform.position = endPosition;d
	}
    /*
	public void OnTriggerEnter(Collider other)
	{
			soundWin.Play();
			Destroy(gameObject);
	}*/
}
