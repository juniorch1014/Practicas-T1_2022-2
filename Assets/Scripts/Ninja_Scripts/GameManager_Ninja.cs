using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager_Ninja : MonoBehaviour
{
    Script_Ninja PlayerIn;
    public TMP_Text scoreText1;
    public TMP_Text scoreText2;
    public TMP_Text scoreText3;
    private TMP_Text scoreText4;
    private int score;
    private int live;
    private int enemies;
    private int level;
    private float Pos_X;
    private float Pos_Y;
    private float Pos_Z;
    private Vector3 posicion;
    // Start is called before the first frame update
    void Start()
    {
        PlayerIn = FindObjectOfType<Script_Ninja>();
        score   = 0;
        live    = 3;
        enemies = 0;
        level   = 0;
        posicion = PlayerIn.transform.position;
        PrintScoreInScreen();
        PrintCoinInScreen1();
        PrintCoinInScreen2();
        //LoadGame();
    }
    //*************Guardado*****************
    // public void SaveGame(){
    //     var filePath = Application.persistentDataPath + "/save.dat";

    //     FileStream file;

    //     if(File.Exists(filePath)){
    //         file = File.OpenWrite(filePath);
    //     }else {
    //         file = File.Create(filePath);
    //     }
    //     //Definir que datos guardar;
    //     GameData_Ninja data = new GameData_Ninja();
    //     data.Score = score;
    //     data.Live = live;
    //     data.Enemies = enemies;
       
     
    //     data.Pos_X = PlayerIn.transform.position.x;
    //     data.Pos_Y = PlayerIn.transform.position.y;
    //     data.Pos_Z = PlayerIn.transform.position.z;
    //     BinaryFormatter bf = new BinaryFormatter();
    //     bf.Serialize(file,data);
    //     file.Close();
    //     Debug.Log("Puntaje Guardado");
    // }
    // public void LoadGame(){
    //     var filePath = Application.persistentDataPath + "/save.dat";

    //      FileStream fileL ;
    //     if(File.Exists(filePath)){
    //         fileL = File.OpenRead(filePath);
    //     }else {
    //         fileL = File.Create(filePath);
    //     }
    
    //     //No manda valores- Arreglar
    //     BinaryFormatter bf = new BinaryFormatter();
    //     GameData_Ninja data = (GameData_Ninja) bf.Deserialize(fileL);
    //     fileL.Close();

    //     score = data.Score;
    //     live = data.Live;
    //     enemies = data.Enemies;
    //     posicion.x = data.Pos_X;
    //     posicion.y = data.Pos_Y;
    //     posicion.z = data.Pos_Z;

    //     PlayerIn.transform.position = posicion;
    //     PrintScoreInScreen();
    //     PrintCoinInScreen1();
    //     PrintCoinInScreen2();
    // }
    // public void DeleteGame(){
    //     var filePath = Application.persistentDataPath + "/save.dat";
    //     if(File.Exists(filePath)){
    //         File.Delete(filePath);
    //     }
    // }
    //**************************************
    public int Score(){
        return score;
    }
    public int Live(){
        return live;
    }
    public int Enemies(){
        return enemies;
    }
   
    public void GanarPuntos(int puntos){
        score += puntos;
        Debug.Log("Gpuntos: " + puntos);
        PrintScoreInScreen();
    }
    public void PerdeLive(int liveCant){
        live -= liveCant;
        Debug.Log("Live: " + live);
        PrintCoinInScreen1();
    }
    public void SuberNivel(int levelup){
        level += levelup;
        Debug.Log("Live: " + live);
        PrintLevelInScreen();
    }
    public void PerderLive(int liveCant){
        live -= liveCant;
        Debug.Log("Live: " + live);
        PrintCoinInScreen1();
    }
    public void AsignarVidas(int liveCant){
        live = liveCant;
        Debug.Log("Live: " + live);
        PrintCoinInScreen1();
    }
    public void EnemiesFalt(int enemiesCant){
        enemies += enemiesCant;
        Debug.Log("Enemies: " + enemies);
        PrintCoinInScreen2();
        
    }
    private void PrintScoreInScreen(){
        scoreText1.text = "Coins: " + score;
        Debug.Log("coins: " + score);
    }
    
    private void PrintCoinInScreen1(){
        if(Live()>=0){
            scoreText2.text = "Vida: " + live;
            Debug.Log("live: " + live);
        }else{
            scoreText2.text = "Sin Vidas";
        }
    }
    private void PrintCoinInScreen2(){
        if(Enemies()>=0){
        scoreText3.text = "Enemigos: " + enemies;
        Debug.Log("enemies: " + enemies);
        }else{
            scoreText3.text = "No hay Enemigos";
        }
    }
    private void PrintLevelInScreen(){
        scoreText4.text = "Nivel: " + score;
        Debug.Log("Nivel: " + score);
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
