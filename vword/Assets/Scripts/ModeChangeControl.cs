using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChangeControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Range;
    public GameObject LeftHandCanvas1;
    public GameObject LeftHandCanvas2;
    public Transform RightHandAnchor;
    public Transform ScaleReference;

    public Transform[] ChildrenList;

    private bool SentMessage = false;

    private bool EnableCanvas = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, Range.position) < 10f)
        {
            EnableCanvas = false;
            LeftHandCanvas1.SetActive(false);
            LeftHandCanvas2.SetActive(false);
            RightHandAnchor.GetComponent<OVRGrabber>().m_parentHeldObject = false;
            SentMessage = false;
            Config.ProgramMode = false;
        }
        else
        {
            EnableCanvas = true;
            LeftHandCanvas1.SetActive(true);
            LeftHandCanvas2.SetActive(true);
            RightHandAnchor.GetComponent<OVRGrabber>().m_parentHeldObject = true;
            ChildrenList = ScaleReference.GetComponentsInChildren<Transform>();
            if (!SentMessage)
            {
                for (int i = 0; i < ChildrenList.Length; i++)
                {
                    if (ChildrenList[i].GetComponent<ProObj>() != null)
                    {
                        ChildrenList[i].SendMessage("InitReferenceObj");
                    }
                }
                SentMessage = true;
            }
            Config.ProgramMode = true;
        }
    }
}
