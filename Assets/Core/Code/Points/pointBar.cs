using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointBar : MonoBehaviour
{
    public Slider _pointBar;
    public float _totalPoints = 1;
    public float _currentPoints;
    public bool _zoneWon;

    private void Update()
    {        
        if (_currentPoints <= _totalPoints)
        {
            _pointBar.value = _currentPoints;
        }
    }
}
