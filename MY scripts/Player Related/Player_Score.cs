using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Score : MonoBehaviour
{
    public Player player;
    private int Final_Score;
    private float Max_Distance;
    private float Max_Distance_Score;
    private bool isActive = true;
     //--------------------------------------------------------------------------
    public TextMeshProUGUI Score_Text;
    public float Score_Per_Unit_Traveled;

    //--------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        Final_Score = 0;
    }
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        if(isActive){
            if(player.transform.position.z >= Max_Distance){
                Max_Distance = player.transform.position.z;
            }
            //-------------------------------------
            CalculateFinalScore();
            Score_Text.text = Final_Score.ToString();
        }
    }
    //--------------------------------------------------------------------------
    public virtual void CalculateFinalScore(){
        CalculateMaxDistanceScore();
        Final_Score = (int)(Max_Distance_Score);
    }
    //--------------------------------------------------------------------------
    public void CalculateMaxDistanceScore(){
            Max_Distance_Score = Max_Distance*Score_Per_Unit_Traveled;
    }
    //--------------------------------------------------------------------------
    public void SetActive(bool state){
        isActive = state;
    }
    //--------------------------------------------------------------------------
    public void SetScore(int new_score){
        Final_Score = new_score;
        Max_Distance = 0;
    }
    //--------------------------------------------------------------------------
}
