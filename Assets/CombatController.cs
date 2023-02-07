using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public int turnPriority = 0;
    private int currentHp, currentAp;
    public int maxHp = 100, maxAp = 10;
    private bool isTurn = false;
    private ArenaController arenaController;

    public void setCurrentHp(int currentHp) {
        this.currentHp = currentHp;
    }

    public int getCurrentHp() {
        return currentHp;
    }

    public void setCurrentAp(int currentAp) {
        this.currentAp = currentAp;
    }

    public int getCurrentAp() {
        return currentAp;
    }

    public virtual void startTurn() {
        isTurn = true;
    }

    public virtual void endTurn() {
        isTurn = false;
        currentAp = maxAp;
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

    public void setIsTurn(bool isTurn) {
        this.isTurn = isTurn;
    }
}
