using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramBlock : MonoBehaviour
{
    public ArrayList BlockList = new ArrayList();
    public GameObject blockget;
    public GameObject block;
    public AudioSource soundHit;
    Vector3 startScale;
    public GameObject RightHandAnchor;

    public bool isTrigger;

    public bool flg;
    public string text;
    public int childnumber;
    // Start is called before the first frame update
    void Start()
    {
        isTrigger = false;
        flg = false;
        startScale = transform.localScale;
        GameObject RightHandAnchor = GameObject.Find("RightHandAnchor");
        text = GameObject.Find("Text").GetComponent<TextMesh>().text;
        // = RightHandAnchor.transform.childCount.ToString();
        childnumber = RightHandAnchor.transform.childCount;
        GameObject.Find("Text").GetComponent<TextMesh>().text = childnumber.ToString();
    }

   
    // Update is called once per frame
    void Update()
    {
        //DetectTrigger();
    }

    public void OnTriggerStay(Collider other)
    {

        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch) && other.name == "RightHandAnchor" && isTrigger == false)
        {
            isTrigger = true;//该物体被标记为克隆


            if (RightHandAnchor.transform.childCount - childnumber >= 1)
            {
                soundHit.Play();
                text = RightHandAnchor.transform.childCount.ToString();
                for (int i = 2; i < RightHandAnchor.transform.childCount; i++)
                {
                    GameObject block_old = RightHandAnchor.transform.GetChild(i).gameObject;
                    Destroy(block_old);
                }

                block = (GameObject)Instantiate(blockget);
                block.transform.parent = RightHandAnchor.transform;
                block.transform.localPosition = new Vector3(0f, 0f, 0f);
            }else if(RightHandAnchor.transform.childCount == childnumber){
                GameObject block = (GameObject)Instantiate(blockget);
                block.transform.parent = RightHandAnchor.transform;
                block.transform.localPosition = new Vector3(0f, 0f, 0f);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        /*
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch) && other.name == "RightHandAnchor" && isTrigger == true)
        {
            isTrigger = false;
            Destroy(block);
        }*/
        isTrigger = false;
    }


    public void DetectTrigger(){
        if(isTrigger == true)
        {
            GameObject block = (GameObject)Instantiate(blockget);
            block.transform.parent = RightHandAnchor.transform;
            //block.transform.position = new Vector3(0f, 0f, 0f);
        }
    }

    // if(isGrabble = true)

    // instantiate一个物体，讲物体设置成isGravity，再把grabble的脚本挂在上面
}
