using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFader : MonoBehaviour
{
    public GameObject Room1;

    private Renderer rend;

    public Material RoomMaterial, RoomAlphaMaterial;

    private bool fading = false;

    private Color fade;

    public float FadeSpeed;

    void Awake()
    {
        rend = Room1.GetComponent<Renderer>();
        fade = RoomAlphaMaterial.color;
        fade.a = 0f;
        RoomAlphaMaterial.color = fade;
    }

    // Update is called once per frame
    void Update()
    {
        if (fading == true)
        {
            fade.a += FadeSpeed * Time.deltaTime;
            RoomAlphaMaterial.color = fade;
        }

        if (fading == true && fade.a > 1f)
        {
            fading = false;
            rend.material = RoomMaterial;
        }
    }

    public void MakeFadingTrue()
    {
        fading = true;
    }
}
