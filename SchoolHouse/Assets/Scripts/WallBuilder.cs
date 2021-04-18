using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBuilder : MonoBehaviour
{
    // Change position and rotation of wall
    public void UpdateWallPosition(Transform PositionReference)
    {
        // Change wall position
        transform.position = new Vector3(PositionReference.position.x, 0, PositionReference.position.z);

        // Define wall rotation value
        Vector3 WallRotation = new Vector3(0, PositionReference.eulerAngles.y, 0);

        // Change wall rotation
        transform.rotation = Quaternion.Euler(WallRotation);
    }
}
