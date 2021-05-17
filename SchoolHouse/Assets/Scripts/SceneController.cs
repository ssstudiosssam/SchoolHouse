using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // First scene
    private bool StartSceneDone = false;
    private bool T1 = false;

    public GameObject StartContent;
    public GameObject Room;
    public RoomFader RF;
    public GameObject MainContentDesk, MainContentFloating;
    public GameObject Narrative1Text;

    public GameObject selectionRing1;

    private float Audio1Length;

    public ContentManager CM;

    // Start is called before the first frame update
    void Start()
    {
        Audio1Length = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveStartScene()
    {
        if (StartSceneDone == false)
        {
            StartContent.SetActive(false);

            StartSceneDone = true;

            MainContentDesk.SetActive(true);
            MainContentFloating.SetActive(true);
            selectionRing1.SetActive(true);
            CM.menuVisible = true;
        }       
    }

    public void FirstSceneSetUp()
    {
        if (T1 == false)
        {
            Narrative1Text.SetActive(true);

            // Give time for audio to play
            Invoke("T1Scene", Audio1Length);

            T1 = true;
        }
    }

    private void T1Scene()
    {
        Narrative1Text.SetActive(false);
        Room.SetActive(true);
        RF.MakeFadingTrue();
    }

    public void BackFromT1()
    {
        T1 = false;

        RF.MakeFadingOutTrue();
    }
}
