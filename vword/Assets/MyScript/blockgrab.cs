using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockgrab : MonoBehaviour
{
    public OVRGrabbable grabbable;
    public bool isIns;//如果克隆出来一个，就不要继续克隆了
    public bool m_isGrabbed = false;
    public AudioSource soundHit;
    public GameObject CanvasEmpty;
    public Vector3 startPosition;
    public Vector3 startScale;
    public Quaternion startRotation;

    public GameObject Text;
    public string text;
    //public List lst;
    //ArrayList blockList = new ArrayList();


    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.gameObject.transform.localPosition;
        startScale = this.gameObject.transform.localScale;
        startRotation = Quaternion.identity;



        isIns = false;//是否是已经克隆脱离编程版的块，每个块只能拖一次。
        GameObject CanvasEmpty = GameObject.Find("CanvasEmpty");

        //-Text = new GameObject("nametext");
            
        // = RightHandAnchor.transform.childCount.ToString();
        //text = this.gameObject.name;

    }

  
    // Update is called once per frame
    void Update()
    {
        Detect();
    }

    public void Detect()
    {
        
            
        m_isGrabbed = grabbable.isGrabbed;
        //get blocks
        if (m_isGrabbed == true && isIns == false)
        {
           //soundHit.Play();
            isIns = true;
            //blockList.Add(this.gameObject.name);

            GameObject block = (GameObject)Instantiate(this.gameObject);
            //lst.Add(block.name); 
            //block.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
            block.transform.parent = CanvasEmpty.transform;
            block.transform.localScale = startScale;
            block.transform.localPosition = startPosition;
            block.transform.localRotation = startRotation;
                

            /*if (block.transform.GetChild(0) != null)
            {
                Destroy(block.t ransform.GetChild(0));
            }*/
            //-Text.transform.parent = block.transform;

            //-Text.AddComponent<TextMesh>();
            //-Text.GetComponent<TextMesh>().text = block.transform.GetChild(0).name;//block.name;
            //-Text.transform.localPosition = startPosition;
            //Vector3 localPosition = Text.transform.localPosition;
            //localPosition.y = startPosition.y - 0.1f;
            //-Text.transform.localPosition = new Vector3(0f, -1f, 0f);
            //-Text.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            //block.gameObject.AddComponent<OVRGrabbable>();
            //block.transform.localPosition = new Vector3(0.3f, 0f, -1f);

        }

    }



}
