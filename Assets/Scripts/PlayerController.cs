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

    Vector3 startPosition;

    const string STATE_ALIVE = "isAlive";
    const string STATE_ON_THE_GROUND = "isOnTheGround";

    private int heelPoints , manaPoints;

    public const int INTIAL_HEALTH =100, INITAL_MANA = 15,
    MAX_HEALTH = 200, MAX_MANA = 30,
    MIN_HEALTH= 10, MIN_MANA = 0;

    public const int SUPERJUMP_COST = 5;
    public const float SUPERJUMP_FORCE=1.5f;
    public float jumpRaycastDitance = 2;

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
        startPosition = this.transform.position;
    }
     public void StartGame(){
      animator.SetBool(STATE_ALIVE, true);
      animator.SetBool(STATE_ON_THE_GROUND,true);
      Invoke("RestartPosition",0.1f);

      healthPoints = INTIAL_HEALTH;
      manaPoints =  INITAL_MANA;
      
    }
    void RestartPosition(){
      this.transform.position = startPosition;
      this.rigidBody.velocity = Vector2.zero;

      GameObject mainCamera = GameObject,Find("Main Camera");
      mainCamera.GetComponent<CameraFollow>().ResetCameraPosition();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Jump")){
        Jump(false);
       }
      if(Input.GetButtonDown("JumpSuper")){
        Jump(true);
       }
       animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());

       Debug.DrawRay(this.transform.position, Vector2.down*jumpRaycastDitance , Color.red);
    }
    void FixedUpdate()
    {
      if(GameManager.sharedInstance.currentGameState == GameState.inGame)
      {
      if(rigidBody.velocity.x < runningSpeed)
      {
        rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
      }
      }else{
        rigidBody.velocity = new Vector2(0,rigidBody.velocity.y);
      }
    }
    void Jump(bool JumpSuper){
      float jumpForceFactor= jumpForce;
      if(JumpSuper &&  manaPoints>=SUPERJUMP_COST){
        manaPoints -= SUPERJUMP_COST;
        jumpForceFactor *= SUPERJUMP_FORCE;
      }
      if(GameManager.sharedInstance.currentGameState==GameState.inGame){
        if(IsTouchingTheGround()){
          rigidBody.AddForce(Vector2.up * jumpForceFactor, ForceMode2D.Impulse);
        }
      }
      {
        rigidBody.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
    }
    }
    // nos indica si el mono toca el suelo
    bool IsTouchingTheGround(){
      if(Physics2D.Raycast(this.transform.position, Vector2.down, jumpRaycastDitance , groundMask)){
        //animator.enabled = true;
        GameManager.sharedInstance.currentGameState = GameState.inGame;
return true;
      }else{
        //animator.enabled = false;
return false;
      }
       

    }
    public void Die(){
      float travelledDistance = GetTravelledDistance();
      float previousMaxDistance = PlayerPrefs.GetFloat("maxscore",0f);
      if(travelledDistance> previousMaxDistance){
        PlayerPrefs.SetFloat("maxscore",travelledDistance);
      }
        this.animator.SetBool(STATE_ALIVE, false);
        GameManager.sharedInstance.GameOver();
      }
      public void CollectHealth(int points){
        this.healthPoints += points;
        if(this.healthPoints >= MAX_HEALTH){
          this.healthPoints=MAX_HEALTH;
        }
      }
      public void CollectMana(int points){

      }
      public int GetHealth(){
        return healthPoints;
      }
      public int GetMana(){
        return manaPoints;
      }
}
