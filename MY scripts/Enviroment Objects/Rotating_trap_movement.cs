using System.Collections;
using UnityEngine;

public class Rotating_trap_movement : MonoBehaviour
{
    public Transform[] walls;
    public bool rotating_walls;
    public bool rotating_frame;
    public float frame_rotation_speed;
    public float wall_rotation_speed;

    //--------------------------------------------------------------------------
    private int num_of_walls;
    //--------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        num_of_walls = walls.Length;
    }
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void FixedUpdate()
    {
        RotateTrap();
    }
    //--------------------------------------------------------------------------
    public void RotateTrap(){
        for(int i = 0; i < num_of_walls;i++){
            if(rotating_walls){
                walls[i].Rotate(0,0,360*wall_rotation_speed*Time.deltaTime);
            }
            if(rotating_frame){
                transform.Rotate(0,0,360*frame_rotation_speed*Time.deltaTime);
            }
        }
    }
}
