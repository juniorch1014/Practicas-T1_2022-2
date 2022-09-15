using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Knight_Program : MonoBehaviour
{

    GameManagerController gameManager;
    private int velocity   = 5;
    private int run_vel    = 10;
    private int jump_Force = 5;
    public GameObject shield;
    public AudioClip jumpClip;
    public AudioClip bulletClip;
    public AudioClip deadClip;
     public AudioClip coinsClip;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    AudioSource audioSource;

    const int Anima_Idle   = 0;
    const int Anima_Walk   = 1;
    const int Anima_Run    = 2;
    const int Anima_Attack = 3;
    const int Anima_Jump   = 4;
    const int Anima_jumpAttacK = 5;
    const int Anima_Dead   = 6;
    //bool Ani_Salto = false;
    int aux = 0;
    bool band = false;
    bool band1 = false;
    
    private Vector3 lastCheckpointPosition;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManagerController>();
        Debug.Log("Iniciando Script de Player");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

         if(band1 == false){
        //RightArrow + X
        if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.X)){
            rb.velocity = new Vector2(run_vel, rb.velocity.y);
            sr.flipX = false;
            ChangeAnimation(Anima_Run);
        }//LeftArrow + x
        else if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.X)){
            rb.velocity = new Vector2(-run_vel, rb.velocity.y);
            sr.flipX = true;
            ChangeAnimation(Anima_Run);
        }//RightArrow
        else if(Input.GetKey(KeyCode.RightArrow)){
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            sr.flipX = false;
            ChangeAnimation(Anima_Walk);
        }//LeftArrow
        else if(Input.GetKey(KeyCode.LeftArrow)){
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
            sr.flipX = true;
           ChangeAnimation(Anima_Walk);
        }//Z
        else if(Input.GetKey(KeyCode.Z)){
            ChangeAnimation(Anima_Attack);
        } 
        else{
          rb.velocity = new Vector2(0, rb.velocity.y);
          ChangeAnimation(Anima_Idle);
          
        }
        //Space
        if (Input.GetKeyDown(KeyCode.Space) && aux<2){
            //ChangeAnimation_Bool(Ani_Salto);
          
            rb.AddForce(new Vector2(0,jump_Force),ForceMode2D.Impulse);
           // Ani_Salto=true;
           audioSource.PlayOneShot(jumpClip);
            aux++;
     
        }
        if(aux==2){
            ChangeAnimation(Anima_Jump);
            
        } 
        //A
        if (Input.GetKeyUp(KeyCode.A)){
            //Crear escudo
            if(sr.flipX == false){
                var shieldPosition = transform.position + new Vector3(1,0,0);
                var gb = Instantiate(shield,
                                 shieldPosition,
                                 Quaternion.identity) as GameObject;
                var controller =gb.GetComponent<AttEsc_Controller>();
                controller.SetRightDirection();
            
            }
               if(sr.flipX == true){
                var shieldPosition = transform.position + new Vector3(-1,0,0);
                var gb = Instantiate(shield,
                                 shieldPosition,
                                 Quaternion.identity) as GameObject;
                var controller =gb.GetComponent<AttEsc_Controller>();
                controller.SetLeftDirection();
            }   
        }
        //C
        if (Input.GetKey(KeyCode.Q)){

            ChangeAnimation(Anima_jumpAttacK);
        }
    } else{
        rb.velocity = new Vector2(0, rb.velocity.y);
        ChangeAnimation(Anima_Dead);
    }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
       //ChangeAnimation_Bool(Ani_Salto);
       //Ani_Salto = false;
        aux=0;
        if(other.gameObject.name == "Dark"){
            if(lastCheckpointPosition != null){
                transform.position = lastCheckpointPosition;
            }   
        }
        if(other.gameObject.tag == "base"){
            aux = 3;
        }
        if(other.gameObject.tag == "shield" ){
            aux = 3;
        }
      
         
       
        //Debug.Log ("OnCollisionEnter2D");
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Trigger");
        if(other.gameObject.name == "Flecha_Cpoint" && band == false){
        lastCheckpointPosition = transform.position;
       
        }
        if(other.gameObject.name == "Cartel_Cpoint"){
        lastCheckpointPosition = transform.position;
            band = true;
        }
        // if(other.gameObject.name =="Paredes (3)"){
            
        //     if(gameManager.Coins()!=0){
        //     //Destroy(this.gameObject);
        //     gameManager.GanarCoin1();
        //     //scoreText.text = "Puntaje Modificado";
        //     }else{
        //         band1 = true;
        //         audioSource.PlayOneShot(deadClip);
        //         gameManager.DeleteGame();
        //         Destroy(this.gameObject,3);
        //         return;
                
        //     }
        // }
        if(other.gameObject.tag =="coin"){
           
            audioSource.PlayOneShot(coinsClip);
            gameManager.GanarCoin1(1);
            gameManager.SaveGame();
        }
        if(other.gameObject.tag =="coin2"){
            audioSource.PlayOneShot(coinsClip);
            gameManager.GanarCoin2(1);
            gameManager.SaveGame();
        }
      
    }

    private void ChangeAnimation(int animation){     
        animator.SetInteger("Estado",animation);
    }
    private void ChangeAnimation_Bool(bool animat_bool){
        animator.SetBool("Saltar",animat_bool);
    }
    
}
