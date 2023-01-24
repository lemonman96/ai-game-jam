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
        if(getIsTurn()) {
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, camera.transform.position.z);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * 1f, ForceMode2D.Force) ;
            GetComponentInChildren<Animator>().SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.magnitude);
            
            if(Input.GetKeyUp("n")) {
                this.getArenaController().nextTurn();
            }

            
        }
    }
}
