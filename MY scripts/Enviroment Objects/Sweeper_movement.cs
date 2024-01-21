using System.Collections;
using UnityEngine;

public class Sweeper_movement : MonoBehaviour
{
    public float move_speed_mult;
    public float distance_to_cover;
    public bool isActive = true;
    //--------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {

    }
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void FixedUpdate()
    {
        MoveTrap();
    }
    //--------------------------------------------------------------------------
    public void MoveTrap(){
        if(isActive){
            transform.Translate(transform.right*distance_to_cover*Mathf.Cos(Time.time*move_speed_mult)*Time.deltaTime);
        } 
    }
}
