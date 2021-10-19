using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointZone : MonoBehaviour
{
    public GameObject pointBar;
    // Start is called before the first frame update
    void Start()
    {
        pointBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("He entrado en la zona"); 
        pointBar.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("He salido de la zona");
        pointBar.SetActive(false);
    }
}
