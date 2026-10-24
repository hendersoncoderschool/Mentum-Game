using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoChangeColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    PlayerInput Player;
    [SerializeField] private List<Color> colors = new List<Color>();

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player").GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.PlayerMoChanges == Player.PlayerMaxMoChanges)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
            spriteRenderer.color = colors[Player.PlayerMoChanges];
        }
    }
}
