using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Program : MonoBehaviour
{
    private GameManagerController gameManager;

   // private int velocity   = 5;
    private int run_vel    = 10;
    private int jump_Force = 5;
    public GameObject shield;   
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
  //  bool Ani_Salto = false;
    int aux = 0;
    int aux1 = 0;
    
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
          
        
        
        if (Input.GetKeyUp(KeyCode.Space)&& aux<2){
            //ChangeAnimation_Bool(Ani_Salto);
            rb.AddForce(new Vector2(0,jump_Force),ForceMode2D.Impulse);

            aux++;
        }else{
            rb.velocity = new Vector2(run_vel, rb.velocity.y);
            ChangeAnimation(Anima_Run);
        }
        if (Input.GetKeyUp(KeyCode.A) && aux1<5){
            //Crear escudo
                var game = FindObjectOfType<GameManagerController>();
                
                var shieldPosition = transform.position + new Vector3(2,0,0);
                var gb = Instantiate(shield,
                                 shieldPosition,
                                 Quaternion.identity) as GameObject;
                var controller =gb.GetComponent<AttEsc_Controller>();
                controller.SetRightDirection(); 
               game.perderBala(5);
                aux1++;
        }
         if(aux==1){
            ChangeAnimation(Anima_Jump);
        } 
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
 
        aux=0;
        if(other.gameObject.name == "Dark"){
            if(lastCheckpointPosition != null){
                transform.position = lastCheckpointPosition;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Trigger");
        if(other.gameObject.tag == "pared"){
        rb.AddForce(new Vector2(0,jump_Force),ForceMode2D.Impulse);
        }
    }

    private void ChangeAnimation(int animation){     
        animator.SetInteger("Estado",animation);
    }
    private void ChangeAnimation_Bool(bool animat_bool){
        animator.SetBool("Saltar",animat_bool);
    }
    
}
