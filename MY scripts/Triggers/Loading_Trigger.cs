using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading_Trigger : MonoBehaviour
{
    //--------------------------------------------------------------------------
    public enum Trigger_Method{
        Collision
    }
    //--------------------------------------------------------------------------

    //--------------------------------------------------------------------------
    public Trigger_Method trigger_method;
    public bool is_one_timer;
    public bool isActive;
    //--------------------------------------------------------------------------
    public float Load_delay;
    public float Unload_delay;
    //--------------------------------------------------------------------------
    public  GameObject[] To_Activate_On_Trigger;
    public float Activation_delay = 0f; 

    //--------------------------------------------------------------------------
    void Start()
    {

    }
    //--------------------------------------------------------------------------
    void Update()
    {
        
    }
    //--------------------------------------------------------------------------
    public void OnTriggerEnter(Collider collider)
    {   
        if(isActive){
            if(trigger_method == Trigger_Method.Collision){
                CollisionTrigger();
            }
            if(is_one_timer){
                isActive = false;
            }

            Invoke("ActivateObjects",Activation_delay);
        }
    }
    //--------------------------------------------------------------------------
    public virtual void CollisionTrigger(){
        Invoke("Load",Load_delay);
        Invoke("Unload",Unload_delay);
    }
    //--------------------------------------------------------------------------
    protected void ActivateObjects(){
        for(int i = 0 ; i < To_Activate_On_Trigger.Length ; i++){
            To_Activate_On_Trigger[i].SetActive(true);
        }
    }
    //--------------------------------------------------------------------------
    protected void DeActivateObjects(){
        for(int i = 0 ; i < To_Activate_On_Trigger.Length ; i++){
            To_Activate_On_Trigger[i].SetActive(false);
        }
    }
    //--------------------------------------------------------------------------
    public virtual void Load(){

    }
    //--------------------------------------------------------------------------
    public virtual void Unload(){

    }
}
