using UnityEngine;

public class Rewind_Token : Pickup
{
    public float Time_To_Add  = 2f;
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        
    }
    //--------------------------------------------------------------------------
    public override void ApplyEncounterEntered()
    {
        if(isActive){
            if(Entered_object.tag == "Player" ){
                Rewinder rewinder = Entered_object.GetComponent<Rewinder>();
                if(rewinder){
                    rewinder.setRewindCapacity(rewinder.GetRewindCapacity() + Time_To_Add);
                    SetActive(false);
                }
            }
        }
    }
    //--------------------------------------------------------------------------
}