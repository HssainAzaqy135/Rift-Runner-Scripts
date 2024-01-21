
public class Level_Loader : Loading_Trigger
{
    public GameManager gameManager;
    public string level_to_load;
    public string level_to_unload;
    //--------------------------------------------------------------------------
    void Start()
    {
        DeActivateObjects();
    }
    //--------------------------------------------------------------------------
    void Update()
    {
        
    }
    //--------------------------------------------------------------------------
    public override void CollisionTrigger(){
        Invoke("Load",Load_delay);
        Invoke("Unload",Unload_delay);
    }
    //--------------------------------------------------------------------------
    public override void Load()
    {
        gameManager.loadLevelByName(level_to_load);
        gameManager.SetCurrentLevelIndex(gameManager.getLevelIndex(level_to_load));
        
    }
    //--------------------------------------------------------------------------
    public override void Unload()
    {
        gameManager.unloadLevelByName(level_to_unload);
    }
}
