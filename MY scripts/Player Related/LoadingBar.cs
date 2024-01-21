using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Slider Bar;
    public float SmoothSpeed = 30f;
    float currVelocity = 0f;
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {

    }
    //--------------------------------------------------------------------------
    public virtual void ScaleBar(float value_to_show){
        float currValue = Mathf.SmoothDamp(Bar.value,value_to_show,ref currVelocity,SmoothSpeed*Time.deltaTime);
        Bar.value = currValue;
    }
}
