using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Player : MonoBehaviour {

    public Animator animr;
    public Player player;

    // Use this for initialization
    void Start () {
        animr = gameObject.GetComponent<Animator>();
}
	
	// Update is called once per frame
	void Update () {
        
        //Setting Anim Values
        animr.SetBool("Grounded", player.grounded);
        animr.SetFloat("Speed", player.velocity_x);

        //Regulating animation speed depending on player velocity
        if (player.velocity_x >= 0.1f)
        {
            animr.speed = (player.velocity_x / 2.5f);
        }
        else
        {
            animr.speed = 1;
        }



    }
}
