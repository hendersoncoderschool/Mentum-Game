using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SwitchPlatform : MonoBehaviour
{
    public bool SwitchPlatType;
    public Color Platform;
    private GameManagement GameManager;
    private SpriteShapeRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManagement>();
        spriteRenderer = GetComponent<SpriteShapeRenderer>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        Platform = spriteRenderer.color;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.SwitchState == SwitchPlatType)
        {
            Platform.a = 1;
            spriteRenderer.color = Platform;
            polygonCollider.enabled = true;
        }
        else
        {
            Platform.a = 0.1f;
            spriteRenderer.color = Platform;
            polygonCollider.enabled = false;
        }
    }
}
