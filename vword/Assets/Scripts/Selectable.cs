using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Seleted = false;
    public GameObject SelectIndicator;
    public GameObject MyIndicator;
    public float OriginDistance = 0f;
    public Transform LeftHand;
    public Transform RightHand;
    private float ScaleFactor = 0.3f;

    private Vector3 OriginalRotationIndicator;
    private Quaternion LocalRotation;

    private bool IsGrabbed;
    void Start()
    {
        Seleted = false;
        LeftHand = GameObject.Find("LeftHandAnchor").transform;
        RightHand = GameObject.Find("RightHandAnchor").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Seleted && MyIndicator == null)
        {
            MyIndicator = GameObject.Instantiate(SelectIndicator, transform);
        }
        if((!Seleted))
        {
            Destroy(MyIndicator);
        }

        bool LeftHandDown = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        bool RightHandDown = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        IsGrabbed = transform.GetComponent<OVRGrabbable>().isGrabbed;

        if (Seleted && LeftHandDown && RightHandDown && (!IsGrabbed))
        {
            if(OriginDistance == 0f)
            {
                OriginDistance = Vector3.Distance(LeftHand.position, RightHand.position);
                OriginalRotationIndicator = LeftHand.position - RightHand.position;
            }

            // scale
            float DistanceChange = (Vector3.Distance(LeftHand.position, RightHand.position) - OriginDistance);
            Vector3 Scale = transform.localScale;
            float ScaleY = Scale.y;
            Scale = Scale * (1 + ScaleFactor * DistanceChange);
            Scale.y = ScaleY;
            transform.localScale = Scale;

            // rotation
            Vector3 NewRotationIndicator = LeftHand.position - RightHand.position;
            float RotationAngle = Vector2.SignedAngle(new Vector2(OriginalRotationIndicator.x, OriginalRotationIndicator.z), new Vector2(NewRotationIndicator.x, NewRotationIndicator.z));
            transform.Rotate(0, -RotationAngle, 0, Space.Self);
            LocalRotation = transform.localRotation;
            OriginalRotationIndicator = LeftHand.position - RightHand.position;
        }
        else
        {
            transform.localRotation = LocalRotation;
        }

        if(!LeftHandDown || (!RightHandDown))
        {
            OriginDistance = 0f;
        }
    }

    public void SelectObj()
    {
        if (Seleted)
        {
            DeSelect();
            return;
        }
            
        if (Config.SelectedObj != null)
        {
            Config.SelectedObj.SendMessage("DeSelect");
        }

        Seleted = true;
        Config.SelectedObj = gameObject;
    }

    public void DeSelect()
    {
        Seleted = false;
        Config.SelectedObj = null;
    }
}
