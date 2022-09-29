using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Escena
using UnityEngine.SceneManagement;

public class Goku_Player : MonoBehaviour
{
    
    float velocity = 10;

    
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    private float defaultGravity;
    private Vector2 direction;
    private bool activarNube = false;
    const int Anima_Correr   = 0;
    const int Anima_nube   = 1;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Iniciando Script de Goku");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        defaultGravity = rb.gravityScale;

    }

    // Update is called once per frame
    void Update()
    {
        float   x = Input.GetAxis("Horizontal");
        float   y = Input.GetAxis("Vertical");
        direction = new Vector2(x,y);
        Run();

        if(Input.GetKey(KeyCode.UpArrow) && activarNube == true){
            rb.velocity = new Vector2(rb.velocity.x, velocity);
        }
        if(Input.GetKey(KeyCode.DownArrow) && activarNube == true){
            rb.velocity = new Vector2(rb.velocity.x, -velocity);
        }

    }
    private void Run(){
        if(direction.x == 0f){
            return;
        }
        rb.velocity = new Vector2(direction.x * velocity, rb.velocity.y);
        sr.flipX = direction.x < 0;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
         if(other.gameObject.tag == "suelo"){
            rb.gravityScale = defaultGravity;
            activarNube = false;
            ChangeAnimation(Anima_Correr);
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "nube"){
            Destroy(other.gameObject);
            rb.gravityScale = 0;
            activarNube = true;
            ChangeAnimation(Anima_nube);
        }
        if(other.gameObject.tag == "coin"){
            Destroy(other.gameObject);
            SceneManager.LoadScene(1);
        }
        
    }
    
   
     private void ChangeAnimation(int animation){     
        animator.SetInteger("Estado",animation);
    }
}
