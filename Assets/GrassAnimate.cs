using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.U2D;

public class GrassAnimate : MonoBehaviour
{
    [SerializeField] public SpriteShape Grass0, Grass1, Grass2, Grass3;
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
        AnimFrame = AnimFrame % 4;

        /&if (AnimFrame < 1)
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
        }
    }
}
