using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour
{
    private bool combatEnabled = false;
    public Queue<CombatController> turnQueue = new Queue<CombatController>();
    public List<CombatController> combantants = new List<CombatController>();
    private CombatController currentCharacter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(combatEnabled && combantants.Count == 1) {
            startCombat(GameObject.Find("Player").GetComponent<CircleCollider2D>(), false);
        }
    }

    private bool isAllEnemiesDead() {
        foreach(CombatController combatController in combantants) {
            if(combatController && combatController.gameObject.tag.Equals("enemy")) {
                print(false);
                return false;
            }
        }
        print(true);
        return true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag.Equals("Player")) {
            startCombat(other, false);
        } else {
            //make sure enemy stays inside
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag.Equals("Player")) {
            startCombat(other, true);
        }
    }

    public void nextTurn() {
        if(currentCharacter) {
            currentCharacter.endTurn();
            turnQueue.Enqueue(currentCharacter);
        }

        currentCharacter = turnQueue.Dequeue();
        currentCharacter.startTurn();
    }

    private void startCombat(Collider2D playerCollider, bool combatEnabled) {
        List<CombatController> characters = new List<CombatController>();
        List<Collider2D> characterColliders = new List<Collider2D>();
        this.GetComponent<Collider2D>().OverlapCollider(new ContactFilter2D().NoFilter(), characterColliders);

        //player adjustments
        characters.Add(playerCollider.GetComponent<CombatController>());
        playerCollider.GetComponent<NonCombatController>().enabled = !combatEnabled;
        playerCollider.GetComponent<CombatController>().enabled = combatEnabled;
        playerCollider.GetComponent<CombatController>().setArenaController(this);

        //enemy adjustments
        foreach(Collider2D enemyCollider in characterColliders) {
            if(enemyCollider.tag.Equals("enemy")) {
                enemyCollider.GetComponent<NonCombatController>().enabled = !combatEnabled;
                enemyCollider.GetComponent<CombatController>().enabled = combatEnabled;
                enemyCollider.GetComponent<CombatController>().setArenaController(this);

                characters.Add(enemyCollider.gameObject.GetComponent<CombatController>());
            }
        }
        

        if(combatEnabled) {
            characters.Sort((x, y) => x.turnPriority.CompareTo(y.turnPriority));
            turnQueue = new Queue<CombatController>(characters);
            combantants = characters;
            nextTurn();
            print("combat start!");
        } else {
            Destroy(this.gameObject);
            GameObject.Find("PlayerMenu").GetComponent<Canvas>().enabled = false;
            print("combat end!");
        }
        this.combatEnabled = combatEnabled;
    }

}
