﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hivemind{
    public class BeeChef : MonoBehaviour
    {
        public Spawner sp;

        void Update(){
            //set up controls!
            if(Input.GetKeyDown(KeyCode.D)){
                Vector2 p = transform.position;
                p.x = Mathf.Clamp(p.x + 2.0f, -2.0f, 2.0f);
                transform.position = p;
            }
            if(Input.GetKeyDown(KeyCode.A)){
                Vector2 p = transform.position;
                p.x = Mathf.Clamp(p.x - 2.0f, -2.0f, 2.0f);
                transform.position = p;
            }
        }

        void OnTriggerEnter2D(Collider2D col){
            Ingredient ing = col.gameObject.GetComponent<Ingredient>();
            if(ing != null){
                if(ing.id == sp.ids_needed[sp.next_ing]){
                    Destroy(col.gameObject);
                    sp.NextIng();
                }
            }
        }
    }
}