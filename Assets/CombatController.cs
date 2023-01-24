using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public int turnPriority = 0;
    private bool isTurn = false;

    private ArenaController arenaController;

    public void startTurn() {
        isTurn = true;
    }

    public void endTurn() {
        isTurn = false;
        Input.ResetInputAxes();
    }

    public ArenaController getArenaController() {
        return arenaController;
    }

    public void setArenaController(ArenaController arenaController) {
        this.arenaController = arenaController;
    }

    public bool getIsTurn() {
        return isTurn;
    }
}
