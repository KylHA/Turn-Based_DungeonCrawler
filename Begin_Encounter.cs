using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin_Encounter : MonoBehaviour
{
    Encounter_reached reached;
    public bool finish_Encounter;
    public bool bool_comfirm_attack;
    
    PlayerStatus p_status;
    MonsterStatus m_status;

    UnitStats P_unitstats;
    UnitStats M_unitstats;
    GameObject controlButtons;

    public Renderer rend;

    void Start()
    {
        //controlButtons=GameObject.FindGameObjectWithTag("controlButtons");
       // rend=controlButtons.GetComponent<Renderer>();

        p_status=GameObject.Find("Pbody").GetComponent<PlayerStatus>();
        m_status=GameObject.FindGameObjectWithTag("Enemy").GetComponent<MonsterStatus>();

        P_unitstats=GameObject.Find("Pbody").GetComponent<UnitStats>();
        M_unitstats=GameObject.FindGameObjectWithTag("Enemy").GetComponent<UnitStats>();

        reached=this.GetComponent<Encounter_reached>();

        //reached.Encounter=true;
        finish_Encounter=false;
        bool_comfirm_attack=false;
    }

    void Update()
    {
        if((P_unitstats.is_attacked||M_unitstats.is_attacked)&&(bool_comfirm_attack)&&(!finish_Encounter))
            {
                reached.turn_Counter++;
                bool_comfirm_attack=false;
            }
        if(P_unitstats.dead||M_unitstats.dead)
            finish_Encounter=true;
        
    }
}