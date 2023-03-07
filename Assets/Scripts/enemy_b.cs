using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_b : MonoBehaviour
{

    public int attack = 30;
    
<<<<<<< Updated upstream
    private Animator anim;
=======
    //private Animator anim;
>>>>>>> Stashed changes
    private int cooldown;
    private bool PlayerContact;
    private GameObject hitable;

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        anim = gameObject.GetComponent<Animator>();
=======
        //anim = gameObject.GetComponent<Animator>();
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
<<<<<<< Updated upstream
        if(Input.GetButtonDown("Jump")){
            cooldown = attack;
            anim.SetInteger("State", 1);
=======
        if(Input.GetKeyDown(KeyCode.P)){
            cooldown = attack;
            //anim.SetInteger("State", 1);
>>>>>>> Stashed changes
            if(PlayerContact){
                hitable.GetComponent<life_manager>().Damage(1);
            }
        } 
    }

    void FixedUpdate()
    {
        if(cooldown > 0){
            cooldown--;
<<<<<<< Updated upstream
            if(cooldown == attack - 20)
                anim.SetInteger("State", 0);
=======
            //if(cooldown == attack - 20)
                //anim.SetInteger("State", 0);
>>>>>>> Stashed changes
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="GoodGuy"){
            hitable = other.gameObject;  
            PlayerContact = true;                      
        }
        Debug.Log("ObjectEnter");
    }
    
    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag=="GoodGuy"){
            hitable = null;
            PlayerContact = false;
        }
        Debug.Log("ObjectExit");
    }


}
