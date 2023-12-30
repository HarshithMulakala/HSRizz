using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public bool inSettings = false;

    public GameObject Settings;

    void Update(){
        if(!(SceneManager.GetActiveScene().buildIndex == 0)){
            if(gameObject.name == "Canvas"){
                if(!inSettings && Input.GetKeyDown(KeyCode.Escape)){
                
                StartCoroutine(open());
            }
            if(inSettings && Input.GetKeyDown(KeyCode.Escape)){
                StartCoroutine(close());
            }
            }
            
        }
        
    }

    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0){
            Screen.fullScreen = true;
        }   
    }

    public void moveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    IEnumerator open()
    {
        yield return new WaitForSeconds(.1f);
        openSettings();
    }

    IEnumerator close()
    {
        yield return new WaitForSeconds(.1f);
        closeSettings();
    }



    public void openSettings(){
        Settings.SetActive(true);
        inSettings = true;
    }

    public void closeSettings(){
        Settings.SetActive(false);
        inSettings = false;
    }
}
