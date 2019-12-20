using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallIslandControl : MonoBehaviour
{
    public Vector3 LocalPosition;
    public GameObject LargerIsland_Prefab;
    public GameObject LargerIsland;
    public Transform ScaleReference;
    public Transform OtherPanel;
    public GameObject SmallerIsland_Prefab;
    public bool CreatedAnotherSmallIsland;
    public Vector3 GlobalPosition;
    public Vector3 PanelPosition;
    public Vector3 PanelScale;
    public Vector3 OriginPosition;
    public Vector3 OriginLocalPosition;
    public Quaternion OriginalRotation;
    public Vector3 LocalScale;
    public Vector3 OriginUp;

    private bool IsGrabbed;
    private bool HasMoved =  false;
    private Quaternion LocalRotation;
    // Start is called before the first frame update
    void Start()
    {
        LargerIsland = null;
        ScaleReference = GameObject.Find("ScaleReference").transform;
        OtherPanel = GameObject.Find("ControlPanel_Other").transform;
        OriginLocalPosition = transform.localPosition;
        CreatedAnotherSmallIsland = false;
        OriginPosition = transform.position;
        OriginalRotation = transform.localRotation;
        OriginUp = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        LocalPosition = transform.localPosition;
        GlobalPosition = transform.position;
        PanelPosition = OtherPanel.position;
        PanelScale = OtherPanel.lossyScale;
        PanelScale = PanelScale * 0.5f;

        // Create a new small island token if this one was moved out of the other panel
        if (!CreatedAnotherSmallIsland)
        {
            if (GlobalPosition.x < PanelPosition.x - PanelScale.x || GlobalPosition.x > PanelPosition.x + PanelScale.x
                || GlobalPosition.z < PanelPosition.z - PanelScale.z || GlobalPosition.z > PanelPosition.z + PanelScale.z)
            {
                GameObject NewIsland = GameObject.Instantiate(SmallerIsland_Prefab, OriginPosition, OriginalRotation, transform.parent);
                NewIsland.transform.localPosition = OriginLocalPosition;
                CreatedAnotherSmallIsland = true;
            }
        }

        // world in mini part: once the small rock is above the control panel, create a larger island and move as the small one moves

        if (Config.ProgramMode)
        {
            transform.localPosition = LargerIsland.transform.localPosition;
            transform.localRotation = LargerIsland.transform.localRotation;
        }
        else
        {
            if (LocalPosition.x > 0.6 || LocalPosition.x < -0.6 || LocalPosition.z > 0.6 || LocalPosition.z < -0.6)
            {
                // out of the boundar, disable the largeIsland
                if (LargerIsland != null)
                {
                    LargerIsland.SetActive(false);
                }
            }
            else
            {
                if (LargerIsland != null)
                {
                    LargerIsland.SetActive(true);
                }
                else
                {
                    // init one larger island
                    LargerIsland = GameObject.Instantiate(LargerIsland_Prefab, LocalPosition, OriginalRotation, ScaleReference);
                }
            }
            if (transform.tag == "Island")
            {
                LocalPosition.y = -0.15f;
            }
            else if (transform.tag == "Tree")
            {
                LocalPosition.y = 0f;
                transform.localRotation = OriginalRotation;
            }
            else if (transform.tag == "Chick")
            {
                LocalPosition.y = 0.06f;
                transform.localRotation = OriginalRotation;
            }

            LargerIsland.transform.localPosition = LocalPosition;
            if (transform.tag != "Chick")
            {
                LargerIsland.transform.localScale = transform.localScale;
            }
            LargerIsland.transform.localRotation = transform.localRotation;
        }
    }
}
