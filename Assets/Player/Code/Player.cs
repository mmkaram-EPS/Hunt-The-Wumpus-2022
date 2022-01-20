using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour{
    private Vector2 targetPos;
    public float speed = 5;
    
    private bool UIActive = false;
    
    
    void Start(){
        GameObject UI = transform.GetChild(0).gameObject;
        UI.SetActive(!gameObject.activeSelf);
    }
    
    void Update(){
            //debug
        // Debug.Log(UIActive);



        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Movement
        if (Input.GetMouseButton(0) && UIActive == false){
            targetPos = new Vector2(mousePos.x, mousePos.y);
        }

        if (targetPos.x == 0 && targetPos.y == 0){  //This is a very bad fix to a bug which I cannot even begin to understand
                                                    //When the game is intialized the mouse position is auto-set to 0,0
                                                    //The player always goes to 0,0 at the start, and I don't want it to
            // Debug.Log("TargetPos: x:" + targetPos.x + " y: " + targetPos.y);
        }else{
            if (UIActive == false){
                transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
            }
        }

        //UI
        if (Input.GetButtonDown("Fire1")){
            GameObject UI = transform.GetChild(0).gameObject;
            
            if(UIActive == false){
                UI.SetActive(gameObject.activeSelf);
                targetPos = new Vector2(transform.position.x, transform.position.y);
                UIActive = true;
            }else{
                UI.SetActive(!gameObject.activeSelf);
                UIActive = false;

            }
        }
    }
}
