using UnityEngine;

public class Time_Alterer : EntryTriggerTrap
{
    public float Time_Mult = 0.5f;
    public bool Affects_Players = true;
    //--------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        if(Time_Mult < 0){
            Time_Mult = 1f;
        }
        if(Time_Mult == 0){
            Time_Mult = float.Epsilon;
        }
    }
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        
    }
    //--------------------------------------------------------------------------
    public override void ApplyEncounterEntered(){
        if(Entered_object.tag == "Player"){
            Player player = Entered_object.GetComponent<Player>();
            if(player){
                if(!Affects_Players){
                    player.SetSpeedMult(player.GetSpeedMult()/Time_Mult);
                }
            }
            Time.timeScale *= Time_Mult;
        }
    }
    //--------------------------------------------------------------------------
    public override void ApplyEncounterExited(){
        if(Entered_object.tag == "Player"){
            Player player = Entered_object.GetComponent<Player>();
            if(player){
                if(!Affects_Players){
                    player.SetSpeedMult(player.GetSpeedMult()*Time_Mult);
                }
            }
            Time.timeScale /= Time_Mult;
        }
    }
    //--------------------------------------------------------------------------

}
