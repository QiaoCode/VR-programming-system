using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform MainCameraLeft;
    public Transform MainCameraRight;
    public Transform MainCamera;
    public Transform MainCameraPosition;
    public Transform PairPortal;
    public Transform PairCamera;
    public Transform PairCameraLeft;
    public Transform PairCameraRight;
    public Transform OtherCamera;
    public float Angular;

    public bool HasEntrance = false;
    public bool EnterFromWrongDirection = false;

    public Vector2 Rotate(Vector2 v, float degrees)
    {
        float radians = degrees * Mathf.Deg2Rad;
        //float radians = degrees;
        float sin = Mathf.Sin(radians);
        float cos = Mathf.Cos(radians);

        float tx = v.x;
        float ty = v.y;

        return new Vector2(cos * tx - sin * ty, sin * tx + cos * ty);
    }

    void Start()
    {
        MainCamera = GameObject.Find("OVRCameraRig").transform;
        MainCameraLeft = GameObject.Find("LeftEyeAnchor").transform;
        MainCameraRight = GameObject.Find("RightEyeAnchor").transform;
        MainCameraPosition = GameObject.Find("CenterEyeAnchor").transform;
        PairCamera = transform.Find("PairCamera");
        PairCameraLeft = transform.Find("PairCameraLeft");
        PairCameraRight = transform.Find("PairCameraRight");
        OtherCamera = PairPortal.Find("PairCameraLeft");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MainPosition = MainCameraPosition.position; // global position
        Vector3 MainPositionLeft = MainCameraLeft.position;
        Vector3 MainPositionRight = MainCameraRight.position;

        Vector3 OffSet = MainPosition - PairPortal.position;
        Vector3 OffsetLeft = MainPositionLeft - PairPortal.position;
        Vector3 OffSetRight = MainPositionRight - PairPortal.position;

        Vector2 Offset2 = new Vector2(OffSet.x, OffSet.z);
        Vector2 OffSet2Left = new Vector2(OffsetLeft.x, OffsetLeft.z);
        Vector2 OffSet2Right = new Vector2(OffSetRight.x, OffSetRight.z);

        Angular = transform.rotation.eulerAngles.y - PairPortal.rotation.eulerAngles.y;

        Offset2 = Rotate(Offset2, -Angular);
        OffSet.x = Offset2.x;
        OffSet.z = Offset2.y;
        OffSet2Left = Rotate(OffSet2Left, -Angular);
        OffsetLeft.x = OffSet2Left.x;
        OffsetLeft.z = OffSet2Left.y;
        OffSet2Right = Rotate(OffSet2Right, -Angular);
        OffSetRight.x = OffSet2Right.x;
        OffSetRight.z = OffSet2Right.y;
        //OffSet = Quaternion.Inverse(PairPortal.forward * Quaternion.Inverse(transform.rotation)) * OffSet;

        Vector3 TargetPosition = transform.position - OffSet;
        TargetPosition.y = MainPosition.y;
        //PairCamera.transform.position = TargetPosition;

        Vector3 TargetPositionLeft = transform.position - OffsetLeft;
        TargetPositionLeft.y = MainPositionLeft.y;
        PairCameraLeft.transform.position = TargetPositionLeft;

        Vector3 TaregetPositionRight = transform.position - OffSetRight;
        TaregetPositionRight.y = MainPositionRight.y;
        PairCameraRight.transform.position = TaregetPositionRight;

        //Quaternion TargetRotation = Quaternion.Inverse(MainRotation);
        //PairCamera.transform.rotation = TargetRotation;

        Vector3 Rotation = MainCameraPosition.transform.rotation.eulerAngles;

        Rotation.y += (180f + (transform.rotation.eulerAngles.y - PairPortal.rotation.eulerAngles.y));
        //Rotation.z = Rotation.z - 180f;
        //PairCamera.transform.rotation = Quaternion.Euler(Rotation);
        PairCameraLeft.transform.rotation = Quaternion.Euler(Rotation);
        PairCameraRight.transform.rotation = Quaternion.Euler(Rotation);
    }

    public void Entrance()
    {
        if (EnterFromWrongDirection)
        {
            EnterFromWrongDirection = false;
            HasEntrance = false;
        }
        else
        {
            HasEntrance = true;
        }
    }

    public void Transport()
    {
        if (HasEntrance)
        {
            float Offset = (180f - (transform.rotation.eulerAngles.y - PairPortal.rotation.eulerAngles.y));
            Vector3 Rotation = MainCamera.rotation.eulerAngles;
            Rotation.y += Offset;
            MainCamera.rotation = Quaternion.Euler(Rotation);

            MainCamera.position = OtherCamera.position;
            //MainCamera.rotation = OtherCamera.rotation;

            /*
            Vector3 Rotation = MainCameraLeft.transform.rotation.eulerAngles;
            float OriginX = Rotation.x;
            Debug.Log("MainCameraRotation = " + Rotation);

            Rotation.y += (180f - (transform.rotation.eulerAngles.y - PairPortal.rotation.eulerAngles.y));
            //Debug.Log("Angle between two portal: " + (transform.rotation.eulerAngles.y - PairPortal.rotation.eulerAngles.y));
            MainCamera.transform.rotation = Quaternion.Euler(Rotation);
            */

            //Quaternion Rotation = MainCamera.rotation;
            //Rotation = Rotation * Quaternion.Euler(0, Offset, 0);
        }
        else
        {
            EnterFromWrongDirection = true;
        }
    }
}
