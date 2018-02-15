using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Player : MonoBehaviour {

    public Animator animr;
    public Player player;
    public GameObject player_spr;
 
    


    // Use this for initialization
    void Start () {
        animr = gameObject.GetComponent<Animator>();
        player = gameObject.GetComponentInParent<Player>();
        player_spr = GameObject.FindGameObjectWithTag("Player_spr");

    }
	
	// Update is called once per frame
	void Update () {
        
        //Setting Anim Values
        animr.SetBool("Grounded", player.grounded);
        animr.SetFloat("Speed", player.velocity_x);
        animr.SetBool("Dmg", player.hurt);

        //Regulating animation speed depending on player velocity
        if (player.velocity_x >= 0.1f && player.hurt == false)
        {
            animr.speed = (player.velocity_x / 2.5f);
        }
        else
        {
            animr.speed = 1;
        }
        


    }
}
