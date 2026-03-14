using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelEnter : MonoBehaviour
{
    public CameraTargetController Camera;
    public FadeTransition Fade;
    public float LevelNum;
    private int Transitioning = 0;
    // Start is called before the first frame update
    void Start()
    {
        Fade = GameObject.FindWithTag("Fade").GetComponent<FadeTransition>();
        //Need to get script
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        if (Transitioning == 1)
        {
            Player.transform.position += Vector3.up * Time.deltaTime * 40f;
            Player.transform.Rotate(1080*Time.deltaTime, 0 , 0);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Trigger Enter)");
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Starting Level Transition)");
            GameObject Player = col.gameObject;
            PlayerInput PlayerScript = Player.GetComponent<PlayerInput>();
            PlayerScript.CanControl = false;
            Rigidbody2D RB = Player.GetComponent<Rigidbody2D>();
            RB.velocity = Vector3.zero;
            //Player.transform.position = transform.position;
            StartCoroutine(LevelTransition());
            RB.angularVelocity = 0;
        }
    }

    IEnumerator LevelTransition()
    {
        Fade.fade = true;
        Debug.Log("Starting Coroutine)");
        GameObject Player = GameObject.FindWithTag("Player");
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        while (Vector2.Distance(Player.transform.position, transform.position) > 0.05f)
        {
            Player.transform.position = Vector2.MoveTowards(Player.transform.position, transform.position, 5f * Time.deltaTime);
            yield return null;
            Debug.Log("Running Coroutine)");
        }
        Camera.cutscene = true;
        Player.transform.rotation = Quaternion.Euler(90, 0, 0);
        Transitioning = 1;
    }
}
