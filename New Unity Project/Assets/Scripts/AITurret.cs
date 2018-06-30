using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITurret : MonoBehaviour
{

    //Intigers
    public int curHealth;
    public int maxHealth;

    //Floats
    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;

    //Booleans
    public bool awake = false;
    public bool lookingRight = true;

    //References
    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft;
    public Transform shootPointRight;
    public Player player;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();

    }

    void Start()
    {
        curHealth = maxHealth;
    }

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < wakeRange)
        {
            awake = true;
        }

        if (distance > wakeRange)
        {
            awake = false;
        }

    }

    void DirectionCheck()
    {
        if (target.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        }
        else { lookingRight = false; }

    }

    void Update()
    {
        RangeCheck();
        DirectionCheck();


        anim.SetBool("Awake", awake);
        anim.SetBool("LookRight", lookingRight);

        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void Attack(bool attackingRight)
    {
        bulletTimer += Time.deltaTime;
       

        if (bulletTimer >= shootInterval)
        {
            float directionY = target.transform.position.y - transform.position.y + 0.5F;            


            if (!attackingRight )
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 , directionY) * bulletSpeed;

                bulletTimer = 0;
            }

            if (attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(1, directionY) * bulletSpeed;

                bulletTimer = 0;
            }
        }
    }

    public void Damage(int damage)
    {
        curHealth -= damage;
        gameObject.GetComponent<Animation>().Play("RedFlashAnim");
    }

}
