using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingContentManager : MonoBehaviour
{

    public GameObject T1Content, T2Content, T3Content, T4Content;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Section1")
        {
            T1Content.SetActive(true);
        }

        if (other.tag == "Section2")
        {
            T2Content.SetActive(true);
        }

        if (other.tag == "Section3")
        {
            T3Content.SetActive(true);
        }

        if (other.tag == "Section4")
        {
            T4Content.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Section1")
        {
            T1Content.SetActive(false);
        }

        if (other.tag == "Section2")
        {
            T2Content.SetActive(false);
        }

        if (other.tag == "Section3")
        {
            T3Content.SetActive(false);
        }

        if (other.tag == "Section4")
        {
            T4Content.SetActive(false);
        }
    }
}
