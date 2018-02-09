using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Grounded : MonoBehaviour {

    private Player player;

    // Use this for initialization
    void Start ()
    {
        player = gameObject.GetComponentInParent<Player>();
	}
    //Sending grounded value to Anim_Player
    void OnTriggerEnter2D(Collider2D col)
    {
        player.grounded = true;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player.grounded = false;
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
