using UnityEngine;

public class Vortex_Trap : EnviromentObject
{
    public string ToPullTag = "Player";
    public float pull_force = 800f;
    public float pull_radius = 2f;
    private Rigidbody ToPull;
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void FixedUpdate()
    {
        if(ToPull){
            if(Vector3.Distance(ToPull.transform.position, transform.position)<= pull_radius){
                ApplyEncounter();
            }
        }
    }
    //--------------------------------------------------------------------------
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ToPullTag){
            ToPull = other.GetComponent<Rigidbody>();
        }
    }
    //--------------------------------------------------------------------------
    public override void ApplyEncounter(){
        ToPull.AddForce(pull_force*(transform.position - ToPull.transform.position).normalized*Time.fixedDeltaTime);
    }
}
