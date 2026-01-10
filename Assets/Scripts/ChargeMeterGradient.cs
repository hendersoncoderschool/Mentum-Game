using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeMeterGradient : MonoBehaviour
{
    public Gradient gradient;
    public float gradientPosition = 0f;

    private SpriteRenderer spriteRenderer;
    private float power = 0f;
    public float chargetime = 0f;
    private float MaxPower = 5f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = gradient.Evaluate(gradientPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
            power += Time.deltaTime;
            gradientPosition = Mathf.Clamp01(power / chargetime);
            spriteRenderer.color = gradient.Evaluate(gradientPosition);

        }
        else
        {
            power = 0f;
            gradientPosition = 0f;
            spriteRenderer.color = new Color(255, 255, 255, 0);
        }
    }
}
