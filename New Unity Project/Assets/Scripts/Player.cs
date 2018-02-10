using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float max_speed = 3;
    private float speed = 50f;
    public float jump_power = 300f;
    public float friction_value = 0.8f;
    public float velocity_x;

    public bool grounded;
    public bool Can_DJump;

    public Rigidbody2D rb2d_player;

    

    // Use this for initialization
    void Start ()
    {
        rb2d_player = gameObject.GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Setting Horizontal velocity
        velocity_x = Mathf.Abs(rb2d_player.velocity.x);
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
        if (Input.GetButtonDown("Jump"))
        {          
            if (grounded)
            {
                rb2d_player.AddForce(Vector2.up * jump_power);
                Can_DJump = true;
            }
            else
            {
                if (Can_DJump)
                {
                    Can_DJump = false;
                    rb2d_player.velocity = new Vector2(rb2d_player.velocity.x, 0); 
                    rb2d_player.AddForce(Vector2.up * ((jump_power)*0.8f));

                }
            }
                        
        }
    }

    void FixedUpdate()
    {
        //Fake friction
        Vector3 ease_Velocity = rb2d_player.velocity;
        ease_Velocity.x *= friction_value;
        ease_Velocity.y = rb2d_player.velocity.y;
        ease_Velocity.z = 0.0f;

        if (grounded)
        {
            rb2d_player.velocity = ease_Velocity;
        }



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
