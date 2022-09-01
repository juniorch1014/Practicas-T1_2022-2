using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Program : MonoBehaviour
{


    private int velocity   = 5;
    private int run_vel    = 10;
    private int jump_Force = 5;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    const int Anima_Idle   = 0;
    const int Anima_Walk   = 1;
    const int Anima_Run    = 2;
    const int Anima_Attack = 3;
    const int Anima_Jump   = 4;
    const int Anima_jumpAttacl = 5;
    const int Anima_Dead   = 6;
    bool Ani_Salto = true;
    
    private Vector3 lastCheckpointPosition;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Iniciando Script de Player");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
          
        if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.X)){
            rb.velocity = new Vector2(run_vel, rb.velocity.y);
            sr.flipX = false;
            ChangeAnimation(Anima_Run);
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.X)){
            rb.velocity = new Vector2(-run_vel, rb.velocity.y);
            sr.flipX = true;
            ChangeAnimation(Anima_Run);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            sr.flipX = false;
            ChangeAnimation(Anima_Walk);
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
            sr.flipX = true;
           ChangeAnimation(Anima_Walk);

        }else if(Input.GetKey(KeyCode.Z)){
            ChangeAnimation(Anima_Attack);
        } 
        else{
          rb.velocity = new Vector2(0, rb.velocity.y);
          ChangeAnimation(Anima_Idle);
          
        }
        if (Input.GetKey(KeyCode.Space) && Ani_Salto){
            //ChangeAnimation_Bool(Ani_Salto);
            ChangeAnimation(Anima_Jump);
            rb.AddForce(new Vector2(0,jump_Force),ForceMode2D.Impulse);
            Ani_Salto=false;
        }
        
      
          

        
    }

    void OnCollisionEnter2D( Collision2D other)
    {
       //ChangeAnimation_Bool(Ani_Salto);
        Ani_Salto = true;

        if(other.gameObject.name == "Dark"){
            if(lastCheckpointPosition != null){
                transform.position = lastCheckpointPosition;
            }
        }
        //Debug.Log ("OnCollisionEnter2D");
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Trigger");
        if(other.gameObject.name == "Checkpoint"){
        lastCheckpointPosition = transform.position;
        }
    }

    private void ChangeAnimation(int animation){     
        animator.SetInteger("Estado",animation);
    }
    private void ChangeAnimation_Bool(bool animat_bool){
        animator.SetBool("Saltar",animat_bool);
    }
    
}
