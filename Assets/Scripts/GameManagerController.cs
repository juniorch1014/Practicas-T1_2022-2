using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class GameManagerController : MonoBehaviour
{
    Knight_Program PlayerIn;
    public TMP_Text scoreText1;
    public TMP_Text scoreText2;
    public TMP_Text scoreText3;
    private int score;
    private int coin;
    private int coin2;
    private float Pos_X;
    private float Pos_Y;
    private float Pos_Z;
    private Vector3 posicion;
    // Start is called before the first frame update
    void Start()
    {
        PlayerIn = FindObjectOfType<Knight_Program>();
        score = 0;
        coin = 0;
        coin2 = 0;
        posicion = PlayerIn.transform.position;
        PrintScoreInScreen();
        PrintCoinInScreen1();
        PrintCoinInScreen2();
        LoadGame();
    }
    public void SaveGame(){
        var filePath = Application.persistentDataPath + "/save.dat";

        FileStream file;

        if(File.Exists(filePath)){
            file = File.OpenWrite(filePath);
        }else {
            file = File.Create(filePath);
        }
        //Definir que datos guardar;
        Game_Data data = new Game_Data();
        data.Score = score;
        data.Coins = coin;
        data.Coins2 = coin2;
       
     
        data.Pos_X = PlayerIn.transform.position.x;
        data.Pos_Y = PlayerIn.transform.position.y;
        data.Pos_Z = PlayerIn.transform.position.z;
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file,data);
        file.Close();
        Debug.Log("Puntaje Guardado");
    }
    public void LoadGame(){
        var filePath = Application.persistentDataPath + "/save.dat";

         FileStream fileL ;
        if(File.Exists(filePath)){
            fileL = File.OpenRead(filePath);
        }else {
            fileL = File.Create(filePath);
        }
    
        //No manda valores- Arreglar
        BinaryFormatter bf = new BinaryFormatter();
        Game_Data data = (Game_Data) bf.Deserialize(fileL);
        fileL.Close();

        score = data.Score;
        coin = data.Coins;
        coin2 = data.Coins2;
        posicion.x = data.Pos_X;
        posicion.y = data.Pos_Y;
        posicion.z = data.Pos_Z;

        PlayerIn.transform.position = posicion;
        PrintScoreInScreen();
        PrintCoinInScreen1();
        PrintCoinInScreen2();
    }
    public void DeleteGame(){
        var filePath = Application.persistentDataPath + "/save.dat";
        if(File.Exists(filePath)){
            File.Delete(filePath);
        }
    }
    public int Score(){
        return score;
    }
    public int Coins(){
        return coin;
    }
    public int Coins2(){
        return coin2;
    }
    public void GanarPuntos(int puntos){
        score += puntos;
        Debug.Log("Gpuntos: " + puntos);
        PrintScoreInScreen();
    }
    public void GanarCoin1(int mon1){
        coin += mon1;
        Debug.Log("Coins1: " + coin);
        PrintCoinInScreen1();
    }
    public void GanarCoin2(int mon2){
        coin2 += mon2;
        Debug.Log("Coins2: " + coin2);
        PrintCoinInScreen2();
    }
    private void PrintScoreInScreen(){
        scoreText1.text = "Puntaje: " + score;
        Debug.Log("punto: " + score);
    }
    private void PrintCoinInScreen1(){
        scoreText2.text = "Coin tipo 1: " + coin;
        Debug.Log("coin1: " + coin);
    }
    private void PrintCoinInScreen2(){
        scoreText3.text = "Coin tipo 2: " + coin2;
        Debug.Log("coin2: " + coin2);
    }
    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
