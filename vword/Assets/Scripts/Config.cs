using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject SelectedObj;
    public static bool ProgramMode = false;
    void Start()
    {
        SelectedObj = null;
    }

    private void Update()
    {
        
    }
}
