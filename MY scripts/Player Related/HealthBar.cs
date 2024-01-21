using TMPro;

public class HealthBar : LoadingBar
{
    public Player player;
    public  TextMeshProUGUI lives_Text;
    //--------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        Bar.value = 1f;
    }
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        float value_to_show = ((float)player.getCurrLives())/((float)player.getMaxLives());
        ScaleBar(value_to_show);
        UpdateText();
    }
    //--------------------------------------------------------------------------
    void UpdateText(){
        lives_Text.text = player.getCurrLives().ToString();
    }
}
