using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    //--------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.position + offset;
    }
    //--------------------------------------------------------------------------
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.position + offset;
    }
    //--------------------------------------------------------------------------
}
