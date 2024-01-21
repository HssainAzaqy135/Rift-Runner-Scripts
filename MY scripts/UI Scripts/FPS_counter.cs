using UnityEngine;
using TMPro;

public class FPS_counter : MonoBehaviour
{
    public TextMeshProUGUI Fps_Text;
    private float polling_time = 1f;
    private float time;
    private int frame_count; 
    private bool isActive = true;
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        if(isActive){
            time += Time.deltaTime;
            frame_count++;
            if(time >= polling_time){
                int frame_rate = Mathf.RoundToInt(frame_count/time);
                Fps_Text.text = frame_rate.ToString();
                time -= polling_time;
                frame_count = 0;
            }
        }
    }
    //--------------------------------------------------------------------------
    public void SetActive(bool state){
        isActive = state;
    }
}
