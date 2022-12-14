using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrip_Megaman : MonoBehaviour
{   
    GameManagerController gameManager;
        
    private int run_vel    = 10;
    private int jump_Force = 5;
    private float timer = 0;
    public GameObject Bola1;
    public GameObject Bola2;
    public GameObject Bola3;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
       
    const int Anima_Idle   = 0;
    const int Anima_Run    = 1;
    const int Anima_Jump   = 2;
    const int Anima_Attack = 3; 
    const int Anima_Dead   = 4;
    const int Anima_Throw  = 5;
    const int Anima_Slide  = 6;
       

        //bool Ani_Salto = false;
    int aux = 0;
    int aux1 = 0;
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

    }

        // Update is called once per frame
    void Update()
    {

        //RightArrow + X
        if(Input.GetKey(KeyCode.RightArrow)){
            rb.velocity = new Vector2(run_vel, rb.velocity.y);
            sr.flipX = false;
            ChangeAnimation(Anima_Run);
        }//LeftArrow + x
        else if(Input.GetKey(KeyCode.LeftArrow)){
            rb.velocity = new Vector2(-run_vel, rb.velocity.y);
            sr.flipX = true;
            ChangeAnimation(Anima_Run);
        }//X
        else 
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            ChangeAnimation(Anima_Idle);
            
        }
            //Space
        if (Input.GetKeyUp(KeyCode.Space) && aux<2){
                
            rb.AddForce(new Vector2(0,jump_Force),ForceMode2D.Impulse);
            aux++;
        
            }
        if(aux==2){
            ChangeAnimation(Anima_Jump);
                
        } 
        //X
        if (Input.GetKey(KeyCode.X)){
            timer += Time.deltaTime;
            Debug.Log(timer);
            ChangeAnimation(Anima_Attack);
        }
            Disparar_Bom();
    }

        void OnCollisionEnter2D(Collision2D other)
        {
        //ChangeAnimation_Bool(Ani_Salto);
        //Ani_Salto = false;
            //aux=0;
            if(other.gameObject.name == "Dark"){
                if(lastCheckpointPosition != null){
                    transform.position = lastCheckpointPosition;
                }   
            }
            if(other.gameObject.name == "Tilemap"){
                aux = 0;
            }
            if(other.gameObject.tag == "base"){
                aux = 3;
            }
            
            if(other.gameObject.tag == "Bola1" ){
                aux = 3;
            }
            if(other.gameObject.tag == "Bola2" ){
                aux = 3;
            }
            if(other.gameObject.tag == "Bola3" ){
                aux = 3;
            }
            
        
            //Debug.Log ("OnCollisionEnter2D");
        }

        void OnTriggerEnter2D(Collider2D other){
           
            
           
        
        }

    private void Disparar_Bom(){
        if(sr.flipX == false){
               
            if(Input.GetKeyUp(KeyCode.X)){
                   
                 if(timer<3){
                    Debug.Log(aux1);
                    var shieldPosition = transform.position + new Vector3(1,0,0);
                    var gb = Instantiate(Bola1,
                            shieldPosition,
                            Quaternion.identity) as GameObject;
                    var controller =gb.GetComponent<Meg_AtaqueController>();
                    controller.SetRightDirection();
                    timer = 0;
                }
            }
            if(Input.GetKeyUp(KeyCode.X)){
                if(timer >= 3 && timer<5){
                    Debug.Log(aux1);
                    var shieldPosition = transform.position + new Vector3(1,0,0);
                    var gb = Instantiate(Bola2,
                            shieldPosition,
                            Quaternion.identity) as GameObject;
                    var controller =gb.GetComponent<Meg_AtaqueController>();
                    controller.SetRightDirection();
                    timer = 0;
                }
            }
            if(Input.GetKeyUp(KeyCode.X)){
                if(timer >=5){
                    Debug.Log(aux1);
                    var shieldPosition = transform.position + new Vector3(1,0,0);
                    var gb = Instantiate(Bola3,
                            shieldPosition,
                            Quaternion.identity) as GameObject;
                    var controller =gb.GetComponent<Meg_AtaqueController>();
                    controller.SetRightDirection();
                    timer = 0;
                }
            }
                    
        }
        if(sr.flipX == true){
                   
            if(Input.GetKeyUp(KeyCode.X)){
                   
                if(timer<3){
                    Debug.Log(aux1);
                    var shieldPosition = transform.position + new Vector3(-1,0,0);
                    var gb = Instantiate(Bola1,
                            shieldPosition,
                            Quaternion.identity) as GameObject;
                    var controller =gb.GetComponent<Meg_AtaqueController>();
                    controller.SetLeftDirection();
                    timer = 0;
                }
            }
            if(Input.GetKeyUp(KeyCode.X)){
                if(timer >= 3 && timer<5){
                    Debug.Log(aux1);
                    var shieldPosition = transform.position + new Vector3(-1,0,0);
                    var gb = Instantiate(Bola2,
                            shieldPosition,
                            Quaternion.identity) as GameObject;
                    var controller =gb.GetComponent<Meg_AtaqueController>();
                    controller.SetLeftDirection();
                    timer = 0;
                }
            }
            if(Input.GetKeyUp(KeyCode.X)){
                if(timer >=5){
                    Debug.Log(aux1);
                    var shieldPosition = transform.position + new Vector3(-1,0,0);
                    var gb = Instantiate(Bola3,
                            shieldPosition,
                            Quaternion.identity) as GameObject;
                    var controller =gb.GetComponent<Meg_AtaqueController>();
                    controller.SetLeftDirection();
                    timer = 0;
                }
            }
                    
        }
    }
    private void ChangeAnimation(int animation){     
        animator.SetInteger("Estado",animation);
    }
    private void ChangeAnimation_Bool(bool animat_bool){
        animator.SetBool("Saltar",animat_bool);
    }
        
}
