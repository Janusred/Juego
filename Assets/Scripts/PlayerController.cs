using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Variable de movimiento del monito ese!!
    public float jumpForce = 6f;
    public float runningSpeed = 2f;

    Rigidbody2D rigidBody;

    Animator  animator;

    const string STATE_ALIVE = "isAlive";
    const string STATE_ON_THE_GROUND = "isOnTheGround";

    public LayerMask groundMask;

    void Awake(){
      rigidBody = GetComponent<Rigidbody2D>();
      animator= GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND,true);
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0)){
        Jump();
       } 
       animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());

       Debug.DrawRay(this.transform.position, Vector2.down*2.0f, Color.red);
    }
    void FixedUpdate(){
      if(rigidBody.velocity.x < runningSpeed){
        rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
      }
    }
    void Jump(){
      if(IsTouchingTheGround())
      {
        rigidBody.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
    }
    }
    // nos indica si el mono toca el suelo
    bool IsTouchingTheGround(){
      if(Physics2D.Raycast(this.transform.position, Vector2.down, 2.0f, groundMask)){
        //animator.enabled = true;
return true;
      }else{
        //animator.enabled = false;
return false;
      }

    }
}