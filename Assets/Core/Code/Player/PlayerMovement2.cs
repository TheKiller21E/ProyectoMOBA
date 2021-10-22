using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement2 : MonoBehaviour
{
    public NavMeshAgent jugador;

    [SerializeField]
    public float rotateSpeedmove = 0.075f;
    public float rotatevelocity;

    //private LayerMask mask;

    public GameObject Loock;

    CombatHero combatscript;

    void Start()
    {
        combatscript = GetComponent<CombatHero>();
       // mask = LayerMask.GetMask("Caminar");
        jugador = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (combatscript.TagetEnemy!=null)
        {
            if (combatscript.TagetEnemy.GetComponent<CombatHero>() != null)
            {
                if (!combatscript.TagetEnemy.GetComponent<CombatHero>().alive)
                {
                    combatscript.TagetEnemy = null;
                }
            }
        }

        if (Input.GetMouseButtonDown(1)) //boton izquierdo
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity/*, mask*/))
            {
                if (hit.collider.tag == "floor")
                {
                    //Movimiento
                    jugador.SetDestination(hit.point);
                    combatscript.TagetEnemy = null;
                    jugador.stoppingDistance = 0;

                    //Rotacion
                    Quaternion roationTolookAt = Quaternion.LookRotation(hit.point - transform.position);
                    float rotatey = Mathf.SmoothDampAngle(transform.eulerAngles.y, roationTolookAt.eulerAngles.y, ref rotatevelocity, rotateSpeedmove * (Time.deltaTime * 5));
                    transform.eulerAngles = new Vector3(0, rotatey, 0);

                    // el marcador
                    GameObject X;
                    X = Instantiate(Loock, hit.point, Loock.transform.rotation);
                    Destroy(X, 0.5f);
                }

            }
        }
        else if (Input.GetMouseButton(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity/*, mask*/))
            {
                if (hit.collider.tag == "floor")
                {
                    //Movimiento
                    jugador.SetDestination(hit.point);
                    combatscript.TagetEnemy = null;
                    jugador.stoppingDistance = 0;

                    //Rotacion
                    Quaternion roationTolookAt = Quaternion.LookRotation(hit.point - transform.position);
                    float rotatey = Mathf.SmoothDampAngle(transform.eulerAngles.y, roationTolookAt.eulerAngles.y, ref rotatevelocity, rotateSpeedmove * (Time.deltaTime * 5));
                    transform.eulerAngles = new Vector3(0, rotatey, 0);
                }
            }
        }
    }
}
