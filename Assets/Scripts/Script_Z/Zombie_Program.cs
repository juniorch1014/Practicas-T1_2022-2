using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Program : MonoBehaviour
{
    private GameManagerController gameManager;
    private GameManager_Ninja gameManager_Ninja;
   // private int velocity   = 5;
    public int x ;
    private int run_velZ    = 5;
    public GameObject paredZ;
    public GameObject paredZ2;
    Rigidbody2D rb;
    
    Animator animatorZ;
    SpriteRenderer sr;
   
    const int Anima_Walk   = 3;
    int aux = 0;
    int aux1 = 0;
    int aux2 = 0;
    int aux3 = 0;
  //  bool Ani_Salto = false;
  
    

    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log("Iniciando Script de Zombie");
        gameManager_Ninja = FindObjectOfType<GameManager_Ninja>();
        rb = GetComponent<Rigidbody2D>();
        animatorZ = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {     
            rb.velocity = new Vector2(run_velZ, rb.velocity.y);
            ChangeAnimation(Anima_Walk);
            if(aux3 == 0 ){
            var paredPosition = transform.position + new Vector3(-2,0,0);
            var gb = Instantiate(paredZ,
                    paredPosition,
                    Quaternion.identity) as GameObject;
            var paredPosition2 = transform.position + new Vector3(2,0,0);
            var gb2 = Instantiate(paredZ2,
                    paredPosition2,
                    Quaternion.identity) as GameObject;
            aux3 = 1;
            }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
 
        if(other.gameObject.tag == "kunai"){
            aux2++;
           
        }
        if(aux2 == 2 ){
            gameManager_Ninja.EnemiesFalt(10);
            Destroy(this.gameObject);
        }

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
        if(other.gameObject.tag == "ParedZ"){
        sr.flipX = false;
        run_velZ = x;
        }
        if(other.gameObject.tag == "ParedZ2"){
         sr.flipX = true;
         run_velZ = -x;
        }
        if(other.gameObject.tag == "Espada"){
            gameManager_Ninja.EnemiesFalt(10);
            Destroy(this.gameObject);
        }
    }

    private void ChangeAnimation(int animation){     
        animatorZ.SetInteger("EstadoZ",animation);
    }
    private void ChangeAnimation_Bool(bool animat_bool){
        animatorZ.SetBool("Saltar",animat_bool);
    }
    
}
