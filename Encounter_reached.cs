using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter_reached : MonoBehaviour
{
    public bool can_attack;
    public int turn_Counter;
    public bool Encounter;
    
    PlayerStatus p_status;
    MonsterStatus m_status;

    UnitStats P_unitstats;
    UnitStats M_unitstats;

    void Start()
    {
        p_status=GameObject.Find("Pbody").GetComponent<PlayerStatus>();
        m_status=GameObject.FindGameObjectWithTag("Enemy").GetComponent<MonsterStatus>();
        
        P_unitstats=GameObject.Find("Pbody").GetComponent<UnitStats>();
        M_unitstats=GameObject.FindGameObjectWithTag("Enemy").GetComponent<UnitStats>();

        turn_Counter=1;
        can_attack=false;
        Encounter=false;
    }
  
    void Update()
    {
        Start_attack(turn_Counter,can_attack);

        if(Encounter)
            can_attack=true;
        if(Encounter==false)
            can_attack=false;

    }

    void Start_attack(int turn_Counter,bool can_attack)
    {
        if(can_attack)
        {
            if(turn_Counter <= 2)
            {   
                if(P_unitstats.speed < M_unitstats.speed)
                    m_status.attack=true;

                if(P_unitstats.speed >= M_unitstats.speed)
                    p_status.attack=true;

                if(p_status.attack && turn_Counter==2)
                    m_status.attack=true;

                if(m_status.attack && turn_Counter==2)
                    p_status.attack=true;
            }
        }
    }
}
