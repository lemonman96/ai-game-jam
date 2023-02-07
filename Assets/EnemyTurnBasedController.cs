using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnBasedController : CombatController
{
    // Start is called before the first frame update
    void Start()
    {
        this.setCurrentHp(this.maxHp);
        this.setCurrentAp(this.maxAp);
    }

    // Update is called once per frame
    void Update() {

        if(this.getCurrentHp() <= 0) {
            Destroy(this.gameObject);
            this.getArenaController().combantants.Remove(this);
        }

        if(getIsTurn()) {
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, camera.transform.position.z);
            if(Input.GetKeyUp("n")) {
                this.getArenaController().nextTurn();
            }
        }
    }
}
