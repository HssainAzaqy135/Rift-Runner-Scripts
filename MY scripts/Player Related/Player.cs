using UnityEngine;

public class Player : MonoBehaviour
{
    //--------------------------------------------------------------------------
    public StopWatch Time_Elapsed_Timer;
    //--------------------------------------------------------------------------
    public Rigidbody Player_Body;
    public Vector3 respawn_position;
    //--------------------------------------------------------------------------
    public Transform groundCheck;
    public LayerMask groundMask;
    Vector3 ground_check_initial_position;
    float groundDistance;
    bool isGrounded;

    //--------------------------------------------------------------------------
    public int max_Lives;
    public int curr_Lives;
    private bool isDead = false;
    public bool isInvinsible = false;
    private float speed_mult = 1f;
    //--------------------------------------------------------------------------
    public float passive_force = 450f;
    public float forward_force = 450f;
    public float sideways_force = 600f;
    //--------------------------------------------------------------------------
    public float jump_force;
    public float jump_mult;
    //--------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        groundDistance = Mathf.Max(transform.localScale.x,transform.localScale.y,transform.localScale.z)/2 + 0.1f;
        curr_Lives = max_Lives;
        respawn_position = transform.position;
    }
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void FixedUpdate()
    {
        isDead = CheckIfDead();// checks if dead, reacts accordingly
        UpdateIfGrounded();// checks if grounded, affects jumping
        CheckIfFellOff();// checks if fell off
        CheckMovement();// checks movement input, reacts accordingly
    }
    //--------------------------------------------------------------------------
    void OnCollisionEnter(Collision collisionInfo){
        string collider_tag = collisionInfo.collider.tag;


    }
    //--------------------------------------------------------------------------
    void UpdateIfGrounded(){
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
    }
    //--------------------------------------------------------------------------
    void CheckMovement(){
        Player_Body.AddForce(0,0,passive_force*speed_mult*Time.deltaTime);
        
        if(Input.GetKey("w")){
            Player_Body.AddForce(0,0,forward_force*speed_mult*Time.deltaTime);
        }
        if(Input.GetKey("s")){
            Player_Body.AddForce(0,0,-2*forward_force*speed_mult*Time.deltaTime);
        }
        if(Input.GetKey("d")){
            Player_Body.AddForce(sideways_force*speed_mult*Time.deltaTime,0,0);
        }
        if(Input.GetKey("a")){
            Player_Body.AddForce(-sideways_force*speed_mult*Time.deltaTime,0,0);
        }
        if(Input.GetKey("space") && isGrounded){
            Player_Body.AddForce(0,jump_force*speed_mult*Time.deltaTime,0);
        }
    }
    //--------------------------------------------------------------------------
    public int getCurrLives(){
        return curr_Lives;
    }
    //--------------------------------------------------------------------------
    public int getMaxLives(){
        return max_Lives;
    }
    //--------------------------------------------------------------------------
    public bool CheckIfDead(){
        bool ret = false;
        if(curr_Lives == 0){
            ret = true;
        }
        return ret;
    }
    //--------------------------------------------------------------------------
    void CheckIfFellOff(){
        if(transform.position.y <= -10f){
            ReSpawn();
            takeDamage(1);
        }
    }
    //--------------------------------------------------------------------------
    public void Reset_Respawn_Position(Vector3 newPosition){
        respawn_position = newPosition;
    }
    //--------------------------------------------------------------------------
    public void ReSpawn(){
        Reset_Momentum();
        Reset_Rotation();
        Rewinder rewinder = GetComponent<Rewinder>();
        if(rewinder){
            float curr_rewind_capacity = rewinder.GetRewindCapacity();
            rewinder.DeActivate();
            rewinder.ResetRewinder();
            rewinder.setRewindCapacity(curr_rewind_capacity);
            rewinder.Invoke("Activate", curr_rewind_capacity);
        }
        transform.position = respawn_position;
    }
    //--------------------------------------------------------------------------
    public void Reset_Rotation(){
        transform.rotation = Quaternion. Euler(0, 0, 0);
    }
    //--------------------------------------------------------------------------
    public void Reset_Momentum(){
        Player_Body.velocity = Vector3.zero;
        Player_Body.angularVelocity = Vector3.zero;
    }
    //--------------------------------------------------------------------------
    public void Move_To(Vector3 Location){
        transform.position = Location;
    }
    //--------------------------------------------------------------------------
    public void takeDamage(int amount){
        if(isInvinsible){
            return;
        }
        
        if(amount>=0){
            curr_Lives-= amount;
            if(curr_Lives<=0){
                curr_Lives = 0;
            }
        }
    }
    //--------------------------------------------------------------------------
    public void Heal(int amount){
        if(amount>=0){
            curr_Lives+= amount;
            if(curr_Lives>=max_Lives){
                curr_Lives = max_Lives;
            }
        }
    }
    //--------------------------------------------------------------------------
    public void SetSpeedMult(float new_speed_mult){
        speed_mult = new_speed_mult;
    }
    //--------------------------------------------------------------------------
    public float GetSpeedMult(){
        return speed_mult;
    }
    //--------------------------------------------------------------------------
}
