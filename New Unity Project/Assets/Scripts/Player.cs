using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float max_speed = 3;
    public float speed = 50f;
    public float jump_power = 300f;

    public bool grounded;

    public Rigidbody2D rb2d_player;

    // Use this for initialization
    void Start ()
    {
        rb2d_player = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Limiting speed
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //Jumping
        if (Input.GetButtonDown("Jump") && grounded != false)
        {          
                rb2d_player.AddForce(Vector2.up * jump_power);           
        }
    }

    void FixedUpdate()
    {
        // Getting direction horizontal
        float h = Input.GetAxis("Horizontal");

        //Moving the player

        rb2d_player.AddForce((Vector2.right * speed) * h);

        // Limiting speed of player
        if (rb2d_player.velocity.x > max_speed)
        {
            rb2d_player.velocity = new Vector2(max_speed, rb2d_player.velocity.y);

        }

        if (rb2d_player.velocity.x < -max_speed)
        {
            rb2d_player.velocity = new Vector2(-max_speed, rb2d_player.velocity.y);
        }
    }
}
