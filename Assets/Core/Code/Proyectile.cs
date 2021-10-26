using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{

    public int dmg;
    public GameObject target;

    public float velocity = 5;
    public bool stopProyectil;

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, velocity * Time.deltaTime);

            if (!stopProyectil)
            {
                if (Vector3.Distance(transform.position,target.transform.position)<0.5f)
                {
                    target.GetComponent<StatsPlayer>().Takedaño(dmg);
                    stopProyectil = true;
                    Destroy(gameObject);
                }
            }
        }
        else if (target==null)
        {
            Destroy(gameObject);
        }
    }
}
