using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_behavior : MonoBehaviour
{
    Begin_Encounter begin;
    Vector2 m_NewPosition;
    Vector2 zero_V;
    public GameObject player ;
    public GameObject monster ;
    public GameObject monster_area ;
    BoxCollider2D M_collision_enabled;
    private float turn;
    public float next_turn;
    Animator anim;
    private float inputTimer;
    private float GameTimer;
    public Renderer render;
    public bool sets=false;
    Next_turn_Act acces;
    SpriteRenderer sprRend;
    Renderer sprRend_AttackButton;
    public bool isattacked;
    UnitStats P_UnitStats;
    UnitStats M_UnitStats;

    void Start()
    { 

        begin=GameObject.Find("Control_Sprite").GetComponent<Begin_Encounter>();

        M_collision_enabled=monster_area.GetComponent<BoxCollider2D>();
        M_collision_enabled.enabled=false;

        isattacked=false;

        GameObject attackButton =GameObject.Find("AttackButton");
        sprRend_AttackButton=attackButton.GetComponent<Renderer>();

        M_UnitStats=monster.GetComponent<UnitStats>();
        P_UnitStats=player.GetComponent<UnitStats>();

        sprRend = GetComponent<SpriteRenderer> ();
        sprRend.flipX = true;
        render = monster.GetComponent<Renderer>();
        render.enabled = true;
        inputTimer = 0;
        anim = monster.GetComponent<Animator>();
        zero_V=new Vector2(0, 0);
        m_NewPosition = monster.transform.position;
        turn=1; 
        next_turn=1;       
        Debug.Log("Monster Position: "+m_NewPosition);
        GameObject button =GameObject.FindGameObjectWithTag("Next_turn_Button");
        acces=button.GetComponent<Next_turn_Act>();
        //acces.renderer_bool=false;
    }

    void Update()
    {
         if(next_turn>1)
         {

            if(turn<next_turn)
            {
                M_collision_enabled.enabled=true;
                render.enabled = false;
                monster.transform.position=zero_V;

                monster.transform.Translate(player.transform.position.x + 0.1f,player.transform.position.y,0);

                //sprRend_AttackButton.enabled=true;
                render.enabled = true;
                anim.Play("testanim");
                Debug.Log("Entered Animation: "+m_NewPosition);

                if(isattacked)
                {
                    P_UnitStats.health-=M_UnitStats.attack;
                    Debug.Log("Player Health: "+P_UnitStats.health);
                    M_UnitStats.is_attacked=true;
                    begin.bool_comfirm_attack=true;
                    Debug.Log("begin.bool_comfirm_attack=true; "+P_UnitStats.health);
                    isattacked=false;
                }

                Debug.Log("Turn now : "+turn);
                Debug.Log("next Turn : "+next_turn);
                turn++;
                sets=true;
            }

            if(turn==next_turn && sets)
            {
                inputTimer += Time.deltaTime;

                if(inputTimer>=2f)
                {
                    monster.transform.position=m_NewPosition;
                    anim.Play("Mini_monster_1");
                    Debug.Log(" Animation ended: "+m_NewPosition);
                    
                    
                    inputTimer=0;
                    sets=false;
                    acces.rend.enabled=true;
                }
            }
         }         
    }
}
