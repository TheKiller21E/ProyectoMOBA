using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput : MonoBehaviour
{
    public GameObject selectedhero;
    bool heroplayer;
    RaycastHit hit;

    void Start()
    {
        selectedhero = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider.GetComponent<Targetable>() != null)
                {
                    if (hit.collider.gameObject.GetComponent<Targetable>().enemytype == Targetable.EnemyType.minion)
                    {
                        selectedhero.GetComponent<CombatHero>().TagetEnemy = hit.collider.gameObject;
                    }
                }

                else if (hit.collider.GetComponent<Targetable>() == null)
                {
                    selectedhero.GetComponent<CombatHero>().TagetEnemy = null;
                }
            }
        }
    }
}
