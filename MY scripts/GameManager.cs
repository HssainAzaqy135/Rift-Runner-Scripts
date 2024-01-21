using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

//--------------------------------------------------------------------------
public enum GameState{
    GamePlaying,
    GameOver,
    GamePaused,
    StartScreen
}
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState gameState;
    public StartScreen startScreen;
    public PauseScreen pauseScreen;
    public PlayerUI playerUI;
    //--------------------------------------------------------------------------
    public string[] level_names;
    public Vector3[] level_Spawns;
    public int curr_Level_index = 0;
    public Player player;
    //--------------------------------------------------------------------------
    private int num_of_levels;
    //--------------------------------------------------------------------------
    void Awake(){
        Instance = this;
    }
    //--------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        //------------------------------------
        loadLevelByName(level_names[0]);
        num_of_levels = level_names.Length;
        curr_Level_index = 0;
        UpdatePlayerRespawn();
        //------------------------------------
        startScreen.enabled = true;
        startScreen.ActivateStartScreen();
        Time.timeScale = 1;
        pauseScreen.PauseMenuUI.SetActive(false);
        playerUI.ShutDown();
        //------------------------------------
        ResetPlayer();
        player.ReSpawn();
        //------------------------------------
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
    }
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        UpdatePlayerRespawn();
        UpdateGameStatusRealtime();
        UpdateCursor();
        if(gameState == GameState.GameOver){
            ReStartRun();
            MovePlayerToLevel(0);
        }
        
    }
    //--------------------------------------------------------------------------
    void UpdateCursor(){
        if(gameState == GameState.GamePaused){
            Cursor.lockState = CursorLockMode.Confined;
        }
        if(gameState == GameState.GamePlaying){
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    //--------------------------------------------------------------------------
    void ResetPlayer(){
        player.curr_Lives = player.max_Lives;
        playerUI.player_Score.SetScore(0);
        Rewinder rewinder = player.GetComponent<Rewinder>();
        if(rewinder){
            rewinder.setRewindCapacity(rewinder.Starting_Time_Capacity);
        }
    }
    //--------------------------------------------------------------------------
    void UpdateGameStatusRealtime(){

        if(startScreen.StartMenuUI.active){
            UpdateGameState(GameState.StartScreen);
        }
        else if(pauseScreen.PauseMenuUI.active){
            UpdateGameState(GameState.GamePaused);
        }else{
            UpdateGameState(GameState.GamePlaying);
        }

        if(player.CheckIfDead()){
            UpdateGameState(GameState.GameOver);
        }
    }
    //--------------------------------------------------------------------------
    public void ReStartRun(){

        num_of_levels = level_names.Length;
        curr_Level_index = 0;
        UpdatePlayerRespawn();
        //------------------------------------
        startScreen.enabled = true;
        startScreen.ActivateStartScreen();
        pauseScreen.PauseMenuUI.SetActive(false);
        playerUI.ShutDown();
        //------------------------------------
        ResetPlayer();
        player.ReSpawn();
        //------------------------------------
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
    }
    //--------------------------------------------------------------------------
    public void MovePlayerToLevel(string level_name){

        int level_index = getLevelIndex("lvl" + level_name);
        
        if(level_index >= 0 && level_index <= curr_Level_index){
            player.Reset_Respawn_Position(level_Spawns[level_index]);

            for (int i = 0 ; i < num_of_levels ; i++){
                unloadLevelByName(level_names[i]);
            }
            curr_Level_index = level_index;
            loadLevelByName(level_names[curr_Level_index]);
            player.ReSpawn();
        }else{
            Debug.Log("invalid level index, index should be between 0 <-> current level.");
        }
    }
    //--------------------------------------------------------------------------
    public void MovePlayerToLevel(int level_index){

        if(level_index >= 0 && level_index <= curr_Level_index){
            player.Reset_Respawn_Position(level_Spawns[level_index]);

            for (int i = 0 ; i < num_of_levels ; i++){
                unloadLevelByName(level_names[i]);
            }
            curr_Level_index = level_index;
            loadLevelByName(level_names[curr_Level_index]);
            player.ReSpawn();
        }else{
            Debug.Log("invalid level index, index should be between 0 <-> current level.");
        }
    }
    //--------------------------------------------------------------------------
    public void UpdateGameState(GameState state){
        gameState = state;
    }
    //--------------------------------------------------------------------------
    public void UpdatePlayerRespawn(){
        player.Reset_Respawn_Position(level_Spawns[curr_Level_index]);
    }
    //--------------------------------------------------------------------------
    public string getCurrentLevelName(){
        return level_names[curr_Level_index];
    }
    //--------------------------------------------------------------------------
    public int getLevelIndex(string level_name){
        for(int i = 0 ; i< num_of_levels ; i++){
            if(level_name == level_names[i]){
                return i;
            }
        }
        return -1; //invalid index
    }
    //--------------------------------------------------------------------------
    public void loadLevelByName(string scene_to_load){
        if(!SceneManager.GetSceneByName(scene_to_load).isLoaded){
            SceneManager.LoadSceneAsync(scene_to_load,LoadSceneMode.Additive);
        }
        curr_Level_index = System.Array.IndexOf(level_names,scene_to_load);
    }
    //--------------------------------------------------------------------------
    public void unloadLevelByName(string scene_to_unload){
        if(SceneManager.GetSceneByName(scene_to_unload).isLoaded){
            SceneManager.UnloadSceneAsync(scene_to_unload);
        }
    }
    //--------------------------------------------------------------------------
    public string getLevelName(int index){
        return level_names[index];
    }
    //--------------------------------------------------------------------------
    public void SetCurrentLevelIndex(int index){
        if(index >= 0 && index < num_of_levels){
            curr_Level_index = index;
        }else{
            Debug.Log("invalid level index, previous index not changed");
        }
    }
    //--------------------------------------------------------------------------
    public void QuitGame(){
        Application.Quit(0);
    }
}
