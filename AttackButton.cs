using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    Begin_Encounter begin;
    public GameObject monster_area;
    public GameObject player;
    public GameObject monster;
    public bool ispressed;
    public Renderer rend;
    public bool isfinished;
    public bool other;
    Animator anim;
    SpriteRenderer sprRend;
    public bool flag;
    public bool firts_pos;

    BoxCollider2D collision_enabled;
    BoxCollider2D M_collision_enabled;
    public GameObject stick ;

    private Rigidbody2D rb2d;
    Vector2 movement;
    
    private float moveHorizontal;
    UnitStats P_unitStats;
    UnitStats M_unitStats;

    private float inputTimer;
    // Start is called before the first frame update
    void Start()
    {
        begin=GameObject.Find("Control_Sprite").GetComponent<Begin_Encounter>();
        collision_enabled=stick.GetComponent<BoxCollider2D>();
        collision_enabled.enabled=false;

        M_collision_enabled=monster_area.GetComponent<BoxCollider2D>();
        M_collision_enabled.enabled=false;

        inputTimer = 0;
        flag=true;
        other=false;
        isfinished=false;
        ispressed=false;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        firts_pos=false;

        P_unitStats=player.GetComponent<UnitStats>();
        anim = player.GetComponent<Animator>();
        sprRend=player.GetComponent<SpriteRenderer>();

        rb2d = player.GetComponent<Rigidbody2D> ();
        M_unitStats=monster.GetComponent<UnitStats>();

        
        movement = new Vector2 (1f, 0); 
    }

 
    void FixedUpdate()
    {
        if( isfinished != true)
        {
            if(!other && ispressed)
            {
                rb2d.AddRelativeForce (movement * P_unitStats.speed);
                anim.Play("P_run");
                firts_pos=false;
            }

            if(other && ispressed)
            {
                collision_enabled.enabled=true;
                //Debug.Log("Entered: other, ispressed");
                if(inputTimer>=1.5f)
                {
                    if(flag==true)
                    {
                    sprRend.flipX = true;
                    M_unitStats.health -= P_unitStats.attack*3;
                    Debug.Log("Player hit for "+P_unitStats.attack*3+" Damage"+"/Remaining Monster Health "+M_unitStats.health);
                    
                    flag=false;
                    }
                    if(!firts_pos)
                    {
                        rb2d.AddRelativeForce (movement * P_unitStats.speed * -1);
                        anim.Play("P_run");
                    }
                    else if(firts_pos)
                    {
                        sprRend.flipX = false;
                        P_unitStats.is_attacked=true;
                        begin.bool_comfirm_attack=true;
                        other = false;
                        anim.Play("Wait");
                        collision_enabled.enabled=false;
                        inputTimer=0f;
                        isfinished= true;
                    }
                }

                if(flag)
                    anim.Play("FullAtttack");

                inputTimer += Time.deltaTime;
            }
        }
    }
    void Update()
    {
        if(ispressed)
        {
            rend.enabled=false;
        }
        else if(!ispressed)
        {
            rend.enabled=true;
        }
        
        if(M_unitStats.dead)
        {
            Destroy(monster);
        }
        if(P_unitStats.dead)
        {
            Debug.Log("Player is Dead Game Over");
            Destroy(player);
        }
    }
    void OnMouseDown()
    {
        ispressed=true;
        other=false;
        M_collision_enabled.enabled=false;
    }
}
