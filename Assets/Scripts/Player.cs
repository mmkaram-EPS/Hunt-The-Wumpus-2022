using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Pathfinding;


public class Player : MonoBehaviour{
    private Vector2 targetPos;
    public float speed = 5;
    
    private bool UIActive = false;

    public GameObject UI;
    public Rigidbody2D rb;
    public Animator anim;

    public Seeker seeker;

    //wumpus spawn
    //im gonna move this to a separate script later if needed
    /*
    public Wumpus w;
    public GameObject r;
    public GameObject wumpus;
    public GameObject bat;
    public GameObject hole;
    public Instantiate i;
    */

    public Vector2 resetPos;

    public bool isFrozen = false;
    
    void Start(){
        UI.SetActive(!gameObject.activeSelf);
        rb = GetComponent<Rigidbody2D>();
        //wumpus spawn
    }

    Vector2 lastFrame;
    void Update(){

        if (isFrozen)
        {
            return;
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Movement
        if (Input.GetMouseButton(0) && UIActive == false){
            targetPos = new Vector2(mousePos.x, mousePos.y);
        }

        // AI new code
        seeker.StartPath(transform.position, targetPos);

        Vector2 animPos = new Vector2(lastFrame.x - transform.position.x, lastFrame.y - transform.position.y);

        anim.SetFloat("x", animPos.x);
        anim.SetFloat("y", animPos.y);

        lastFrame = transform.position;

        //UI
        if (Input.GetButtonDown("Fire1")){
            //GameObject UI = transform.GetChild(0).gameObject;
            
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

    // Reset the player's position when called
    // Called when new room is loaded
    public void Reset()
    {
        transform.position = resetPos;
        targetPos = resetPos;
    }

    public void Freeze()
    {
        isFrozen = !isFrozen;
    }
}
