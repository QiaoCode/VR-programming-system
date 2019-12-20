using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartProgramSignal : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform ProgramObj;
    public Transform[] Parents;
    void Start()
    {
        Parents = transform.GetComponentsInParent<Transform>();
        for (int i = 0; i < Parents.Length; i++)
        {
            if (Parents[i].tag == "ProgramObj")
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
        if (other.name == "RightHandAnchor")
        {
            //soundHit.Play();
            ProgramObj.SendMessage("StartProgram");

            // remove all program block
            Transform[] Children = transform.parent.GetComponentsInChildren<Transform>();
            for(int i=0; i<Children.Length; i++)
            {
                Children[i].SendMessage("RemoveBlocks");
            }
        }

    }
}
