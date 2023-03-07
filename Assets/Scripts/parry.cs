using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parry : MonoBehaviour
{

    public int parryCooldown = 100;
    
    //private Animator anim;
    private life_manager life;
    private int cooldown;

    private bool t;


    // Start is called before the first frame update
    void Start()
    {
        life = gameObject.GetComponent<life_manager>();
        //anim = gameObject.GetComponent<Animator>();
        cooldown = 0;
    }

    // Update is called once per frame

    void Update(){
        if(Input.GetMouseButtonDown(1) && cooldown == 0){
            cooldown = parryCooldown;
            //anim.SetInteger("State", 1);
            Debug.Log("Parry command received");
            life.LockOn();
        }
    }

    void FixedUpdate()
    {
        if(cooldown > 0){
            t = true;
            cooldown--;
            if(cooldown == parryCooldown - 30){
                life.LockOff();
                //anim.SetInteger("State", 0);
            }
        }else{
            if(t){
                Debug.Log("Parry ready - "+cooldown);
                t = false;
            }
        }
    }
}
