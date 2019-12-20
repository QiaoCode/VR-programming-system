using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ProgramObj;
    public Transform[] Parents;

    private Vector3 OriginDistance;
    private Quaternion OriginRotation;
    void Start()
    {
        OriginRotation = transform.rotation;

        Parents = transform.GetComponentsInParent<Transform>();
        for (int i = 0; i < Parents.Length; i++)
        {
            if (Parents[i].tag == "ProgramObj")
            {
                ProgramObj = Parents[i];
                break;
            }
        }

        OriginDistance = ProgramObj.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        
    }
}
