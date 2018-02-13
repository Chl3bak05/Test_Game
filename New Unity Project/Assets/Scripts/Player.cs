using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float max_speed = 3;
    private float speed = 50f;
    public float jump_power = 300f;
    public float friction_value = 0.8f;
    public float velocity_x;

    public bool grounded;
    public bool Can_DJump;

    public int cur_health;
    public int max_health = 100;

    public Rigidbody2D rb2d_player;
    public GameObject player_spr;

    

    // Use this for initialization
    void Start ()
    {
        rb2d_player = gameObject.GetComponent<Rigidbody2D>();
        player_spr = GameObject.FindGameObjectWithTag("Player_spr");

        cur_health = max_health;
    }

    // Update is called once per frame
    void Update()
    {
        //Setting Horizontal velocity
        velocity_x = Mathf.Abs(rb2d_player.velocity.x);
        //Mirroring Player
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

                    rb2d_player.velocity = new Vector2(rb2d_player.velocity.x, 0);
                    rb2d_player.AddForce(Vector2.up * ((jump_power) * 0.8f));
                    Can_DJump = false;

                }
            }

        }
        if (grounded)
        {
            Can_DJump = true;
        }

        if (cur_health > max_health)
        {
            cur_health = max_health;
        }
        if (cur_health <= 0)
        {
            Kill_Player();
        }


    }

    void FixedUpdate()
    {
        //Fake friction
        Vector2 ease_Velocity = rb2d_player.velocity;
        ease_Velocity.x *= friction_value;
        ease_Velocity.y = rb2d_player.velocity.y;

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

    void Kill_Player()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

    public void Damage(int dmg)
    {
        if (cur_health < dmg)
        {
            dmg = cur_health;
        }
        cur_health -= dmg;

        player_spr.gameObject.GetComponent<Animation>().Play("RedFlashAnim");
    }
    public IEnumerator KnockBack(float knockDur, float knockBackPwr, Vector3 knockBackDir)
    {

        float timer = 0;
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            rb2d_player.velocity = new Vector2(0, 0);   //<----------------------
            rb2d_player.AddForce(new Vector3(knockBackDir.x * -100, knockBackDir.y * knockBackPwr, transform.position.z));

        }
        yield return 0;

    }
}

