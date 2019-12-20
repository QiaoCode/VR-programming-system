using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    // Start is called before the first frame update
    public bool SelectEnable = false;
    private bool InTirgger = false;
    public GameObject TouchObj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool handdown = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        bool indextouch = OVRInput.Get(OVRInput.Touch.PrimaryIndexTrigger, OVRInput.Controller.RTouch);

        if(handdown && (!indextouch))
        {
            SelectEnable = true;
        }
        else
        {
            SelectEnable = false;
        }

        if (SelectEnable)
        {
            transform.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        else
        {
            transform.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }

        if (InTirgger)
        {
            transform.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Selectable>() != null && (SelectEnable))
        {
            other.SendMessage("SelectObj");
        }
        InTirgger = true;
    }

    public void OnTriggerExit(Collider other)
    {
        InTirgger = false;
    }
}
