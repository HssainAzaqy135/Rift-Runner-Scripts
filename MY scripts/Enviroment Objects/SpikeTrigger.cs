using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : EntryTriggerTrap
{
    public Move_Fixed_Distance[] Spikes_to_trigger;
    //--------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Spikes_to_trigger.Length; i++){
            Spikes_to_trigger[i].DeActivate();
        }
    }
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        
    }
    //--------------------------------------------------------------------------
    public override void ApplyEncounterEntered()
    {
        for(int i = 0; i < Spikes_to_trigger.Length; i++){
            Spikes_to_trigger[i].Activate();
        }
    }
    //--------------------------------------------------------------------------
}
