using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Player : MonoBehaviour {

    private Animator anim;
    public Player player;

    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        
        //Setting Anim Values
        anim.SetBool("Grounded", player.grounded);
        anim.SetFloat("Speed", Mathf.Abs(player.rb2d_player.velocity.x));
    }
}
