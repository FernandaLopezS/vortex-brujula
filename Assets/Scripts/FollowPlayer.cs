using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Player GameObject to follow.
    public GameObject player;
    public bool inheritRotation = false;

    // Camera offset from Player's position.
    public Vector3 offset = new Vector3(0, 6, -11);

    // LateUpdate is called once per frame after Update.
    void LateUpdate()
    {
        // Offset the camera behind the player by adding to the player's position.
        transform.position = player.transform.position + offset;
        if (inheritRotation)
        {
            // Rotate the camera to face the player.
            transform.rotation = player.transform.rotation;
        }
    }
}
