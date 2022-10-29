using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 public float runningSpeed = 1.5f;

 public int enemyDamage = 10.0f;

 Rigidbody2D rigidBody;

public bool facingBody;
 private Vector3 startPosition;
private void Awake(){
rigidBody = GetComponent<Rigidbody2D>();    
}


    void Start()
    {
        this.transform.position = startPosition;
    }

    // Update is called once per frame
     private void FixedUpdate()
    {
        float currentRunningSpeed = runningSpeed;
        if(facingRigth){
                currentRunningSpeed = runningSpeed;
                this.transform.eulerAngles = new Vector3(0,200,0)
        }else{
            currentRunningSpeed = -runningSpeed;
            this.transform.eulerAngles = Vector3.zero;
        }
        if(GameManager.sharedInstance.currentGameState == GameState.inGame){
            rigidBody.velocity = new Vector2(currentRunningSpeed, rigidBody.velocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Coin"){
            return;
        }
        if(collision.tag == "Player"){
            collision.gameObject.GetComponent<PlayerController>().CollectHealth(-enemyDamage);
        return;
        }
        //Hacemos que el enemigo rote 
        facingRigth= !facingRigth; 

    }
}
