using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteblock : MonoBehaviour
{
    public blockgrab blockgrab;
    public AudioSource soundHit;
   //public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //delete blocks
    public void OnTriggerStay(Collider other)
    {
        bool a = blockgrab.isIns;
        if(a == true)
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && other.name == "RightHandAnchor")
            {
                soundHit.Play();
                //a = false;
                this.gameObject.transform.localPosition = new Vector3(-100f, -100f, -100f);
                this.gameObject.SetActive(false);
            }
        }

    }
}
