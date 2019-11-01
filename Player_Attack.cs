using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
   public GameObject player ;
   public UnitStats unitStats;
   public GameObject stick ;
   BoxCollider2D collision_enabled;
   Animator anim;
   private float inputTimer;
   
   
    void Start()
    {
       inputTimer = 0;

       unitStats=player.GetComponent<UnitStats>();
       //Debug.Log("Text: " + unitStats.speed);

       stick=GameObject.Find("Stick");
       anim = player.GetComponent<Animator>();

       collision_enabled=stick.GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.J))
         {
            inputTimer += Time.deltaTime;

            anim.Play("FullAtttack");
            
            if(inputTimer >= 0.2f)
            {
                collision_enabled.enabled=true;

                if(inputTimer >= 0.22f)
                {
                    collision_enabled.enabled=false;
                    inputTimer = 0;     
                }
            }
         }
        
        if (Input.GetKeyUp(KeyCode.J))
        {
            inputTimer = 0;
            collision_enabled.enabled=false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           UnitStats e_unitStats = collision.gameObject.GetComponent<UnitStats>();
           e_unitStats.health -= unitStats.attack;

           if(e_unitStats.health <= 0)
           {
               unitStats.exprience+=e_unitStats.exprience;
               Destroy(collision.gameObject);
           }

           Debug.Log("Text: " + e_unitStats.health);
        }
    }
}
