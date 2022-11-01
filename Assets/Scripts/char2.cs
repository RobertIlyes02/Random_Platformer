using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class char2 : MonoBehaviour
{
    private float movementX;
    private float movementY;
    private Rigidbody2D body;
    private SpriteRenderer sr;
    private Animator anim;
    public float movementspeed = 5f;
    private string walkstate = "Walk";
    public float animationspeed = 0.5f;
    public float jumpForce = 8f;
    private bool groundedstate = true;
    private bool justjumped = false;
    public AudioSource audio;
    private AudioClip slash_noise;
    private bool justslashed = false;
    private float FireRate = 1f;
    private float NextFire;
    public float testvariable = 0.5f;
    public int health = 5;
    private string directionstanding = "left";
    public LayerMask enemy;
    private int score;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (justjumped)
        {
            justjumped = false;
            PlayerJump();
        } else if (justslashed)
        {
            Attack();
            justslashed = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        AnimatePlayer();
        DetectJump();
        DetectAttack();
        Debug.DrawLine(transform.position, transform.position + new Vector3(2, 0, 0), Color.red);
        Debug.DrawLine(transform.position, transform.position + new Vector3(-2, 0, 0), Color.red);
        Debug.DrawLine(transform.position, transform.position + new Vector3(0, 0.5f, 0), Color.red);
        Debug.DrawLine(transform.position, transform.position + new Vector3(0, 0.5f, 0), Color.red);
        Debug.DrawLine(transform.position, transform.position + new Vector3(1, 0, 0), Color.blue);
    }

    void MovementInput()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * movementspeed;
    }

    void AnimatePlayer()
    {
        //anim.SetBool()
        if (movementX > 0)
        {
            directionstanding = "right";
            if (groundedstate && Time.time > NextFire-testvariable)
            {
                anim.Play("walk");
            }
            sr.flipX = true;
        } else if (movementX < 0)
        {
            directionstanding="left";
            if (groundedstate && Time.time > NextFire-testvariable)
            {
                anim.Play("walk");
            }
            sr.flipX = false;
        } else
        {
            //anim.Play("idle");
        }
    }

    void DetectJump()
    {
        if (Input.GetButtonDown("Jump") && groundedstate)
        {
            //anim.Play("jump");
            justjumped = true;
        }
    }

    void PlayerJump()
    {
        //anim.Stop("walk");
        anim.Play("jump");
        groundedstate = false;
        body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Debug.Log("ground");
            groundedstate = true;
        } else if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("enemy");
            //groundedstate = true;
        }
    }

    void DetectAttack()
    {
        if (Input.GetKeyDown("z") && Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            justslashed = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + new Vector3(-1, 0, 0), new Vector2(1.75f, 2));
    }

    void DetectAttackHit()
    {
        if (justslashed)
        {
            if (directionstanding == "right")
            {
                RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(2.5f, 3f), 0f, Vector3.right, 1f, enemy);
                if (hit)
                {
                    GameObject selectedobject = hit.collider.gameObject;
                    Debug.Log(selectedobject.name);
                    Debug.Log("hit");
                    enemy1 sn = selectedobject.GetComponent<enemy1>();
                    sn.Kill();
                    score += 1;
                    //KillCounter kc = new KillCounter();
                   // kc.updatescore(score);
                }
            }
            else
            {
                RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(2.5f, 3f), 0f, Vector3.left, 1f, enemy);
                if (hit)
                {
                    GameObject selectedobject = hit.collider.gameObject;
                    Debug.Log(selectedobject.name);
                    Debug.Log("hit");
                    enemy1 sn = selectedobject.GetComponent<enemy1>();
                    sn.Kill();
                    score += 1;

                    //KillCounter kc = new KillCounter();
                   // kc.updatescore(score);
                }
            }
        }
    }

    void Attack()
    {
        audio.Play();
        anim.Play("attack", -1, 0f);
        DetectAttackHit();
    }

}
