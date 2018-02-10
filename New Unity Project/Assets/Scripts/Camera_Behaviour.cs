using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Behaviour : MonoBehaviour {


    private Vector2 velocity;

    public float smooth_time_x;
    public float smooth_time_y;


    private GameObject player;

    

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
	}
	

	void FixedUpdate ()
    {
        //Setting x & y position changes over time from current position to player position
        float pos_x = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smooth_time_x);
        float pos_y = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smooth_time_y);

        //Setting new camera position 
        transform.position = new Vector3(pos_x, pos_y, transform.position.z);
    }
}
