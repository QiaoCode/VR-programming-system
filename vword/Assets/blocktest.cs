using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocktest : MonoBehaviour
{

    //public GameObject ProObj;
    public bool hasTrigger = false;
    public AudioSource soundHit;
    public int list_idx;

    public Transform ProgramObj;
    public Transform[] Parents;

    public GameObject ProgramBlock;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject ProObj = ProgramObj;
        //if (this.gameObject.tag == "whentouch")
        //{

        //}

        Parents = transform.GetComponentsInParent<Transform>();
        for(int i=0; i<Parents.Length; i++)
        {
            if(Parents[i].tag == "ProgramObj")
            {
                ProgramObj = Parents[i];
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("add:" + other.tag);
        Vector3 otherscalle = other.transform.localScale;
        //soundHit.Play();
        if (hasTrigger == false)
        {//当有物体进入时，不再检测其他物体的进入

            if (other.tag == "whentouch")
            {
                ProgramObj.SendMessage("getIndex", list_idx, SendMessageOptions.DontRequireReceiver);
                ProgramObj.SendMessage("getBlock", "whentouch", SendMessageOptions.DontRequireReceiver);

                ProgramBlock = other.gameObject;
                //gameObject.GetComponent(“MyScript”).enabled = false;
            }

            else if (other.tag == "turnleft")
            {
                ProgramObj.SendMessage("getIndex", list_idx, SendMessageOptions.DontRequireReceiver);
                ProgramObj.SendMessage("getBlock", "turnleft", SendMessageOptions.DontRequireReceiver);
                ProgramBlock = other.gameObject;
            }

            else if (other.tag == "turnright")
            {
                ProgramObj.SendMessage("getIndex", list_idx, SendMessageOptions.DontRequireReceiver);
                ProgramObj.SendMessage("getBlock", "turnright", SendMessageOptions.DontRequireReceiver);
                ProgramBlock = other.gameObject;
            }
            else if (other.tag == "forward")
            {
                ProgramObj.SendMessage("getIndex", list_idx, SendMessageOptions.DontRequireReceiver);
                ProgramObj.SendMessage("getBlock", "forward", SendMessageOptions.DontRequireReceiver);
                ProgramBlock = other.gameObject;
            }

            hasTrigger = true;
        }

    }

    public void RemoveBlocks()
    {
        Destroy(ProgramBlock);
    }

    public void OnTriggerExit(Collider other)
    {
        //soundHit.Play();
        if (hasTrigger == true)
        {
            if (other.tag == "forward")
            {
                ProgramObj.SendMessage("getRemove", list_idx, SendMessageOptions.DontRequireReceiver);

            }
            else if (other.tag == "turnleft")
            {
                ProgramObj.SendMessage("getRemove", list_idx, SendMessageOptions.DontRequireReceiver);
            }
            else if (other.tag == "turnright")
            {
                ProgramObj.SendMessage("getRemove", list_idx, SendMessageOptions.DontRequireReceiver);
            }
            else if (other.tag == "whentouch")
            {
                ProgramObj.SendMessage("getRemove", list_idx, SendMessageOptions.DontRequireReceiver);
            }

            hasTrigger = false;
        }
    }

}