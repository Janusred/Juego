using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatoform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        animator.enabled=true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
