using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPortalTexture : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera PairCamera;
    public Material PortalMaterial;
    void Start()
    {
        PairCamera = transform.Find("PairCamera").GetComponent<Camera>();
        if (PairCamera.targetTexture != null)
        {
            PairCamera.targetTexture.Release();
        }
        PairCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        transform.GetComponent<Material>().mainTexture = PairCamera.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
