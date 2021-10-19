using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointZone : MonoBehaviour
{
    public GameObject _pointBar;
    public bool _onZone;
    public float _points;
    public float _maxPoints;
    public int _playerNumber;
    // Start is called before the first frame update
    private void Start()
    {
        _pointBar.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (_onZone == true && Input.GetKey(KeyCode.E) && GetComponent<pointBar>()._currentPoints <= GetComponent<pointBar>()._totalPoints)
        {
            GetComponent<pointBar>()._currentPoints = GetComponent<pointBar>()._currentPoints + 0.09f * Time.deltaTime;
            Debug.Log(GetComponent<pointBar>()._currentPoints);
        }
        else
            return;        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("He entrado en la zona"); 
        _pointBar.SetActive(true);
        _onZone = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("He salido de la zona");
        _pointBar.SetActive(false);
        _onZone = false;
    }
}