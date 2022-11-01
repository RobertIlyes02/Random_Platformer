using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    private float movementX;
    private float movementY;
    private float bearing;
    private SpriteRenderer sr;
    private Animator anim;
    public AudioSource audio;
    private float speed = 0.01f;
    private float directionX = 1f;
    private float directionY = 1f;
    public AnimationCurve movementcurve;
    private float times;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        times = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Move(45f);
        DetectEdges();
    }

    void Move(float angle)
    {
        speed = movementcurve.Evaluate(times);
        times += Time.deltaTime;
        movementX = Mathf.Cos(angle) * directionX;
        movementY = Mathf.Sin(angle) * directionY;
        transform.position += new Vector3(movementX, movementY, 0f) * (speed / 100);
        //Debug.Log(transform.position[0]);
        //Debug.Log(new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f));
    }

    void DetectEdges()
    {
        if (transform.position[0] > 8.5f || transform.position[0] < -8.5f)
        {
            directionX *= -1;
        } else if (transform.position[1] > 4.5f || transform.position[1] < -4.5f)
        {
            directionY *= -1;
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
        Destroy(this);
    }
}
