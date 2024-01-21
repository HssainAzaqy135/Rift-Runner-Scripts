using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    private bool isActive = true;
    //--------------------------------------------------------------------------
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public StopWatch Timer;
    public float PauseDelay;
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }else{
                Invoke("Pause",PauseDelay);
            }
        }
    }
    //--------------------------------------------------------------------------
    public void Resume(){
        GameIsPaused = false;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    //--------------------------------------------------------------------------
    public void Pause(){
        GameIsPaused = true;
        PauseMenuUI.SetActive(true);
        Timer.StopTimer();
        Time.timeScale = 0f;
    }
    //--------------------------------------------------------------------------
    public void SetActive(bool state){
        isActive = state;
    }
}
