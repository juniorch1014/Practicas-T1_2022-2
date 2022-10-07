using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambio_Arma : MonoBehaviour
{
    public SpriteRenderer srCambio;
    public Sprite[] sprites;
    private int next = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiarArma(){
        srCambio.sprite = sprites[next];
        next++;
        if(next == sprites.Length){
             next = 0;
        }
        
    }
}
