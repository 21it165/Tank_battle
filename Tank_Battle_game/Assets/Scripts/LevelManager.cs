using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    void Update(){
        if(!GameObject.FindObjectOfType<Enemy_Ai>() && SceneManager.GetActiveScene().name == "Game"){
            LoadLevel("GameOver");
        }
    }

    
   
    public void LoadLevel(string name){
        //Debug.Log("req : " + name);
        //Application.LoadLevel(name);
        if(name == "Game"){
            //Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
             Cursor.lockState = CursorLockMode.Locked;
        }
        else{
            Cursor.visible = true;
             Cursor.lockState = CursorLockMode.None;
        }
        SceneManager.LoadScene(name);
    }

    public void QuitReq(){
       // Debug.Log("req for quit");
       Application.Quit();
    }

    public void LoadNextLevel(){
        SceneManager.LoadScene(SceneManager.sceneCount + 1);
    }

}
