using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camaraoam : MonoBehaviour
{
    [SerializeField]
    float camspeed = 20;
    [SerializeField]
    float screensieThick = 20;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.mousePosition.y >= Screen.height - screensieThick)
        {
            pos.z += camspeed * Time.deltaTime;
        }

        if (Input.mousePosition.y <= screensieThick)
        {
            pos.z -= camspeed * Time.deltaTime;
        }

        if (Input.mousePosition.x <= screensieThick)
        {
            pos.x -= camspeed * Time.deltaTime;
        }   

        if (Input.mousePosition.x >= Screen.width - screensieThick)
        {
            pos.x += camspeed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
