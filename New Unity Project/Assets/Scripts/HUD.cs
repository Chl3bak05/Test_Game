using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] Heart_Sprites;

    public Image HeartUI;

    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }
    void Update()
    {
        HeartUI.sprite = Heart_Sprites[player.cur_health];
    }
}
