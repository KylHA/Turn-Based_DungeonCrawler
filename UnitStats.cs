using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UnitStats : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

	private GameObject damageTextPrefab;

	private Vector2 damage_Text_Position;

	Monster_behavior monster_behav;
	GameObject monster;

	public GameObject a_button;
	AttackButton att;

	public float health;
	public float mana;
	public float attack;
	public float magic;
	public float defense;
	public float speed;
	public bool is_attacked;
	
	public int exprience;

	public bool dead = false;

	void Start()
	{
		monster=GameObject.Find("Enemy");
		monster_behav=monster.GetComponent<Monster_behavior>();
		a_button=GameObject.Find("AttackButton");
		att = a_button.GetComponent<AttackButton>();
	}

	void Update()
	{
		if (health<=0)
			dead=true;
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "Enemy")
        {
			att.other=true;
		}
		if (collision.gameObject.tag == "Enemy_area")
        {
			monster_behav.isattacked=true;
		}
		if (collision.gameObject.tag == "First_pos")
        {
			att.firts_pos=true;
		}
	}
}
