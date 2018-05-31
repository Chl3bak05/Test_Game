using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCone : MonoBehaviour {

    public AITurret AITurret;

    public bool isLeft = false;



    private void Awake()
    {
        AITurret = gameObject.GetComponentInParent <AITurret>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isLeft)
            {
                AITurret.Attack(false);
            }
            else
            {
                AITurret.Attack(true);
            }
        }

        
    }
}
