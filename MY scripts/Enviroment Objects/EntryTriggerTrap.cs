using UnityEngine;

public class EntryTriggerTrap : MonoBehaviour
{
    public float Trigger_delay = 0f;
    protected Collider Entered_object;
    protected Collider Exited_object;
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
    private void OnTriggerEnter(Collider collider){
        Entered_object = collider;
        Invoke("ApplyEncounterEntered",Trigger_delay);
    }
    //--------------------------------------------------------------------------
    private void OnTriggerExit(Collider collider)
    {
        Entered_object = collider;
        Invoke("ApplyEncounterExited",Trigger_delay);
    }
    //--------------------------------------------------------------------------
    public virtual void ApplyEncounterEntered(){

    }
    //--------------------------------------------------------------------------
    public virtual void ApplyEncounterExited(){

    }
    //--------------------------------------------------------------------------
}
