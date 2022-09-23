using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Program : MonoBehaviour
{
    private GameManagerController gameManager;

   // private int velocity   = 5;
    private int run_velZ    = 2;
    
    Rigidbody2D rb;
    
    Animator animatorZ;
    SpriteRenderer sr;
   
    const int Anima_Walk   = 4;

    int aux = 0;
    int aux1 = 0;
    int aux2 = 0;
  //  bool Ani_Salto = false;
  
    

    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log("Iniciando Script de Zombie");
        rb = GetComponent<Rigidbody2D>();
        animatorZ = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {       
            sr.flipX = true;
            rb.velocity = new Vector2(-run_velZ, rb.velocity.y);
            ChangeAnimation(Anima_Walk);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
 
    
        if(other.gameObject.tag == "shield"){
           Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "Bola1"){
          aux++;
            
        }
        if(aux == 3){
            Destroy(this.gameObject);
            aux = 0;
        }
        if(other.gameObject.tag == "Bola2"){
          aux1++;
            
        }
        if(aux1 == 2){
            Destroy(this.gameObject);
            aux1 = 0;
        }
        if(other.gameObject.tag == "Bola3"){
           Destroy(this.gameObject);
        }

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
        animatorZ.SetInteger("EstadoZ",animation);
    }
    private void ChangeAnimation_Bool(bool animat_bool){
        animatorZ.SetBool("Saltar",animat_bool);
    }
    
}
