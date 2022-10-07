using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Ninja : MonoBehaviour
{
    GameManager_Ninja gameManager_Ninja;
        
    private int run_vel    = 10;
    private int jump_Force = 5;
    private float timer = 0;
    private int random = 0;
    public GameObject Bola1;
    public GameObject Bola2;
    public GameObject Bola3;
    public GameObject Kunai;
    public GameObject Espada;
    
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
    public int i = 0;
    bool band = false;
    bool bandDis = false;
    
        
    private Vector3 lastCheckpointPosition;
        // Start is called before the first frame update
    void Start()
    {
        gameManager_Ninja = FindObjectOfType<GameManager_Ninja>();
        Debug.Log("Iniciando Script de Player");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

        // Update is called once per frame
    void Update()
    {   //**Teclas
        Num_Random();
        // if(band==false){
        // //RightArrow
        // if(Input.GetKey(KeyCode.RightArrow)){
        //     rb.velocity = new Vector2(run_vel, rb.velocity.y);
        //     sr.flipX = false;
        //     ChangeAnimation(Anima_Run);
        // }//LeftArrow
        // else if(Input.GetKey(KeyCode.LeftArrow)){
        //     rb.velocity = new Vector2(-run_vel, rb.velocity.y);
        //     sr.flipX = true;
        //     ChangeAnimation(Anima_Run);
        // }
        // else 
        // {
        //     rb.velocity = new Vector2(0, rb.velocity.y);
        //     ChangeAnimation(Anima_Idle);
            
        // }
        // //Space
        // if (Input.GetKeyUp(KeyCode.Space) && aux<2){
                
        //     rb.AddForce(new Vector2(0,jump_Force),ForceMode2D.Impulse);
        //     aux++;
        
        //     }
        // if(aux==2){
        //     ChangeAnimation(Anima_Jump);
                
        // } 
        // //Q
        // if (Input.GetKey(KeyCode.Q)){

        //     ChangeAnimation(Anima_Slide);
        // }
        // //X
        // if (Input.GetKey(KeyCode.X)){
        //     timer += Time.deltaTime;
        //     Debug.Log(timer);
        //     ChangeAnimation(Anima_Attack);
        // }
        //     Disparar_Bom();
        // }
    }

    void OnCollisionEnter2D(Collision2D other)
        {
        //******************************************
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

             if(other.gameObject.tag == "zombie"){
                if(gameManager_Ninja.Live()>=0){
                    gameManager_Ninja.PerdeLive(1);
                }
                if(gameManager_Ninja.Live()==-1){
                    ChangeAnimation(Anima_Dead);
                     Destroy(this.gameObject,3);
                     band = true;
                }
                
            }
        
            //Debug.Log ("OnCollisionEnter2D");
    }

    void OnTriggerEnter2D(Collider2D other){
           
            if(other.gameObject.tag =="coin"){
           
                gameManager_Ninja.GanarPuntos(10);
                //gameManager.SaveGame();
        }
           
        
    }
    //Teclas
    private void Disparar_Bom(){
        if(sr.flipX == false){
               
            if(Input.GetKeyUp(KeyCode.X)){
                   
                 if(timer<3){
                    Debug.Log(aux1);
                    var shieldPosition = transform.position + new Vector3(1,0,0);
                    var gb = Instantiate(Bola1,
                            shieldPosition,
                            Quaternion.identity) as GameObject;
                    var controller =gb.GetComponent<Ninja_AtaqueController>();
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
                    var controller =gb.GetComponent<Ninja_AtaqueController>();
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
                    var controller =gb.GetComponent<Ninja_AtaqueController>();
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
                    var controller =gb.GetComponent<Ninja_AtaqueController>();
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
                    var controller =gb.GetComponent<Ninja_AtaqueController>();
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
                    var controller =gb.GetComponent<Ninja_AtaqueController>();
                    controller.SetLeftDirection();
                    timer = 0;
                }
            }
                    
        }
    }
    private void Contador(){
        timer += Time.deltaTime;
        Debug.Log(timer);
        ChangeAnimation(Anima_Attack);
    }
    //**Random************************
    private void Num_Random(){
        random = Random.Range(0,3);
        Debug.Log("R: "+ random);
    }

    public void ChangeAnimation(int animation){     
        animator.SetInteger("EstadoNinja",animation);
    }
    private void ChangeAnimation_Bool(bool animat_bool){
        animator.SetBool("Saltar",animat_bool);
    }
    //botones
    public void derecha(){
            rb.velocity = new Vector2(run_vel, rb.velocity.y);
            sr.flipX = false;
            ChangeAnimation(Anima_Run);
    }
    public void izquierda(){
            rb.velocity = new Vector2(-run_vel, rb.velocity.y);
            sr.flipX = true;
            ChangeAnimation(Anima_Run);
    }
    public void stop(){
        rb.velocity = new Vector2(0, rb.velocity.y);
        ChangeAnimation(Anima_Idle);
    }
    public void saltar(){
            if (aux<2){
            rb.AddForce(new Vector2(0,jump_Force),ForceMode2D.Impulse);
            aux++;
            }
    }
    public void disparar(){
        if(bandDis==false){
           
            if(sr.flipX == false){
                 
                    Debug.Log(aux1);
                    var shieldPosition = transform.position + new Vector3(1,0,0);
                    var gb = Instantiate(Kunai,
                            shieldPosition,
                            Quaternion.identity) as GameObject;
                    var controller =gb.GetComponent<Ninja_AtaqueController>();
                    controller.SetRightDirection();
                        
            }
            if(sr.flipX == true){
                    Debug.Log(aux1);
                    var shieldPosition = transform.position + new Vector3(-1,0,0);
                    var gb = Instantiate(Kunai,
                            shieldPosition,
                            Quaternion.identity) as GameObject;
                    var controller =gb.GetComponent<Ninja_AtaqueController>();
                    controller.SetLeftDirection();
                    
            }
        ChangeAnimation(Anima_Throw);
        }
        //Espada
        if(bandDis==true){
            Debug.Log("cambio");
            if(sr.flipX == false){
                    
                    Debug.Log(aux1);
                    var espadaPosition = transform.position + new Vector3(1,0,0);
                    var gb = Instantiate(Espada,
                            espadaPosition,
                            Quaternion.identity) as GameObject;
                        
            }
            if(sr.flipX == true){
                    
                    Debug.Log(aux1);
                    var espadaPosition = transform.position + new Vector3(-1,0,0);
                    var gb = Instantiate(Espada,
                            espadaPosition,
                            Quaternion.identity) as GameObject;
                        
            }
            ChangeAnimation(Anima_Attack);
        }

    }
    public void cambio(){
        if(i==0){
            bandDis=true;
            i++;
        }else{
            bandDis=false;
            i=0;
        }
        
    }
}
