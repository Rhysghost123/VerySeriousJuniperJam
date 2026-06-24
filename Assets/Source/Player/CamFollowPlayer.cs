using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CameraPos = Camera.transform.position;
        CameraPos = Player.transform.position; // better than parenting the 2, then the rotation gets fucked
        CameraPos.z -= 10;

        //Camera.transform.position = CameraPos;
    }
}
