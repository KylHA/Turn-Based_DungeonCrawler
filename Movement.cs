using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{          
    private Rigidbody2D rb2d;       
    Animator anim;
    SpriteRenderer sprRend;
  
    
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer> ();
        rb2d = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
       UnitStats unitStats=this.GetComponent<UnitStats>();

      // speed = unitStats.speed;

        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector2 movement = new Vector2 (moveHorizontal, moveVertical); 
        
    //Debug.Log("Poz: "+movement);

  /*  if (movement.x<0)
    {
        sprRend.flipX = true;
    }

    if(movement.x>0)
    {
        sprRend.flipX = false;
        anim.Play("P_run");
    }*/

    
//|| Input.GetKeyDown(KeyCode.D)
        rb2d.AddRelativeForce (movement * unitStats.speed);
    }                
    void Update()
    {
        if (Input.GetKey(KeyCode.A) )
        {
            sprRend.flipX = true;
            anim.Play("P_run");
        }

        if (Input.GetKey(KeyCode.D) )
        {
            sprRend.flipX = false;
            anim.Play("P_run");
        }

        if(!(Input.anyKey))
        {
            anim.Play("Wait");
        }
        /* if(inputTimer >= 1f)
        {
            anim.Play("Wait");
        }*/    
    }
}
