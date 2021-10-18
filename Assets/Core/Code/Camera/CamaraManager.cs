using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camaraoam))]
[RequireComponent(typeof(camara))]
[RequireComponent(typeof(CameraScroll))]
public class CamaraManager : MonoBehaviour
{
    Camaraoam camararoamscript;
    camara camarascript;
    bool camview;
    void Start()
    {
        camararoamscript=GetComponent<Camaraoam>();
        camarascript = GetComponent<camara>(); ;
        camview = true;
        camararoamscript.enabled = false;
        camarascript.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (camview == false)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                camview = true;
                camararoamscript.enabled = false;
                camarascript.enabled = true;
            }
        }
        else if (camview == true)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                camview = false;
                camararoamscript.enabled = true;
                camarascript.enabled = false;
            }
        }
    }
}
