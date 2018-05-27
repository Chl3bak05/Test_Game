using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    private Player player;
    private Anim_Player animn;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    //Action with spikes, collider
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.grounded = false;
            StartCoroutine(player.KnockBack(0.02f, 200, player.rb2d_player.velocity));
            
            player.Damage(1);
            player.grounded = false;


        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.grounded = false;
        }
    }
}
