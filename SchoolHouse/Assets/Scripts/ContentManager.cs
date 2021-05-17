using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentManager : MonoBehaviour
{

    private int MenuOption1, MenuOption2;

    private int CurrentSelected;

    public Text MenuOptionText1, MenuOptionText2;

    public Text T1ImageText, T1VideoText, T1DocumentText, T2ImageText, T2VideoText, T2DocumentText, T3ImageText, T3VideoText, T3DocumentText, T4ImageText, T4VideoText, T4DocumentText;

    private int CurrentT1Image, CurrentT1Video, CurrentT1Document, CurrentT2Image, CurrentT2Video, CurrentT2Document, CurrentT3Image, CurrentT3Video, CurrentT3Document, CurrentT4Image, CurrentT4Video, CurrentT4Document;

    public GameObject[] T1Images; 

    public Transform[] Menu1Positions;
    public Transform[] Menu2Positions;

    public GameObject selectionRing1, selectionRing2;

    public bool menuVisible = false;

    public GameObject Menu1, Menu2, Menu3;

    public GameObject T1Options, T2Options, T3Options, T4Options;

    public GameObject T1ImageHolder, T1VideoHolder, T1DocumentHolder, T2ImageHolder, T2VideoHolder, T2DocumentHolder, T3ImageHolder, T3VideoHolder, T3DocumentHolder, T4ImageHolder, T4VideoHolder, T4DocumentHolder;

    public GameObject FloatingContent;

    public GameObject FloatingT1ImageHolder, FloatingT1VideoHolder, FloatingT1DocumentHolder, FloatingT2ImageHolder, FloatingT2VideoHolder, FloatingT2DocumentHolder, FloatingT3ImageHolder, FloatingT3VideoHolder, FloatingT3DocumentHolder, FloatingT4ImageHolder, FloatingT4VideoHolder, FloatingT4DocumentHolder;

    public SceneController SC;

    public Text PanelInstructionText;

    // Start is called before the first frame update
    void Start()
    {
        CurrentSelected = 1;

        MenuOption1 = 1;
        MenuOption2 = 1;

        ResetValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateMenuOption()
    {
        MenuOptionText1.text = MenuOption1.ToString() + ".";
        MenuOptionText2.text = MenuOption2.ToString() + ".";

        T1ImageText.text = CurrentT1Image.ToString();
        T1VideoText.text = CurrentT1Video.ToString();
        T1DocumentText.text = CurrentT1Document.ToString();

        T2ImageText.text = CurrentT2Image.ToString();
        T2VideoText.text = CurrentT2Video.ToString();
        T2DocumentText.text = CurrentT2Document.ToString();

        T3ImageText.text = CurrentT3Image.ToString();
        T3VideoText.text = CurrentT3Video.ToString();
        T3DocumentText.text = CurrentT3Document.ToString();

        T4ImageText.text = CurrentT4Image.ToString();
        T4VideoText.text = CurrentT4Video.ToString();
        T4DocumentText.text = CurrentT4Document.ToString();

        if (CurrentSelected == 1)
        {
            MenuOptionText1.color = Color.green;
            MenuOptionText2.color = Color.red;

            PanelInstructionText.text = "PICK A TIME IN HISTORY";
        }

        if (CurrentSelected == 2)
        {
            MenuOptionText1.color = Color.red;
            MenuOptionText2.color = Color.green;

            PanelInstructionText.text = "CHOOSE IMAGES, VIDEOS OR DOCUMENTS";
        }

        if (CurrentSelected == 3)
        {
            MenuOptionText1.color = Color.red;
            MenuOptionText2.color = Color.red;

            PanelInstructionText.text = "SCROLL THROUGH CONTENT";
        }

        ShowCorrectContent();
    }

    public void IncreaseCurrentSelected()
    {
        if (menuVisible == true)
        {
            if (CurrentSelected < 3)
            {
                CurrentSelected = CurrentSelected + 1;
            }

            UpdateMenuOption();
        }
    }

    public void DecreaseCurrentSelected()
    {
        if (menuVisible == true)
        {
            if (CurrentSelected > 1)
            {
                CurrentSelected = CurrentSelected - 1;
                MenuOption2 = 1;

                ResetValues();
            }

            // returning to main selection
            if (CurrentSelected == 1)
            {
                if (MenuOption1 == 1)
                {
                    SC.BackFromT1();
                }
            }

            UpdateMenuOption();
        }
    }

    public void IncreaseMenuOption()
    {
        if (menuVisible == true)
        {

            // T1 T2 T3 T4
            if (CurrentSelected == 1 && MenuOption1 < 4)
            {
                MenuOption1 = MenuOption1 + 1;
            }

            // IMAGES VIDEO DOCUMENTS
            if (CurrentSelected == 2 && MenuOption2 < 3)
            {
                MenuOption2 = MenuOption2 + 1;
            }

            // CURRENT MEDIA
            if (CurrentSelected == 3)
            {
                // if T1
                if (MenuOption1 == 1)
                {
                    // images
                    if (MenuOption2 == 1 && CurrentT1Image < T1Images.Length)
                    {
                        CurrentT1Image++;
                    }

                    // videos
                    if (MenuOption2 == 2 && CurrentT1Video < 10)
                    {
                        CurrentT1Video++;
                    }

                    // documents
                    if (MenuOption2 == 3 && CurrentT1Document < 10)
                    {
                        CurrentT1Document++;
                    }
                }

                // if T2
                if (MenuOption1 == 2)
                {
                    // images
                    if (MenuOption2 == 1 && CurrentT2Image < 10)
                    {
                        CurrentT2Image++;
                    }

                    // videos
                    if (MenuOption2 == 2 && CurrentT2Video < 10)
                    {
                        CurrentT2Video++;
                    }

                    // documents
                    if (MenuOption2 == 3 && CurrentT2Document < 10)
                    {
                        CurrentT2Document++;
                    }
                }

                // if T3
                if (MenuOption1 == 3)
                {
                    // images
                    if (MenuOption2 == 1 && CurrentT3Image < 10)
                    {
                        CurrentT3Image++;
                    }

                    // videos
                    if (MenuOption2 == 2 && CurrentT3Video < 10)
                    {
                        CurrentT3Video++;
                    }

                    // documents
                    if (MenuOption2 == 3 && CurrentT3Document < 10)
                    {
                        CurrentT3Document++;
                    }
                }

                // if T4
                if (MenuOption1 == 4)
                {
                    // images
                    if (MenuOption2 == 1 && CurrentT4Image < 10)
                    {
                        CurrentT4Image++;
                    }

                    // videos
                    if (MenuOption2 == 2 && CurrentT4Video < 10)
                    {
                        CurrentT4Video++;
                    }

                    // documents
                    if (MenuOption2 == 3 && CurrentT4Document < 10)
                    {
                        CurrentT4Document++;
                    }
                }
            }

            UpdateMenuOption();
        }
    }

    public void DecreaseMenuOption()
    {
        if (menuVisible == true)
        {
            // T1 T2 T3 T4
            if (CurrentSelected == 1 && MenuOption1 > 1)
            {
                MenuOption1 = MenuOption1 - 1;
            }

            // IMAGES VIDEO DOCUMENTS
            if (CurrentSelected == 2 && MenuOption2 > 1)
            {
                MenuOption2 = MenuOption2 - 1;
            }

            // CURRENT MEDIA
            if (CurrentSelected == 3)
            {
                // if T1
                if (MenuOption1 == 1)
                {
                    // images
                    if (MenuOption2 == 1 && CurrentT1Image > 1)
                    {
                        CurrentT1Image--;
                    }

                    // videos
                    if (MenuOption2 == 2 && CurrentT1Video > 1)
                    {
                        CurrentT1Video--;
                    }

                    // documents
                    if (MenuOption2 == 3 && CurrentT1Document > 1)
                    {
                        CurrentT1Document--;
                    }
                }

                // if T2
                if (MenuOption1 == 2)
                {
                    // images
                    if (MenuOption2 == 1 && CurrentT2Image > 1)
                    {
                        CurrentT2Image--;
                    }

                    // videos
                    if (MenuOption2 == 2 && CurrentT2Video > 1)
                    {
                        CurrentT2Video--;
                    }

                    // documents
                    if (MenuOption2 == 3 && CurrentT2Document > 1)
                    {
                        CurrentT2Document--;
                    }
                }

                // if T3
                if (MenuOption1 == 3)
                {
                    // images
                    if (MenuOption2 == 1 && CurrentT3Image > 1)
                    {
                        CurrentT3Image--;
                    }

                    // videos
                    if (MenuOption2 == 2 && CurrentT3Video > 1)
                    {
                        CurrentT3Video--;
                    }

                    // documents
                    if (MenuOption2 == 3 && CurrentT3Document > 1)
                    {
                        CurrentT3Document--;
                    }
                }

                // if T4
                if (MenuOption1 == 4)
                {
                    // images
                    if (MenuOption2 == 1 && CurrentT4Image > 1)
                    {
                        CurrentT4Image--;
                    }

                    // videos
                    if (MenuOption2 == 2 && CurrentT4Video > 1)
                    {
                        CurrentT4Video--;
                    }

                    // documents
                    if (MenuOption2 == 3 && CurrentT4Document > 1)
                    {
                        CurrentT4Document--;
                    }
                }
            }

            UpdateMenuOption();
        }
    }

    private void ShowCorrectContent()
    {
        if (menuVisible == true)
        {
            // First menu selection
            if (CurrentSelected == 1)
            {
                Menu1.SetActive(true);

                selectionRing1.SetActive(true);

                if (MenuOption1 == 1)
                {
                    selectionRing1.transform.position = Menu1Positions[0].position;
                }

                if (MenuOption1 == 2)
                {
                    selectionRing1.transform.position = Menu1Positions[1].position;
                }

                if (MenuOption1 == 3)
                {
                    selectionRing1.transform.position = Menu1Positions[2].position;
                }

                if (MenuOption1 == 4)
                {
                    selectionRing1.transform.position = Menu1Positions[3].position;
                }
            }
            else
            {
                Menu1.SetActive(false);

                selectionRing1.SetActive(false);
            }

            // Second menu selection
            if (CurrentSelected == 2)
            {
                Menu2.SetActive(true);

                selectionRing2.SetActive(true);

                // Show correct options
                // T1 Options
                if (MenuOption1 == 1)
                {
                    T1Options.SetActive(true);
                    SC.FirstSceneSetUp();
                }
                else
                {
                    T1Options.SetActive(false);
                }

                // T2 Options
                if (MenuOption1 == 2)
                {
                    T2Options.SetActive(true);
                }
                else
                {
                    T2Options.SetActive(false);
                }

                // T3 Options
                if (MenuOption1 == 3)
                {
                    T3Options.SetActive(true);
                }
                else
                {
                    T3Options.SetActive(false);
                }

                // T4 Options
                if (MenuOption1 == 4)
                {
                    T4Options.SetActive(true);
                }
                else
                {
                    T4Options.SetActive(false);
                }

                // Move cursor
                if (MenuOption2 == 1)
                {
                    selectionRing2.transform.position = Menu2Positions[0].position;
                }

                if (MenuOption2 == 2)
                {
                    selectionRing2.transform.position = Menu2Positions[1].position;
                }

                if (MenuOption2 == 3)
                {
                    selectionRing2.transform.position = Menu2Positions[2].position;
                }
            }
            else
            {
                Menu2.SetActive(false);

                selectionRing2.SetActive(false);
            }

            // Third menu selection
            if (CurrentSelected == 3)
            {

                Menu3.SetActive(true);
                FloatingContent.SetActive(true);

                // T1

                // T1 Images
                if (MenuOption1 == 1 && MenuOption2 == 1)
                {
                    T1ImageHolder.SetActive(true);
                    FloatingT1ImageHolder.SetActive(true);

                    for (int i = 0; i < T1Images.Length; i++)
                    {
                        if (i == CurrentT1Image - 1)
                        {
                            T1Images[i].SetActive(true);
                        }
                        else
                        {
                            T1Images[i].SetActive(false);
                        }
                    }
                }
                else
                {
                    T1ImageHolder.SetActive(false);
                    FloatingT1ImageHolder.SetActive(false);
                }

                // T1 Videos
                if (MenuOption1 == 1 && MenuOption2 == 2)
                {
                    T1VideoHolder.SetActive(true);
                    FloatingT1VideoHolder.SetActive(true);
                }
                else
                {
                    T1VideoHolder.SetActive(false);
                    FloatingT1VideoHolder.SetActive(false);
                }

                // T1 Docs
                if (MenuOption1 == 1 && MenuOption2 == 3)
                {
                    T1DocumentHolder.SetActive(true);
                    FloatingT1DocumentHolder.SetActive(true);
                }
                else
                {
                    T1DocumentHolder.SetActive(false);
                    FloatingT1DocumentHolder.SetActive(false);
                }

                // T2

                // T2 Images
                if (MenuOption1 == 2 && MenuOption2 == 1)
                {
                    T2ImageHolder.SetActive(true);
                    FloatingT2ImageHolder.SetActive(true);
                }
                else
                {
                    T2ImageHolder.SetActive(false);
                    FloatingT2ImageHolder.SetActive(false);
                }

                // T2 Videos
                if (MenuOption1 == 2 && MenuOption2 == 2)
                {
                    T2VideoHolder.SetActive(true);
                    FloatingT2VideoHolder.SetActive(true);
                }
                else
                {
                    T2VideoHolder.SetActive(false);
                    FloatingT2VideoHolder.SetActive(false);
                }

                // T2 Docs
                if (MenuOption1 == 2 && MenuOption2 == 3)
                {
                    T2DocumentHolder.SetActive(true);
                    FloatingT2DocumentHolder.SetActive(true);
                }
                else
                {
                    T2DocumentHolder.SetActive(false);
                    FloatingT2DocumentHolder.SetActive(false);
                }

                // T3

                // T3 Images
                if (MenuOption1 == 3 && MenuOption2 == 1)
                {
                    T3ImageHolder.SetActive(true);
                    FloatingT3ImageHolder.SetActive(true);
                }
                else
                {
                    T3ImageHolder.SetActive(false);
                    FloatingT3ImageHolder.SetActive(false);
                }

                // T3 Videos
                if (MenuOption1 == 3 && MenuOption2 == 2)
                {
                    T3VideoHolder.SetActive(true);
                    FloatingT3VideoHolder.SetActive(true);
                }
                else
                {
                    T3VideoHolder.SetActive(false);
                    FloatingT3VideoHolder.SetActive(false);
                }

                // T3 Docs
                if (MenuOption1 == 3 && MenuOption2 == 3)
                {
                    T3DocumentHolder.SetActive(true);
                    FloatingT3DocumentHolder.SetActive(true);
                }
                else
                {
                    T3DocumentHolder.SetActive(false);
                    FloatingT3DocumentHolder.SetActive(false);
                }

                // T4

                // T4 Images
                if (MenuOption1 == 4 && MenuOption2 == 1)
                {
                    T4ImageHolder.SetActive(true);
                    FloatingT4ImageHolder.SetActive(true);
                }
                else
                {
                    T4ImageHolder.SetActive(false);
                    FloatingT4ImageHolder.SetActive(false);
                }

                // T4 Videos
                if (MenuOption1 == 4 && MenuOption2 == 2)
                {
                    T4VideoHolder.SetActive(true);
                    FloatingT4VideoHolder.SetActive(true);
                }
                else
                {
                    T4VideoHolder.SetActive(false);
                    FloatingT4VideoHolder.SetActive(false);
                }

                // T4 Docs
                if (MenuOption1 == 4 && MenuOption2 == 3)
                {
                    T4DocumentHolder.SetActive(true);
                    FloatingT4DocumentHolder.SetActive(true);
                }
                else
                {
                    T4DocumentHolder.SetActive(false);
                    FloatingT4DocumentHolder.SetActive(false);
                }

            }
            else
            {
                Menu3.SetActive(false);
                FloatingContent.SetActive(false);
            }
        }
    }

    private void ResetValues()
    {
        CurrentT1Image = 1;
        CurrentT1Video = 1;
        CurrentT1Document = 1;

        CurrentT2Image = 1;
        CurrentT2Video = 1;
        CurrentT2Document = 1;

        CurrentT3Image = 1;
        CurrentT3Video = 1;
        CurrentT3Document = 1;

        CurrentT4Image = 1;
        CurrentT4Video = 1;
        CurrentT4Document = 1;
    }
}
