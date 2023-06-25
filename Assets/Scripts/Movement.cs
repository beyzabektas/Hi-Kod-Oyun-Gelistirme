using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public AudioSource audioPlayer;
    public float speed;

    public Animator animator;

    private Animator anim;
    private Rigidbody2D myRigidbody;

    public Vector3 direction;
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

   
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!attacking)
        {
    
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        direction = new Vector3(horizontal,vertical);

        AnimateMovement(direction);

        if(Input.GetMouseButtonDown(0))
        {
            attackTimeCounter = attackTime;
            attacking = true;
            myRigidbody.velocity = Vector2.zero;
            anim.SetBool("Attack",true);
            audioPlayer.Play();
        }
        }

        if(attackTimeCounter >= 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if(attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attack",false);
        }
    }

    void FixedUpdate()
    {
        this.transform.position += direction.normalized * speed * Time.deltaTime;   
    }

    void AnimateMovement(Vector3 direction)
    {
        if(animator != null)
        {
            if(direction.magnitude > 0)
            {
                animator.SetBool("isMoving",true);
                animator.SetFloat("horizontal",direction.x);
                animator.SetFloat("vertical",direction.y);
            }
            else
            {
                animator.SetBool("isMoving",false);
            }
        }
    }

}
