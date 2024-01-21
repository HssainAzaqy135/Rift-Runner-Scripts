using TMPro;

public class TimeCapacityBar : LoadingBar
{
    public Player player;
    public  TextMeshProUGUI TimeCapacity_Text;
    //--------------------------------------------------------------------------
    private Rewinder rewinder;
    //--------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        Bar.value = 1f;
        rewinder = player.GetComponent<Rewinder>();
    }
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        float value_to_show = ((float)rewinder.GetCurrSavedTime())/((float)rewinder.GetMaxRewindCapacity());
        ScaleBar(value_to_show);
        UpdateText();
    }
    //--------------------------------------------------------------------------
    void UpdateText(){
        TimeCapacity_Text.text = rewinder.GetCurrSavedTime().ToString("f2");
    }
    //--------------------------------------------------------------------------
}
