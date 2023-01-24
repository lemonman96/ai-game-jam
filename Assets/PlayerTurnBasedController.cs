using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnBasedController : CombatController
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInChildren<Animator>().SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.magnitude);
    }

    private void endTurn() {
        
    }
}
