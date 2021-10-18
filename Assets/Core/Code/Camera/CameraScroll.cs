using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    // Start is called before the first frame update
    Camera cam;
    float camfov;
    float mousescroll;
    [SerializeField]
    float zoomspeed;

    void Start()
    {
        cam = GetComponent<Camera>();
        camfov = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        mousescroll = Input.GetAxis("Mouse ScrollWheel");
        camfov -= mousescroll * zoomspeed;
        camfov = Mathf.Clamp(camfov, 45,62);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, camfov, zoomspeed);
    }
}
