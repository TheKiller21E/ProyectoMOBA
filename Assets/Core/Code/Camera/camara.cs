using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public Transform player;
    private Vector3 camerapos;

    [Range(0.1f, 1.0f)]
    public float smothe = 0.5f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        camerapos = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newpos = player.position + camerapos;
        transform.position = Vector3.Slerp(transform.position, newpos, smothe);
    }
}
