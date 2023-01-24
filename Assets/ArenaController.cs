using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour
{
    
    public Queue<GameObject> turnQueue = new Queue<GameObject>();

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
            startCombat(false);
        } else {
            //make sure enemy stays inside
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag.Equals("Player")) {
            startCombat(true);
        }
    }


    private void startCombat(bool combatEnabled) {
        List<GameObject> characters = new List<GameObject>();
        List<Collider2D> characterColliders = new List<Collider2D>();
        this.GetComponent<Collider2D>().OverlapCollider(new ContactFilter2D().NoFilter(), characterColliders);

        foreach(Collider2D characterCollider in characterColliders) {
            if(characterCollider.tag.Equals("enemy") || characterCollider.tag.Equals("Player")) {
                characterCollider.GetComponent<NonCombatController>().enabled = !combatEnabled;
                characterCollider.GetComponent<CombatController>().enabled = combatEnabled;
                characters.Add(characterCollider.gameObject);
            }
        }
        

        if(combatEnabled) {
            characters.Sort((x, y) => x.GetComponent<CombatController>().turnPriority.CompareTo(y.GetComponent<CombatController>().turnPriority));
            turnQueue = new Queue<GameObject>(characters);
            print("combat start!");
        } else {
            Destroy(this.gameObject);
            print("combat end!");
        }
    }

}
