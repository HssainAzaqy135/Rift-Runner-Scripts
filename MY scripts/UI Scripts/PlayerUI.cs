using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private bool isActive = true;
    //--------------------------------------------------------------------------
    public GameObject The_UI;
    public StopWatch TimeElapsed;
    public FPS_counter fps_Counter;
    public HealthBar healthBar;
    public Player_Score player_Score;
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
    //--------------------------------------------------------------------------
    public void ShutDown(){
        TimeElapsed.StopTimer();
        TimeElapsed.ResetTimer();
        fps_Counter.SetActive(false);
        player_Score.SetActive(false);
        //----------------------------------
        The_UI.SetActive(false);
        isActive = false;
    }
    //--------------------------------------------------------------------------
    public void TurnOn(){
        TimeElapsed.StartTimer();
        TimeElapsed.ResetTimer();
        fps_Counter.SetActive(true);
        player_Score.SetActive(true);
        //----------------------------------
        The_UI.SetActive(true);
        isActive = true;
    }
    //--------------------------------------------------------------------------
    public void SetActive(bool state){
        isActive = state;
    }
}
