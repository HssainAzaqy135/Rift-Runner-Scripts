using UnityEngine;

public class Point_In_Time
{
    public Vector3 Position;
    public Quaternion rotation;

    //--------------------------------------------------------------------------
    public Point_In_Time(Vector3 _Position, Quaternion _rotation){
        Position = _Position;
        rotation = _rotation;

    }
    //--------------------------------------------------------------------------
}
