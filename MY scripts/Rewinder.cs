using System.Collections.Generic;
using UnityEngine;

public class Rewinder : MonoBehaviour
{
    private bool isRewinding;
    private bool CanRewind = false;
    private List<Point_In_Time> points;
    private float max_save_limit = 6f;
    private float time_save_limit = 3f;
    private float curr_saved_time = 0f;
    private int save_internal_counter = 0;
    private int rewind_internal_counter = 0;
    private Rigidbody rb;
    //--------------------------------------------------------------------------
    public KeyCode RewindKey = KeyCode.R;//should be a keycode
    public float Starting_Time_Capacity = 3f;
    public int Rewind_regulator = 1;
    public bool isActive = true;
    public GameObject[] ToEnableWhileRewinding;

    //--------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        if(Rewind_regulator < 1){
            Rewind_regulator = 1;
        }
        setRewindCapacity(Starting_Time_Capacity);
        rb = GetComponent<Rigidbody>();
        points = new List<Point_In_Time>();
    }
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        if(isActive){
            if(Input.GetKeyDown(RewindKey) && CanRewind){
                EnableOnRewind();
                StartRewind();
            }
            if(Input.GetKeyUp(RewindKey)){
                DisableOutOfRewind();
                StopRewind();
            }
        }
        curr_saved_time = (points.Count - 1)*Time.fixedDeltaTime*Rewind_regulator;
        UpdateCanRewind();
    }
    //--------------------------------------------------------------------------
    void FixedUpdate()
    {
        if(isRewinding && isActive){
            Rewind();
        }else{
            RecordPointsInTime();
        }
    }
    //--------------------------------------------------------------------------
    void Rewind(){
        if(points.Count > 0){
            if(((rewind_internal_counter + 1) % Rewind_regulator) == 0 ){
                Point_In_Time point = points[0];
                transform.position = point.Position;
                transform.rotation = point.rotation;
                points.RemoveAt(0);
                //-------------------------
                time_save_limit = curr_saved_time;
                //-------------------------
            }
            rewind_internal_counter ++;
        }else{
            StopRewind();
        }
    }
    //--------------------------------------------------------------------------
    void RecordPointsInTime(){
        if(points.Count > Mathf.RoundToInt(time_save_limit / (Time.fixedDeltaTime * Rewind_regulator))){
            points.RemoveAt(points.Count -1);
        }

        if(((save_internal_counter + 1) % Rewind_regulator) == 0 ){
            points.Insert(0, new Point_In_Time(transform.position,transform.rotation));
            save_internal_counter = 0;
        }
        save_internal_counter ++;
    }
    //--------------------------------------------------------------------------
    public void StartRewind(){
        isRewinding = true;
        rb.isKinematic = true;
    }
    //--------------------------------------------------------------------------
    public void StopRewind(){
        isRewinding = false;
        rb.isKinematic = false;
    }
    //--------------------------------------------------------------------------
    public void ResetRewinder(){
        points = new List<Point_In_Time>();
    }
    //--------------------------------------------------------------------------
    public void setRewindCapacity(float new_time_save_limit){
        if(new_time_save_limit < time_save_limit){
            points = points.GetRange(0,Mathf.RoundToInt(new_time_save_limit / (Time.fixedDeltaTime * Rewind_regulator)));
        }
        time_save_limit = Mathf.Min(max_save_limit,new_time_save_limit);
    }
    //--------------------------------------------------------------------------
    public float GetCurrSavedTime(){
        return curr_saved_time;
    }
    //--------------------------------------------------------------------------
    public float GetRewindCapacity(){
        return time_save_limit;
    }
    //--------------------------------------------------------------------------
    public float GetMaxRewindCapacity(){
        return max_save_limit;
    }
    //--------------------------------------------------------------------------
    public void SetActive(bool state){
        isActive = state;
    }
    //--------------------------------------------------------------------------
    public void Activate(){
        isActive = true;
    }
    //--------------------------------------------------------------------------
    public void DeActivate(){
        isActive = false;
    }
    //--------------------------------------------------------------------------
    private void UpdateCanRewind(){
        if (curr_saved_time <=0){
            CanRewind = false;
            DisableOutOfRewind();
        }else{
            CanRewind = true;
        }
    }
    //--------------------------------------------------------------------------
    private void EnableOnRewind(){
        int num_of_items = ToEnableWhileRewinding.Length;
        for(int i = 0 ; i < num_of_items ; i++){
            if(!ToEnableWhileRewinding[i].active){
                ToEnableWhileRewinding[i].SetActive(true);
            }
        }
    }
    //--------------------------------------------------------------------------
    private void DisableOutOfRewind(){
        int num_of_items = ToEnableWhileRewinding.Length;
        for(int i = 0 ; i < num_of_items ; i++){
            if(ToEnableWhileRewinding[i].active){
                ToEnableWhileRewinding[i].SetActive(false);
            }
        }
    }
    //--------------------------------------------------------------------------
}
