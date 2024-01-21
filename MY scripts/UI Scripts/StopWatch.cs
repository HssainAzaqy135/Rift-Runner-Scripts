using System;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
    public Text timerText;
    public bool isActive;
    float currTime;
    public string Seperator;

    //--------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {

    }
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        if(!isActive){
            StartTimer();
        }else{
            UpdateTime();
        }
    }
    //--------------------------------------------------------------------------
    void UpdateTime(){
        currTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currTime);

        String Seconds  = time.Seconds.ToString();
        String Minutes  = time.Minutes.ToString();
        String Hours  = time.Hours.ToString();

        if(time.Seconds < 10){
            Seconds  = "0" + Seconds;
        } 
        if(time.Minutes < 10){
            Minutes  = "0" + Minutes;
        }
        if(time.Hours < 10){
            Hours  = "0" + Hours;
        }

        timerText.text = Hours + Seperator + Minutes + Seperator + Seconds;
    }
    //--------------------------------------------------------------------------
    public void StartTimer(){
        isActive = true;
    }
    //--------------------------------------------------------------------------
    public void StopTimer(){
        isActive = false;
    }
    //--------------------------------------------------------------------------
    public void ResetTimer(){
        currTime = 0;
    }
}
