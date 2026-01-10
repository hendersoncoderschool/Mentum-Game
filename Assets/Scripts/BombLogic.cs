using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public float Strength = 10;
    private AudioManager audioManager;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetKeyDown("2"))
        {
            var Colliders = Physics2D.OverlapCircleAll(transform.position, 10f);
            foreach (var col in Colliders)
            {
                //print(col.gameObject.tag);
                if (col.gameObject.tag == "Player")
                {
                    GameObject Player = col.gameObject;
                    Vector3 TargetDirection = Player.transform.position - transform.position;
                    //Vector3 NewDirection = Vector3.RotateTowards(transform.forward, TargetDirection, Time.deltaTime * 6.28f, 0f);
                    //transform.rotation = Quaternion.LookRotation(NewDirection);
                    float angle = Mathf.Atan2(TargetDirection.x , TargetDirection.y) * Mathf.Rad2Deg;
                    Quaternion TargetRotation = Quaternion.Euler(0, 0, angle*-1);
                    transform.rotation = TargetRotation;
                    float distance = Vector2.Distance(Player.transform.position, transform.position);
                    Player.GetComponent<Rigidbody2D>().velocity = Vector3.Reflect(Player.GetComponent<Rigidbody2D>().velocity, transform.up);
                    //print(Player.GetComponent<Rigidbody2D>().velocity);
                    Player.GetComponent<Rigidbody2D>().AddForce(transform.up * Strength / ( 1 + ( distance / 5 ) ), ForceMode2D.Impulse);
                    Player.GetComponent<PlayerInput>().Dash = false;
                    Debug.Log(transform.up * Strength / (1 + (distance / 5)));  
                    //print("Near Player");
                    audioManager.playSFX(audioManager.clip_badexplosion);
                    Destroy(gameObject);
                }
            }

        }*/
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 5);
    }
}

/*
                        GameObject Player = col.gameObject;
                    Vector3 TargetDirection = Player.transform.position - transform.position;
                    //Vector3 NewDirection = Vector3.RotateTowards(transform.forward, TargetDirection, Time.deltaTime * 6.28f, 0f);
                    //transform.rotation = Quaternion.LookRotation(NewDirection);
                    float angle = Mathf.Atan2(TargetDirection.x , TargetDirection.y) * Mathf.Rad2Deg;
                    Quaternion TargetRotation = Quaternion.Euler(0, 0, angle*-1);
                    transform.rotation = TargetRotation;
                    float distance = Vector2.Distance(Player.transform.position, transform.position);
                    Player.GetComponent<Rigidbody2D>().velocity = Vector3.Reflect(Player.GetComponent<Rigidbody2D>().velocity, transform.up);
                    print(Player.GetComponent<Rigidbody2D>().velocity);
                    Player.GetComponent<Rigidbody2D>().AddForce(transform.up * Strength / ( 1 + ( distance / 5 ) ), ForceMode2D.Impulse);
                    Player.GetComponent<PlayerInput>().Dash = false;
*/