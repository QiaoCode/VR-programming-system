using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
	public AudioSource soundWin;

	public Vector3 startTargetPosition = Vector3.zero;
	// Start is called before the first frame update
	void Start()
	{
		startTargetPosition = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if(transform.position.y > 4.3f)
		{
			soundWin.Play();
			transform.position = startTargetPosition;
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.name == "WinMeter")
		{
			soundWin.Play();
			transform.position = startTargetPosition;
		}
	}
}
