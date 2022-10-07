    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_ZombMb : MonoBehaviour
{
   private GameManager_Ninja gameManager_Ninja;
    
    public GameObject Zombie;
   // private int velocity   = 5;
    private int run_velZ    = 2;
    private float timer = 0;
    private int random = 0;
    
    Rigidbody2D rb;
    
    Animator animatorZ;
    SpriteRenderer sr;
   
    const int Anima_Walk   = 3;

    int aux = 0;
    int aux1 = 0;
  //  bool Ani_Salto = false;
  
    

    // Start is called before the first frame update
    void Start()
    {
        
        
        gameManager_Ninja = FindObjectOfType<GameManager_Ninja>();
        Debug.Log("Iniciando Script de Zombie");
        rb = GetComponent<Rigidbody2D>();
        animatorZ = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {       
        timer += Time.deltaTime;
        if(aux == 0){
            Num_Random();
            aux = 1;
        }
        Debug.Log("R: "+ random);
        Debug.Log("T" + timer);
       // Debug.Log(timer);
        // if(gameManager_Ninja.Live()>=0){
        //     sr.flipX = true;
        //     rb.velocity = new Vector2(-run_velZ, rb.velocity.y);
        //     ChangeAnimation(Anima_Walk);
        // }else{
        //     rb.velocity = new Vector2(0, rb.velocity.y);
            
        //*************************************************************
       if (timer>=random){
        Debug.Log("Zombie");
        var shieldPosition = transform.position + new Vector3(-1,0,0);
        var gb = Instantiate(Zombie,
                    shieldPosition,
                    Quaternion.identity) as GameObject;
        var controller =gb.GetComponent<Generar_Zombies>();
        controller.SetLeftDirection();
        //****************************************************************
        
        // sr.flipX = true;
        // rb.velocity = new Vector2(-run_velZ, rb.velocity.y);
        // ChangeAnimation(Anima_Walk);
        timer = 0;
        aux = 0;
       }
        
        
    }
    private void Num_Random(){
        random = Random.Range(0,3);
        Debug.Log("R: "+ random);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
 
    
        // if(other.gameObject.tag == "shield"){
        //    Destroy(this.gameObject);
        // }
        // if(other.gameObject.tag == "Bola1"){
        //   aux++;
            
        // }
        // if(aux == 3){
        //     if(gameManager_Ninja.Enemies()!=0){
        //         gameManager_Ninja.EnemiesFalt(1);
        //     }
        //     Destroy(this.gameObject);
        //     aux = 0;
        // }
        // if(other.gameObject.tag == "Bola2"){
        //   aux1++;
        
        // }
        // if(aux1 == 2){
        //     if(gameManager_Ninja.Enemies()!=0){
        //         gameManager_Ninja.EnemiesFalt(1);
        //     }
        //     Destroy(this.gameObject);
        //     aux1 = 0;
        // }
        // if(other.gameObject.tag == "Bola3"){
        //     if(gameManager_Ninja.Enemies()!=0){
        //         gameManager_Ninja.EnemiesFalt(1);
        //     }
        //     Destroy(this.gameObject);
        // }
        
        // if(other.gameObject.tag == "kunai"){
        //     aux++;
           
        // }
        // if(aux ==2 ){
        //     gameManager_Ninja.EnemiesFalt(1);
        //     Destroy(this.gameObject);
        // }
        //  if(other.gameObject.name == "Ninja_Player"){
            
        //     gameManager_Ninja.EnemiesFalt(1);
        //     Destroy(this.gameObject);
        // }
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Trigger");
        //Movimiento de derecha a izquierda
        if(other.gameObject.tag == "ParedZ"){
        sr.flipX = false;
        run_velZ = 10;
        }
        if(other.gameObject.tag == "ParedZ2"){
         sr.flipX = true;
         run_velZ = -10;
        }
        //************************************

    }

    private void ChangeAnimation(int animation){     
        animatorZ.SetInteger("Estado",animation);
    }
    private void ChangeAnimation_Bool(bool animat_bool){
        animatorZ.SetBool("Saltar",animat_bool);
    }
}
