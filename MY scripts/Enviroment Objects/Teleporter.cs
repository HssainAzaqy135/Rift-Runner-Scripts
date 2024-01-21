using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : EntryTriggerTrap
{
    private Player player;
    //--------------------------------------------------------------------------
    public Transform Teleport_Pad;
    public Vector3 Teleport_Offset;
    public bool reset_momentum_on_teleport;
    //--------------------------------------------------------------------------
    public override void ApplyEncounterEntered(){
        if(Entered_object.tag == "Player"){
            player = Entered_object.gameObject.GetComponent<Player>();
        }
        if(player){
            if(reset_momentum_on_teleport){
                player.Reset_Momentum();
            }
            player.Reset_Rotation();
            player.Move_To(Teleport_Pad.position + Teleport_Offset);
        }else{
            Entered_object.transform.position = Teleport_Pad.position + Teleport_Offset;
        }
    }
    //--------------------------------------------------------------------------
}
