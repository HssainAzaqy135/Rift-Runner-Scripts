using UnityEngine;

public class Hp_Fragment : Pickup
{
    public int HP_To_Heal  = 1;
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
                Player player = Entered_object.GetComponent<Player>();
                if(player){
                    player.Heal(HP_To_Heal);
                    SetActive(false);
                }
            }
        }
    }
    //--------------------------------------------------------------------------
}
