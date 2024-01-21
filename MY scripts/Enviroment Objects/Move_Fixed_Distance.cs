using System.Collections;
using UnityEngine;

public class Move_Fixed_Distance : MonoBehaviour
{
    public Vector3 DistanceToMoveXYZ;
    public float Move_speed = 1f;
    public bool BackAndForth;
    public bool isActive = true;
    public float Deactivation_distance = 0.5f;
    private Vector3 Min;
    private Vector3 Max;

    //--------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        //-----------------TO deal with pingpong-------------------
        float Ep = 0.0001f;
        if(DistanceToMoveXYZ.x == 0){
            DistanceToMoveXYZ.x = Ep;
        }
        if(DistanceToMoveXYZ.y == 0){
            DistanceToMoveXYZ.y = Ep;
        }
        if(DistanceToMoveXYZ.z == 0){
            DistanceToMoveXYZ.z = Ep;
        }
        if(Deactivation_distance < Ep*10){
            Deactivation_distance = Ep*10;
        }
        //---------------------------------------------------------
        Min = transform.position;
        Max = transform.position + DistanceToMoveXYZ;

    }
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void FixedUpdate()
    {
        if(isActive){
            Move(BackAndForth);
        }
    }
    //--------------------------------------------------------------------------
    public void Move(bool is_Back_And_Forth){
        MoveInStraightLines();

        if(CloseEnough(transform.position , Max)){
            if(!is_Back_And_Forth){
            DeActivate();
            }
        }
    }
    //--------------------------------------------------------------------------
    public void MoveInStraightLines(){
        //PingPong doesn't like negative numbers , needed adjusting
        float X_value = Mathf.Sign(DistanceToMoveXYZ.x)*Mathf.PingPong(Time.time*Move_speed,Mathf.Abs(DistanceToMoveXYZ.x)) + Min.x;
        float Y_value = Mathf.Sign(DistanceToMoveXYZ.y)*Mathf.PingPong(Time.time*Move_speed,Mathf.Abs(DistanceToMoveXYZ.y)) + Min.y;
        float Z_value = Mathf.Sign(DistanceToMoveXYZ.z)*Mathf.PingPong(Time.time*Move_speed,Mathf.Abs(DistanceToMoveXYZ.z)) + Min.z;
        transform.position = new Vector3 (X_value,Y_value,Z_value);
    }
    //--------------------------------------------------------------------------
    public void Activate(){
        isActive =true;
    }
    //--------------------------------------------------------------------------
    public void DeActivate(){
        isActive =false;
    }
    //--------------------------------------------------------------------------
    bool CloseEnough(Vector3 V1,Vector3 V2){
        Vector3 V3 = V1-V2;
        bool ret = false;
        if(Mathf.Abs(V3.x) <= Deactivation_distance && Mathf.Abs(V3.y) <= Deactivation_distance &&
                                                       Mathf.Abs(V3.z) <= Deactivation_distance){
            ret = true;
        }
        return ret;
    }

}
