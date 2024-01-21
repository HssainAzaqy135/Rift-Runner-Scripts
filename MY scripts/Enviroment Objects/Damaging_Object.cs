using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaging_Object : EnviromentObject
{
    public bool isActive = true;
    public int Damage = 1;
    public bool Respawn_On_Collison = true;

    //--------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        
    }
    //--------------------------------------------------------------------------
    void OnCollisionEnter( Collision collisionInfo){
        if(isActive){
            if(collisionInfo.collider.tag == "Player"){
                if(Respawn_On_Collison){
                    collisionInfo.gameObject.GetComponent<Player>().ReSpawn();
                }
                collisionInfo.gameObject.GetComponent<Player>().takeDamage(Damage);
            }
        }
    }
}
