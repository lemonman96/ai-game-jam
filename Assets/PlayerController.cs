using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private bool isAlive;
    private int currentHp, currentAp, maxHp = 100, maxAp = 10;


    // Start is called before the first frame update
    private void Start() {
        currentHp = maxHp;
        currentAp = maxAp;
    }

    // Update is called once per frame
    private void Update() {
        
    }
}
