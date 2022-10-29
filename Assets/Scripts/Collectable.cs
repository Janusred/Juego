using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public emun CollectableType{
    healthPotion
    manaPotion
    money
}

public class Collectable : MonoBehaviour

public CollectableType type = CollectableType.money;

private SprinteRenderer sprite;
private CircleCollider2D itemCollider;

bool hasBeenCollected = false;

public int value = 1;

private void Awake(){
    sprite = GetComponent<SprinteRenderer>();
    itemCollider = GetComponent<CircleCollider2D>();
}

{
    void Show(){
        sprite.enabled= true;
        itemCollider.enabled= true;
        hasBeenCollected=false;
    }    
    void Hide(){
        sprite.enabled=false;
        itemCollider.enabled= false;
    }

    void Collect(){
        Hide();
        hasBeenCollected= true;

        switch (this.type){
            case CollectableType.money:
            GameManager.sharedInstance.collectedObject(this);
            break;
            case CollectableType.healthPotion:
            break;
            case CollectableType.manaPotion:
            break;
        }
        {
            
            default:
        }
    }
    void OnTriggerEnter2D(Collider2D collison){
        if(collision.tag == tag "Player"){
            Destroy(gameObject);
        }
    }
}
