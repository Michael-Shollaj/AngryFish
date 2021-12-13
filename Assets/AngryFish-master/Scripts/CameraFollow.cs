using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFollowing)
        {
            if (BirdToFollow != null) //bird will be destroyed if it goes out of the scene
            {
                var birdPosition = BirdToFollow.transform.position;
                float x = Mathf.Clamp(birdPosition.x, minCameraX, maxCameraX);
                //camera follows bird's x position
                transform.position = new Vector3(x, StartingPosition.y, StartingPosition.z);
            }
            else
                IsFollowing = false;
        }
    }

    [HideInInspector]
    public Vector3 StartingPosition;


    public const float minCameraX = 0;
    public const float maxCameraX = 50;

    [HideInInspector]
    public bool IsFollowing;
    [HideInInspector]
    public Transform BirdToFollow;
}
