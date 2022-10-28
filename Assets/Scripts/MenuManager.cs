using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
    public Canvas menuCanvas;
    public static MenuManager sharedInstance;

{

    void Start()
    {
        if(sharedInstance == null){
            sharedInstance = this;
        } 
        public void ShowMainMenu(){
            menuCanvas.enabled = true;
        }
        public void HideMainMenu(){
            menuCanvas.enabled=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
