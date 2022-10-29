using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
private Slider slider;
public Bartype type;

    void Start()
    {
       slider= GetComponent<Slider>();
       switch(type){
        case Bartype.healthBar:
        slider.maxValue = PlayerController.MAX_HEALTH;
        break;
        case Bartype.manaBar:
       slider.maxValue= PlayerController.MAX_MANA;
        break;
       } 

    }

    // Update is called once per frame
    void Update()
    {
        switch(type){ 
            case BarType.healthBar:
            slider.value = GameObject.Find("Player").
            GetComponent<PlayerController>().GetHealth();
        }
    }
}
