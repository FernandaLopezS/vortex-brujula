using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_b : MonoBehaviour
{

    public int attack = 30;
    
    private Animator anim;
    private int cooldown;
    private bool PlayerContact;
    private GameObject hitable;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetButtonDown("Jump")){
            cooldown = attack;
            anim.SetInteger("State", 1);
            if(PlayerContact){
                hitable.GetComponent<life_manager>().Damage(1);
            }
        } 
    }

    void FixedUpdate()
    {
        if(cooldown > 0){
            cooldown--;
            if(cooldown == attack - 20)
                anim.SetInteger("State", 0);
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
