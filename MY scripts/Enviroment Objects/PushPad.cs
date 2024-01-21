using UnityEngine;
using System;

public class PushPad : MonoBehaviour
{
    public Vector3 Force_direction;
    public float Push_Force;
    public bool IsRandomX;
    public float RandomXMult;
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
    void OnCollisionEnter( Collision collisionInfo){
        
        System.Random rx = new System.Random();
        float f = (float)(rx.NextDouble()*2-1)*RandomXMult;
        
        Vector3 RandomOffset = new Vector3(f, 0, 0);
        collisionInfo.rigidbody.AddForce((Force_direction.normalized + Convert.ToInt16(IsRandomX)*RandomOffset) *Push_Force );
    }
    //--------------------------------------------------------------------------

}
