using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHero : MonoBehaviour
{
    public GameObject TagetEnemy;
    public enum HeroAttack { melee, ranged};
    [SerializeField]
    public HeroAttack heroAttack;

    [SerializeField]
    float attackranged;
    [SerializeField]
    float rotatespeedattack = 0.075f;

    PlayerMovement2 movescript;

    bool atckidle = false;
    public bool alive;
    [SerializeField]
    bool performattack = true;

    void Start()
    {
        movescript = GetComponent<PlayerMovement2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TagetEnemy != null)
        {
            if (Vector3.Distance(gameObject.transform.position,TagetEnemy.transform.position)>attackranged)
            {
                movescript.jugador.SetDestination(TagetEnemy.transform.position);
                movescript.jugador.stoppingDistance = attackranged;

                //Rotacion
                Quaternion roationTolookAt = Quaternion.LookRotation(TagetEnemy.transform.position - transform.position);
                float rotatey = Mathf.SmoothDampAngle(transform.eulerAngles.y, roationTolookAt.eulerAngles.y, ref movescript.rotatevelocity, rotatespeedattack * (Time.deltaTime * 5));
                transform.eulerAngles = new Vector3(0, rotatey, 0);
            }
            else
            {
                if (heroAttack==HeroAttack.melee)
                {
                    if (performattack)
                    {
                        Debug.Log("ataque");
                    }
                }
            }
        }
    }
}
