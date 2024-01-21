using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene_Loading_Trigger : Loading_Trigger
{
    //--------------------------------------------------------------------------
    public string scene_to_load;
    public string scene_to_unload;
    //--------------------------------------------------------------------------
    void Start()
    {

    }
    //--------------------------------------------------------------------------
    void Update()
    {
        
    }
    //--------------------------------------------------------------------------
    public override void Load(){
        if(!SceneManager.GetSceneByName(scene_to_load).isLoaded){
            SceneManager.LoadSceneAsync(scene_to_load,LoadSceneMode.Additive);
        }
    }
    //--------------------------------------------------------------------------
    public override void Unload(){
        if(SceneManager.GetSceneByName(scene_to_unload).isLoaded){
            SceneManager.UnloadSceneAsync(scene_to_unload);
        }
    }
    //--------------------------------------------------------------------------
}
