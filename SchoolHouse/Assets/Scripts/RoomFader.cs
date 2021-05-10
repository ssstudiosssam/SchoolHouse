using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFader : MonoBehaviour
{
    public GameObject Room1, Hallway1, Outside1;

    private Renderer RoomRend, HallwayRend, OutsideRend;

    public Material RoomMaterial, RoomAlphaMaterial, HallwayMaterial, HallwayAlphaMaterial, OutsideMaterial, OutsideAlphaMaterial;

    private bool fadingIn = false;

    private Color RoomFade, HallwayFade, OutsideFade;

    public float FadeSpeed;

    void Awake()
    {
        RoomRend = Room1.GetComponent<Renderer>();
        HallwayRend = Hallway1.GetComponent<Renderer>();
        OutsideRend = Outside1.GetComponent<Renderer>();

        RoomFade = RoomAlphaMaterial.color;
        HallwayFade = HallwayAlphaMaterial.color;
        OutsideFade = OutsideAlphaMaterial.color;

        RoomFade.a = 0f;
        HallwayFade.a = 0f;
        OutsideFade.a = 0f;

        RoomAlphaMaterial.color = RoomFade;
        HallwayAlphaMaterial.color = HallwayFade;
        OutsideAlphaMaterial.color = OutsideFade;
    }

    // Update is called once per frame
    void Update()
    {

        // Fade room in
        if (fadingIn == true)
        {
            RoomRend.material = RoomAlphaMaterial;
            HallwayRend.material = HallwayAlphaMaterial;
            OutsideRend.material = OutsideAlphaMaterial;

            RoomFade.a += FadeSpeed * Time.deltaTime;
            HallwayFade.a += FadeSpeed * Time.deltaTime;
            OutsideFade.a += FadeSpeed * Time.deltaTime;

            RoomAlphaMaterial.color = RoomFade;
            HallwayAlphaMaterial.color = HallwayFade;
            OutsideAlphaMaterial.color = OutsideFade;
        }

        // Change to standard shader texture when finished fading
        if (fadingIn == true && RoomFade.a > 1f)
        {
            fadingIn = false;
            RoomRend.material = RoomMaterial;
            HallwayRend.material = HallwayMaterial;
            OutsideRend.material = OutsideMaterial;
        }
    }

    public void MakeFadingTrue()
    {
        fadingIn = true;
    }

    public void SetUpFade()
    {
        RoomRend.material = RoomAlphaMaterial;
        HallwayRend.material = HallwayAlphaMaterial;
        OutsideRend.material = OutsideAlphaMaterial;
    }

}
