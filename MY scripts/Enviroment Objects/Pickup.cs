using UnityEngine;

public class Pickup : EntryTriggerTrap
{
    protected bool isActive = true;
    protected MeshRenderer mesh_Renderer;
    //--------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }
    //--------------------------------------------------------------------------
    public void SetActive(bool state){
        isActive = state;
        if(mesh_Renderer){
            if(isActive){
                mesh_Renderer.enabled = true;
            }else{
                mesh_Renderer.enabled = false;
            }
        }
    }
    //--------------------------------------------------------------------------
}