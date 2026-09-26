using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteShapeAnimate : MonoBehaviour
{
    [SerializeField] public SpriteShape[]Shapes;
    public SpriteShapeController Controller;
    public float AnimSpeed;
    public float AnimFrame;
    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<SpriteShapeController>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimFrame += Time.deltaTime * AnimSpeed;
        AnimFrame = AnimFrame % Shapes.Length;
        Controller.spriteShape = Shapes[Mathf.FloorToInt(AnimFrame)];

        /*if (AnimFrame < 1)
        {
            Controller.spriteShape = Grass0;
        }
        else
        {
            if (AnimFrame < 2)
            {
                Controller.spriteShape = Grass1;
            }
            else
            
            {
                if (AnimFrame < 3)
                {
                    Controller.spriteShape = Grass2;
                }
                else
                {
                    Controller.spriteShape = Grass3;
                }
            }
        }*/
    }
}
