using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLimit : MonoBehaviour
{

    [SerializeField]
    private GameObject maxPos, minPos;

    //public GameObject originalPosition;

    //private float minDistance;
    //private float maxDistance;

    void Awake()
    {
        //minDistance = Vector3.Distance(maxPos.transform.position, transform.position);

        //maxDistance = maxPos.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Vector3.Distance(maxPos.transform.position, transform.position) >= minDistance)
        {
            transform.position = originalPosition.transform.position;
        }

        if (transform.position.y <= maxDistance)
        {
            transform.position = new Vector3(transform.position.x, maxDistance, transform.position.z);
        }
        */

        if (transform.position.y >= minPos.transform.position.y)
        {
            transform.position = minPos.transform.position;
        }

        if (transform.position.y <= maxPos.transform.position.y)
        {
            transform.position = maxPos.transform.position;
        }
    }
}
