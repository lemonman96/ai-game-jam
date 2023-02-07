using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnBasedController : CombatController
{
   
    Canvas turnBasedCanvas;
    GameObject camera;

    // Start is called before the first frame update
    void Start()
    {   
        this.setCurrentHp(this.maxHp);
        this.setCurrentAp(this.maxAp);
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        turnBasedCanvas = GameObject.Find("PlayerMenu").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if(getIsTurn()) {
            turnBasedCanvas.enabled = true;
            camera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, camera.transform.position.z);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * 1f, ForceMode2D.Force) ;
            GetComponentInChildren<Animator>().SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.magnitude);

            if(Input.GetKeyUp("n")) {
                this.getArenaController().nextTurn();
            }
            
            if(getCurrentAp() <= 0) {
                this.getArenaController().nextTurn();
            }

        } else {
            turnBasedCanvas.enabled = false;
        }
    }

    public void attack() {
        if(getIsTurn()) {
            List<Collider2D> results = new List<Collider2D>();
            Physics2D.OverlapCircle(new Vector2(this.transform.position.x, this.transform.position.y), 4.0f, new ContactFilter2D().NoFilter(), results);
            foreach(Collider2D collider2D in results) {
                print(collider2D);
                if(collider2D.gameObject.tag.Equals("enemy")) {
                    CombatController combatController = collider2D.gameObject.GetComponent<CombatController>();
                    combatController.setCurrentHp(combatController.getCurrentHp() - 10);
                    this.setCurrentAp(this.getCurrentAp() - 2);
                }
            }
        }
    }

    public void foo() {
        return;
    }
}
