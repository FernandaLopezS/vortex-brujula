using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life_manager : MonoBehaviour
{

    public int life;

    private bool plock;

    public void LockOn(){
        plock = true;
    }

    public void LockOff(){
        plock = false;
    }

    public void Damage(int x){
        // The script for the damage taken would go here
        if(plock){
            Debug.Log("Damage parried");
        }else
            Debug.Log("Damage received - "+x);
    }

}
