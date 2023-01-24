using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour
{
    
    Queue<GameObject> turnQueue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag.Equals("Player")) {
            startCombat(other, false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag.Equals("Player")) {
            startCombat(other, true);
        }
    }


    private void startCombat(Collider2D playerCollider, bool combatEnabled) {
        turnQueue.Enqueue(playerCollider.gameObject);
        playerCollider.GetComponent<PlayerController>().enabled = !combatEnabled;
        playerCollider.GetComponent<PlayerTurnBasedController>().enabled = combatEnabled;        

        List<Collider2D> enemyColliders = new List<Collider2D>();

        this.GetComponent<Collider2D>().OverlapCollider(new ContactFilter2D().NoFilter(), enemyColliders);

        foreach(Collider2D enemyCollider in enemyColliders) {
            if(enemyCollider.tag.Equals("enemy")) {
                enemyCollider.GetComponent<EnemyController>().enabled = !combatEnabled;
                enemyCollider.GetComponent<EnemyTurnBasedController>().enabled = combatEnabled;
                turnQueue.Enqueue(enemyCollider.gameObject);
            }
        }
        
        if(combatEnabled) {
            print("combat start!");
        } else {
            Destroy(this.gameObject);
            print("combat end!");
        }
    }

}
