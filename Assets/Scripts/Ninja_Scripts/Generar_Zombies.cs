using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generar_Zombies : MonoBehaviour
{   
    private GameManager_Ninja gameManager_Ninja;
    private float velocity = 5;
    private Enemigo_ZombMb zombie_Enemies;
    const int Anima_Walk   = 3;
    Animator animatorZ;
    Rigidbody2D rb;
    SpriteRenderer sr;
    int aux = 0;
    // Start is called before the first frame update
    float realVelocity;
    public void SetRightDirection(){
        realVelocity = velocity;
    }
    public void SetLeftDirection(){
        realVelocity = -velocity;
    }
    void Start()
    {
        gameManager_Ninja = FindObjectOfType<GameManager_Ninja>();
        zombie_Enemies = FindObjectOfType<Enemigo_ZombMb>();
        rb = GetComponent<Rigidbody2D>();
        animatorZ = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        
       // Destroy(this.gameObject,5);
    }

    // Update is called once per frame
    void Update()
    {
        sr.flipX = true;
        rb.velocity = new Vector2(realVelocity,rb.velocity.y);
        ChangeAnimation(Anima_Walk);
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "kunai"){
            aux++;
           
        }
        if(aux ==2 ){
            gameManager_Ninja.EnemiesFalt(10);
            //gameManager_Ninja.GanarPuntos(10);
            Destroy(this.gameObject);
        }
      
        //  if(other.gameObject.name == "Ninja_Player"){
            
        //     gameManager_Ninja.EnemiesFalt(1);
        //     Destroy(this.gameObject);
        // }
    }
     void OnTriggerEnter2D(Collider2D other){
          if(other.gameObject.tag == "Espada"){
            gameManager_Ninja.EnemiesFalt(10);
            gameManager_Ninja.GanarPuntos(1);
            Destroy(this.gameObject);
        }
      
    }
    private void ChangeAnimation(int animation){     
        animatorZ.SetInteger("Estado",animation);
    }
}
