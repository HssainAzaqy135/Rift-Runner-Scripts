using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTriggerTrap : EnviromentObject
{
    public float Trigger_delay;
    protected Collision collisionInfo;

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
    void OnCollisionEnter(Collision other)
    {
        collisionInfo = other;
         Invoke("ApplyEncounter",Trigger_delay);
    }
}
