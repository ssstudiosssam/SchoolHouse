using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // First scene
    private bool FirstScene = false;
    public GameObject StartContent;
    public GameObject Room;
    public RoomFader RF;
    public GameObject MainContentDesk, MainContentFloating;
    public GameObject Narrative1Text;

    public GameObject pointer1;

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
        if (FirstScene == false)
        {
            StartContent.SetActive(false);
            Narrative1Text.SetActive(true);

            FirstScene = true;

            // Give time for audio to play
            Invoke("FirstSceneSetUp", Audio1Length);
        }       
    }

    private void FirstSceneSetUp()
    {
        Narrative1Text.SetActive(false);
        Room.SetActive(true);
        RF.MakeFadingTrue();
        MainContentDesk.SetActive(true);
        MainContentFloating.SetActive(true);
        pointer1.SetActive(true);
        CM.menuVisible = true;
    }
}
