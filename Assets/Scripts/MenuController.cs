using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void PlayBtn(){
        Debug.Log("fhfhfhffhf");
        SceneManager.LoadScene(1);
        
    }

    public void QuitGame(){
        Application.Quit();
    }

    

}