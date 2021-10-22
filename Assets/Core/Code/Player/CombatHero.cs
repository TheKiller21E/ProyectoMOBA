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
    StatsPlayer statsscript;
    Animator anim;

    bool atckidle = false;
    public bool alive;
    [SerializeField]
    public bool performattack = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        movescript = GetComponent<PlayerMovement2>();
        statsscript = GetComponent<StatsPlayer>();
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

                        //Rotacion
                        Quaternion roationTolookAt = Quaternion.LookRotation(TagetEnemy.transform.position - transform.position);
                        float rotatey = Mathf.SmoothDampAngle(transform.eulerAngles.y, roationTolookAt.eulerAngles.y, ref movescript.rotatevelocity, rotatespeedattack * (Time.deltaTime * 5));
                        transform.eulerAngles = new Vector3(0, rotatey, 0);

                        StartCoroutine(MeleeAtack());
                    }
                }
            }
        }
    }

    IEnumerator MeleeAtack()
    {
        performattack = false;
        anim.SetBool("BasicAtack",true);
        yield return new WaitForSeconds(1f);

        if (TagetEnemy==null)
        {
            anim.SetBool("BasicAtack", false);
            performattack = true;
        }
    }

    void attack()
    {
        if (TagetEnemy != null)
        {
            if (TagetEnemy.GetComponent<Targetable>().enemytype == Targetable.EnemyType.minion)
            {
                TagetEnemy.GetComponent<StatsPlayer>().Takedaño(statsscript.atackDmg);
            }
        }

        performattack = true;
    }
}
