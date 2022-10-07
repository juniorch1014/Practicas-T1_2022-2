using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class Generar_Portal : MonoBehaviour
{
   
    private GameManagerController gameManager;
    private GameManager_Ninja gameManager_Ninja;
   // private int velocity   = 5;
    public int x ;
    private int run_velZ    = 0;
    public GameObject portal;
    Rigidbody2D rb;
    
   
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
        
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {     
            
            if(gameManager_Ninja.Score() == 10 && gameManager_Ninja.Enemies() ==10){
            if(aux3==0){
            var paredPosition = transform.position + new Vector3(0,0,0);
            var gb = Instantiate(portal,
                    paredPosition,
                    Quaternion.identity) as GameObject;
            }
            aux3 = 1;
            }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
 
        
    }

    void OnTriggerEnter2D(Collider2D other){
       SceneManager.LoadScene(3);
    }

}
