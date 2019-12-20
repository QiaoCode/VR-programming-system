using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMoveControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform MainCamera;
    public Transform ControlPanel;

    public Quaternion OrigRotation;
    public float OrigY;

    public bool IsGrabbed = false;
    public bool HasMoved = false;
    void Start()
    {
        MainCamera = GameObject.Find("OVRCameraRig").transform;
        ControlPanel = GameObject.Find("Control").transform;
        OrigRotation = transform.rotation;
        OrigY = MainCamera.localPosition.y;

        IsGrabbed = false;
        HasMoved = false;
    }

    // Update is called once per frame
    void Update()
    {
        IsGrabbed = transform.GetComponent<OVRGrabbable>().isGrabbed;

        if (IsGrabbed)
        {
            HasMoved = true;
        }
        else
        {
            if (HasMoved)
            {
                HasMoved = false;
                Vector3 Distance = MainCamera.position - ControlPanel.position;

                // move camera
                Vector3 NewPosition = transform.localPosition;
                NewPosition.y = OrigY;
                MainCamera.localPosition = NewPosition;

                // move control panel
                ControlPanel.position = MainCamera.position - Distance;
            }
            transform.localPosition = MainCamera.localPosition;
            transform.Translate(0, 0.12f, 0);
        }

        transform.rotation = OrigRotation;
    }
}
