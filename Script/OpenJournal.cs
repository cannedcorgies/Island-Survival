using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenJournal : MonoBehaviour
{
    public GameObject Panel;

    void Update(){
        bool isActive = Panel.activeSelf;
        if(Panel != null && Input.GetKeyDown(KeyCode.F) && !isActive){
            Time.timeScale = 0; 
            Panel.SetActive(true);
        }
        if(Panel != null && Input.GetKeyDown(KeyCode.Return) && isActive){
            Panel.SetActive(false);
            Time.timeScale = 1; 

        }
    }
}
