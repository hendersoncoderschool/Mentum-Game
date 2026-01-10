using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D RB;
    private Vector2 InitVel = Vector2.zero;
    public bool Dash = false;
    public GameObject DashArrow;
    public Vector2 collisionPoint = Vector2.zero;
    private Vector2 mouseWorldPos;
    private float Speed = 0;
    private float Cooldown = 0;
    private float MaxCooldown = 0.4f;
    public bool Grounded = false;
    public GameObject Bomb;
    public float Charge = 0;
    public float MaxCharge;
    public LayerMask RaycastDetection;
    public float Strength = 10;
    private Vector3 SpawnPoint;
    private int CheckpointNum = 0;
    public bool CanControl = true;


    // Start is called before the first frame update

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        //mouseWorldPos.z = -10f;
    }


    // Update is called once per frame

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Cooldown > 0)
        {
            Cooldown -= Time.deltaTime;
            /*if (Cooldown == 0)
            {
                if Dash == false)
//                DashArrow.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 150);
            }*/
        }
        if (Dash == false)
        {
            DashArrow.GetComponent<SpriteRenderer>().material.color = new Color(Cooldown / MaxCooldown * -0.75f + 0.75f, Cooldown / MaxCooldown * -0.75f + 0.75f, Cooldown / MaxCooldown * -0.75f + 0.75f, 1);
        }
        else
        {
            DashArrow.GetComponent<SpriteRenderer>().material.color = new Color(Cooldown / MaxCooldown * -0.75f + 0.75f, Cooldown / MaxCooldown * -0.75f + 0.75f, Cooldown / MaxCooldown * -0.75f + 0.75f, .25f);
        }

        if (Cooldown <= 0)
        {
            // Left Click - Dash
            if (Input.GetMouseButtonDown(0) && CanControl)
            {
                if (Dash == false)
                {
                    Dash = true;
                    InitVel = RB.velocity;
                    if (Mathf.Abs(RB.velocity.x) +  Mathf.Abs(RB.velocity.y) < 0.5f)
                    {
                        RB.velocity = new Vector2(RB.velocity.x, 8);
                    }
                    else
                    {
                        RB.velocity = new Vector2(RB.velocity.x * Mathf.Abs(20 / (Mathf.Sign(RB.velocity.x) * 10 + ((RB.velocity.x / 2)))), RB.velocity.y * Mathf.Abs(20 / (Mathf.Sign(RB.velocity.y) * 10 + ((RB.velocity.y / 2)))));
                    }
                        Cooldown = MaxCooldown;
                }
            }
        }



        //print(RB.velocity);


        // Right Click - Velocity Change

        if (Input.GetMouseButtonUp(1) && CanControl)
        {
            // Get mouse position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Get angle of mouse to game object
            float angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg;

            // Get current speed of game object
            float speed = Mathf.Abs(RB.velocity.x) + Mathf.Abs(RB.velocity.y);

            float percent = 0;

            // top left
            if (angle > 90)
            {
                percent = (angle - 90) / 90;
                //print("percent: " + percent);
                RB.velocity = new Vector2(speed * percent * -1, speed * (1 - percent));
            }

            // top right
            else if (angle <= 90 && angle >= 0)
            {
                percent = angle / 90;
                //print("percent: " + percent);
                RB.velocity = new Vector2(speed * (1 - percent), speed * percent);
            }

            // bottom right
            else if (angle < 0 && angle >= -90)
            {
                percent = Mathf.Abs(angle / 90);
                //print("percent: " + percent);
                RB.velocity = new Vector2(speed * (1 - percent), speed * percent * -1);
            }
            // bottom left
            //else if (angle < -90)
            else
            {
                percent = Mathf.Abs((angle + 90) / 90);
                //print("percent: " + percent);
                RB.velocity = new Vector2(speed * percent * -1, speed * (1 - percent) * -1);
            }
        }



        // Resets Dash when on ground

        if (isColliding(collisionPoint))
        {
            Dash = false;
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }

        if (Input.GetKey("1") && CanControl)
        {
            Charge += Time.deltaTime;
            Charge += Time.deltaTime * MaxCharge / 2;
            if (Charge > MaxCharge)
            {
                Charge = MaxCharge;
            }
        }

        if (Input.GetKeyUp("1") && CanControl)
        {
            Transform spawnLocation = GameObject.Find("Arrow Flip").transform;
            GameObject newBomb = Instantiate(Bomb, spawnLocation.position, spawnLocation.rotation);
            newBomb.GetComponent<Rigidbody2D>().AddForce(newBomb.transform.up * Charge * 10, ForceMode2D.Impulse);          
            Charge = 0;
        }

        if (Input.GetKeyDown("2") && CanControl)
        {
            var Colliders = Physics2D.OverlapCircleAll(transform.position, 10f);
            Vector3 tempforce = Vector3.zero;
            float tempdistance = 0;
            float numColliders = 0;
            Vector3 velocityDirection = Vector3.zero;
            foreach (var col in Colliders)
            {
                //print(col.gameObject.tag);
                if (col.gameObject.tag == "Bomb")
                {
                    GameObject Bomb = col.gameObject;
                    Vector3 TargetDirection = transform.position - Bomb.transform.position;
                    float angle = Mathf.Atan2(TargetDirection.x, TargetDirection.y) * Mathf.Rad2Deg;
                    Quaternion TargetRotation = Quaternion.Euler(0, 0, angle * -1);
                    Bomb.transform.rotation = TargetRotation;
                    float distance = Vector2.Distance(Bomb.transform.position, transform.position);
                    tempdistance += distance / 10;
                    velocityDirection += Bomb.transform.up / distance;
                    numColliders += 1;

                    Debug.Log("Bomb: " + Bomb.transform.position.normalized);
                    Debug.Log("Position: " + transform.position.normalized);
                    Debug.Log("Distance: " + distance);

                    Vector3 PlayerPos = transform.position;
                    Vector3 BombPos = Bomb.transform.position;
                    Vector3 PlayerVel = RB.velocity;
                    float OldDist = Vector2.Distance(BombPos, PlayerPos);
                    float NewDist = Vector2.Distance(BombPos, PlayerPos + PlayerVel);
                    if (NewDist < OldDist)
                    {
                        Vector3 reflectedVector = Vector3.Reflect(RB.velocity, Bomb.transform.up);
                        tempforce += reflectedVector;
                    }
                    else
                    {         
                        tempforce += new Vector3 (RB.velocity.x, RB.velocity.y, 0);
                    }



                    Destroy(Bomb.gameObject);
                }
            }
            if (numColliders > 0)
            {
                //Debug.Log("After:"+ tempdistance);
                RB.velocity = tempforce;
                RB.AddForce(velocityDirection * Strength / (1 + (tempdistance / numColliders / 10)), ForceMode2D.Impulse);
                Dash = false;
                //Debug.Log(velocityDirection);
                //Debug.Log(tempdistance);
            }
        }
        if (Input.GetKeyDown("r") && CanControl)
        {
            transform.position = SpawnPoint;
            RB.velocity = Vector3.zero;
            RB.angularVelocity = 0;
        }
    }
        IEnumerator PauseGravity()
    {
        RB.gravityScale = 0;
        yield return new WaitForSeconds(0.4f);
        RB.gravityScale = 1;
        //RB.velocity = InitVel;
    }


    public bool isColliding(Vector2 collisionPoint)
    {
        return Physics2D.Raycast(transform.position, collisionPoint, 1f, RaycastDetection);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        Dash = false;
        collisionPoint = (collision.GetContact(0).point);
    }
    public void ChangeSpawnPoint(Vector3 NewSpawnPoint, int NewCheckpointPriority)
    {
        if (NewCheckpointPriority >= CheckpointNum)
        {
            SpawnPoint = NewSpawnPoint;
            CheckpointNum = NewCheckpointPriority;
        }
    }
} 