using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPlayer : MonoBehaviour
{
    [SerializeField]
    float vida = 0;

    //Stadisticas
    [SerializeField]
    int MaxVida = 100;
    //float healthRegen = 0.1f;
    int defensa = 0;
    [SerializeField]
    public int atackDmg = 10;
    [SerializeField]
    public int atackSpeed = 1;
    public int Speed = 1;

    CombatHero combatscript;

    void Start()
    {
        combatscript = GetComponent<CombatHero>();
        vida = MaxVida;
    }

    // Update is called once per frame
    void Update()
    {
        if (vida<=0)
        {
            Destroy(gameObject);
        }

        /*if (vida<MaxVida)
        {
            vida = vida + healthRegen;
        }
        else
        {
            vida = MaxVida;
        }*/
    }

    public void Takedaño(float dmg)
    {
        dmg = dmg - defensa;
        vida = vida - dmg;
        Debug.Log(vida + " he recibido daño");
    }

    void curar(float amt)
    {
        vida = vida + amt;
    }
}
