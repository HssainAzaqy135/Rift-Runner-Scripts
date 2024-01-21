using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    private bool isActive = true;
    //--------------------------------------------------------------------------
    public GameObject StartMenuUI;
    public PauseScreen PauseScreen;
    public PlayerUI playerUI;
    public StopWatch Timer;
    //--------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        ActivateStartScreen();
    }
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        
    }
    //--------------------------------------------------------------------------
    public void DeActivateStartScreen(){
        playerUI.TurnOn();
        StartMenuUI.SetActive(false);
        PauseScreen.Resume();
        Timer.ResetTimer();
        isActive = false;
    }
    //--------------------------------------------------------------------------
    public void ActivateStartScreen(){
        playerUI.ShutDown();
        StartMenuUI.SetActive(true);
        PauseScreen.Resume();
        Timer.StopTimer();
        Timer.ResetTimer();
        isActive = true;
        Time.timeScale = 0f;
    }
    //--------------------------------------------------------------------------
    public void SetActive(bool state){
        isActive = state;
    }
}
