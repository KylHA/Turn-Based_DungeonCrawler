using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next_turn_Act : MonoBehaviour
{
    Monster_behavior next_t;
    public Renderer rend;
    AttackButton attackButton;
    public GameObject attack_Button;
    public GameObject monster_area;
    BoxCollider2D M_collision_enabled;
    public GameObject monster;
    MonsterStatus m_status;
    void Start()
    {
        M_collision_enabled=monster_area.GetComponent<BoxCollider2D>();
        M_collision_enabled.enabled=false;

        rend = GetComponent<Renderer>();
        rend.enabled = true;
        monster =GameObject.FindGameObjectWithTag("Enemy");
        next_t=monster.GetComponent<Monster_behavior>();
        attackButton=attack_Button.GetComponent<AttackButton>();
        m_status=monster.GetComponent<MonsterStatus>();
        m_status.attack=false;
    }

    void FixedUpdate()
    {
        if(m_status.attack)
        {
        next_t.next_turn++;
        attackButton.ispressed=false;
        attackButton.isfinished=false;
        attackButton.other=false;
        attackButton.firts_pos=false;
        attackButton.flag=true;
        M_collision_enabled.enabled=true;
        next_t.isattacked=true;
        m_status.attack=false;
        }
    }

    void OnMouseDown()
    {
        next_t.next_turn++;
        attackButton.ispressed=false;
        attackButton.isfinished=false;
        attackButton.other=false;
        attackButton.firts_pos=false;
        attackButton.flag=true;
        M_collision_enabled.enabled=true;
        next_t.isattacked=true;
    }
}
