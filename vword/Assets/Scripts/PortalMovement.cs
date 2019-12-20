using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 LocalPosition;
    public Quaternion OriginRotation;
    public float OriginalY;

    public GameObject LargerObject;
    void Start()
    {
        OriginRotation = transform.localRotation;
        OriginalY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        LocalPosition = transform.localPosition;
        if (LocalPosition.x > 0.6 || LocalPosition.x < -0.6 || LocalPosition.z > 0.6 || LocalPosition.z < -0.6)
        {
            LargerObject.SetActive(false);
        }
        else
        {
            LargerObject.SetActive(true);
        }
        transform.localRotation = OriginRotation;
        LocalPosition.y = OriginalY;
        LargerObject.transform.localPosition = LocalPosition;
        LargerObject.transform.localRotation = OriginRotation;
    }
}
