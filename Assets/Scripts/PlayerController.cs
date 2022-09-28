using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Variable de movimiento del monito ese!!
    public float jumpForce = 6f;
    Rigidbody2D rigidBody;

    public LayerMask groundMask;

    void Awake(){
      rigidBody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0)){
        Jump();
       } 
       Debug.DrawRay(this.transform.position, Vector2.down*2.0f, Color.red);
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
return true;
      }else{
return false;
      }

    }
}
