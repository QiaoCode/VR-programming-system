using UnityEngine;

public class Exit : MonoBehaviour
{
	// determines which controller should be used for locomotion
	public enum Controller { Left, Right };
	public Controller controller = Controller.Right;

	// the maximum movement speed in meters per second
	public float maxSpeed = 3.0f;

	// the deadzone is the area close to the center of the thumbstick
	public float moveDeadzone = 0.2f;

	OVRCameraRig cameraRig = null;

	// Start is called before the first frame update
	void Start()
	{
		// this script is meant to be used on the OVRCameraRig game object
		cameraRig = GetComponent<OVRCameraRig>();
	}

	// Update is called once per frame
	void Update()
	{
		// stores the x and y values of the thumbstick
		Vector2 thumbstickVector = new Vector2();

		// read the thumbstick values from either the right or left controller
		if (controller == Controller.Right)
			thumbstickVector = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
		else
			thumbstickVector = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);

		// if the thumbstick has been pushed outside the dead zone
		if (thumbstickVector.y > moveDeadzone || thumbstickVector.y < -moveDeadzone)
		{
			// COMPLETE THIS SECTION OF CODE




		}
	}
}
