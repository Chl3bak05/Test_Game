using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Grounded : MonoBehaviour {

    public Anim_Player Anim_Player;

	// Use this for initialization
	void Start ()
    {
        Anim_Player.player = gameObject.GetComponentInParent<Player>();
	}
    //Sending grounded value to Anim_Player
    void OnTriggerEnter2D(Collider2D col)
    {
        Anim_Player.player.grounded = true;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        Anim_Player.player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Anim_Player.player.grounded = false;
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
