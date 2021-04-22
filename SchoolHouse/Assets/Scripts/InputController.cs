using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{

    public Transform Oculus_ReferencePosition;
    public Transform Oculus2_ReferencePosition;

    public WallBuilder _wallBuilder;
    public DeskBuilder _deskBuilder;
    public ChairBuilder _chairBuilder;

    private Transform ReferencePosition;

    private int BuildStage;

    public GameObject InstructionCanvas;

    public GameObject Ins1, Ins2, Ins3, Ins4, Ins5, Ins6, Ins7, Ins8, Ins9, Ins10, Ins11, Ins12;

    public GameObject Wall, Desk, Chair;

    public GameObject AttachReference, GlobalReference;

    public GameObject LaserPointer;

    public GameObject MainMenu;

    public Button LoadButton;

    // Wall values
    private float WallYrot;
    private Vector3 WallPosition;

    // Desk values
    private float DeskYrot;
    private Vector3 DeskPosition;
    private Vector3 DeskHeight;
    private Vector3 DeskRight;
    private Vector3 DeskLeft;
    private Vector3 DeskBack;

    // Chair values
    private float ChairYrot;
    private Vector3 ChairPosition;
    private Vector3 ChairHeight;
    private Vector3 ChairRight;
    private Vector3 ChairLeft;
    private Vector3 ChairBack;
    private Vector3 ChairBackHeight;

    // Used to see if user is building room
    private bool Building = false;

    // Start is called before the first frame update
    void Start()
    {
        ReturnReferencePosition();

        //Hide instruction canvas
        InstructionCanvas.SetActive(false);

        if (PlayerPrefs.GetInt("IsSavedData") == 1)
        {
            LoadButton.interactable = true;
        }
        else
        {
            LoadButton.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            // Wall position
            if (BuildStage == 0 && Building == true)
            {
                WallYrot = ReturnReferencePosition().transform.eulerAngles.y;

                WallPosition = new Vector3(ReturnReferencePosition().transform.position.x, ReturnReferencePosition().transform.position.y, ReturnReferencePosition().transform.position.z);

                _wallBuilder.UpdateWallPosition(WallPosition, WallYrot);

                // Save values
                PlayerPrefs.SetFloat("WallPositionX", WallPosition.x);
                PlayerPrefs.SetFloat("WallPositionY", WallPosition.y);
                PlayerPrefs.SetFloat("WallPositionZ", WallPosition.z);

                PlayerPrefs.SetFloat("WallRotationY", WallYrot);

                // Change instructions
                Ins1.SetActive(false);
                Ins2.SetActive(true);
            }

            // Desk position
            if (BuildStage == 1 && Building == true)
            {
                DeskYrot = ReturnReferencePosition().transform.eulerAngles.y;

                DeskPosition = new Vector3(ReturnReferencePosition().transform.position.x, ReturnReferencePosition().transform.position.y, ReturnReferencePosition().transform.position.z);

                _deskBuilder.UpdateDeskPosition(DeskPosition, DeskYrot);

                // Save values
                PlayerPrefs.SetFloat("DeskPositionX", DeskPosition.x);
                PlayerPrefs.SetFloat("DeskPositionY", DeskPosition.y);
                PlayerPrefs.SetFloat("DeskPositionZ", DeskPosition.z);

                PlayerPrefs.SetFloat("DeskRotationY", DeskYrot);

                // Change instructions
                Ins2.SetActive(false);
                Ins3.SetActive(true);
            }

            // Desk height
            if (BuildStage == 2 && Building == true)
            {
                DeskHeight = new Vector3(ReturnReferencePosition().transform.position.x, ReturnReferencePosition().transform.position.y, ReturnReferencePosition().transform.position.z);

                _deskBuilder.UpdateDeskHeight(DeskHeight);

                // Save values
                PlayerPrefs.SetFloat("DeskHeightX", DeskHeight.x);
                PlayerPrefs.SetFloat("DeskHeightY", DeskHeight.y);
                PlayerPrefs.SetFloat("DeskHeightZ", DeskHeight.z);

                // Change instructions
                Ins3.SetActive(false);
                Ins4.SetActive(true);
            }


            // Desk right
            if (BuildStage == 3 && Building == true)
            {
                DeskRight = new Vector3(ReturnReferencePosition().transform.position.x, ReturnReferencePosition().transform.position.y, ReturnReferencePosition().transform.position.z);

                _deskBuilder.UpdateDeskRight(DeskRight);

                // Save values
                PlayerPrefs.SetFloat("DeskRightX", DeskRight.x);
                PlayerPrefs.SetFloat("DeskRightY", DeskRight.y);
                PlayerPrefs.SetFloat("DeskRightZ", DeskRight.z);

                // Change instructions
                Ins4.SetActive(false);
                Ins5.SetActive(true);
            }

            // Desk left
            if (BuildStage == 4 && Building == true)
            {
                DeskLeft = new Vector3(ReturnReferencePosition().transform.position.x, ReturnReferencePosition().transform.position.y, ReturnReferencePosition().transform.position.z);

                _deskBuilder.UpdateDeskLeft(DeskLeft);

                // Save values
                PlayerPrefs.SetFloat("DeskLeftX", DeskLeft.x);
                PlayerPrefs.SetFloat("DeskLeftY", DeskLeft.y);
                PlayerPrefs.SetFloat("DeskLeftZ", DeskLeft.z);

                // Change instructions
                Ins5.SetActive(false);
                Ins6.SetActive(true);
            }

            // Desk back
            if (BuildStage == 5 && Building == true)
            {
                DeskBack = new Vector3(ReturnReferencePosition().transform.position.x, ReturnReferencePosition().transform.position.y, ReturnReferencePosition().transform.position.z);

                _deskBuilder.UpdateDeskBack(DeskBack);

                // Save values
                PlayerPrefs.SetFloat("DeskBackX", DeskBack.x);
                PlayerPrefs.SetFloat("DeskBackY", DeskBack.y);
                PlayerPrefs.SetFloat("DeskBackZ", DeskBack.z);

                // Change instructions
                Ins6.SetActive(false);
                Ins7.SetActive(true);
            }

            // Chair position
            if (BuildStage == 6 && Building == true)
            {
                ChairYrot = ReturnReferencePosition().transform.eulerAngles.y;

                ChairPosition = new Vector3(ReturnReferencePosition().transform.position.x, ReturnReferencePosition().transform.position.y, ReturnReferencePosition().transform.position.z);

                _chairBuilder.UpdateChairPosition(ChairPosition, ChairYrot);

                // Save values
                PlayerPrefs.SetFloat("ChairPositionX", ChairPosition.x);
                PlayerPrefs.SetFloat("ChairPositionY", ChairPosition.y);
                PlayerPrefs.SetFloat("ChairPositionZ", ChairPosition.z);

                PlayerPrefs.SetFloat("ChairRotationY", ChairYrot);

                // Change instructions
                Ins7.SetActive(false);
                Ins8.SetActive(true);
            }

            // Chair height
            if (BuildStage == 7 && Building == true)
            {
                ChairHeight = new Vector3(ReturnReferencePosition().transform.position.x, ReturnReferencePosition().transform.position.y, ReturnReferencePosition().transform.position.z);

                _chairBuilder.UpdateChairHeight(ChairHeight);

                // Save values
                PlayerPrefs.SetFloat("ChairHeightX", ChairHeight.x);
                PlayerPrefs.SetFloat("ChairHeightY", ChairHeight.y);
                PlayerPrefs.SetFloat("ChairHeightZ", ChairHeight.z);

                // Change instructions
                Ins8.SetActive(false);
                Ins9.SetActive(true);
            }

            // Chair right
            if (BuildStage == 8 && Building == true)
            {
                ChairRight = new Vector3(ReturnReferencePosition().transform.position.x, ReturnReferencePosition().transform.position.y, ReturnReferencePosition().transform.position.z);

                _chairBuilder.UpdateChairRight(ChairRight);

                // Save values
                PlayerPrefs.SetFloat("ChairRightX", ChairRight.x);
                PlayerPrefs.SetFloat("ChairRightY", ChairRight.y);
                PlayerPrefs.SetFloat("ChairRightZ", ChairRight.z);

                // Change instructions
                Ins9.SetActive(false);
                Ins10.SetActive(true);
            }

            // Chair left
            if (BuildStage == 9 && Building == true)
            {
                ChairLeft = new Vector3(ReturnReferencePosition().transform.position.x, ReturnReferencePosition().transform.position.y, ReturnReferencePosition().transform.position.z);

                _chairBuilder.UpdateChairLeft(ChairLeft);

                // Save values
                PlayerPrefs.SetFloat("ChairLeftX", ChairLeft.x);
                PlayerPrefs.SetFloat("ChairLeftY", ChairLeft.y);
                PlayerPrefs.SetFloat("ChairLeftZ", ChairLeft.z);

                // Change instructions
                Ins10.SetActive(false);
                Ins11.SetActive(true);
            }

            // Chair back
            if (BuildStage == 10 && Building == true)
            {
                ChairBack = new Vector3(ReturnReferencePosition().transform.position.x, ReturnReferencePosition().transform.position.y, ReturnReferencePosition().transform.position.z);

                _chairBuilder.UpdateChairBack(ChairBack);

                // Save values
                PlayerPrefs.SetFloat("ChairBackX", ChairBack.x);
                PlayerPrefs.SetFloat("ChairBackY", ChairBack.y);
                PlayerPrefs.SetFloat("ChairBackZ", ChairBack.z);

                // Change instructions
                Ins11.SetActive(false);
                Ins12.SetActive(true);
            }

            // Chair back height
            if (BuildStage == 11 && Building == true)
            {
                ChairBackHeight = new Vector3(ReturnReferencePosition().transform.position.x, ReturnReferencePosition().transform.position.y, ReturnReferencePosition().transform.position.z);

                _chairBuilder.UpdateChairBackHeight(ChairBackHeight);

                // Save values
                PlayerPrefs.SetFloat("ChairBackHeightX", ChairBackHeight.x);
                PlayerPrefs.SetFloat("ChairBackHeightY", ChairBackHeight.y);
                PlayerPrefs.SetFloat("ChairBackHeightZ", ChairBackHeight.z);

                // Change instructions
                Ins12.SetActive(false);
                InstructionCanvas.SetActive(false);

                // Save object positions
                CombineScene();

                PlayerPrefs.SetInt("IsSavedData", 1);
            }

            if (BuildStage > 11 && Building == true)
            {
                ResetGlobalPosition();
            }

            if (Building == true)
            {
                BuildStage++;
            }
        }
    }

    // Return correct reference position depending on what model Quest is being used
    public Transform ReturnReferencePosition()
    {
        // If Oculus Quest 2
        if (OVRPlugin.GetSystemHeadsetType() == OVRPlugin.SystemHeadset.Oculus_Quest_2)
        {
            ReferencePosition = Oculus2_ReferencePosition;
        }

        // If Oculus Quest
        if (OVRPlugin.GetSystemHeadsetType() == OVRPlugin.SystemHeadset.Oculus_Quest)
        {
            ReferencePosition = Oculus_ReferencePosition;
        }

        return ReferencePosition;
    }

    private void CombineScene()
    {
        // Set reset position
        GlobalReference.transform.position = AttachReference.transform.position;

        GlobalReference.transform.rotation = AttachReference.transform.rotation;

        // Make objects child of global reference position
        Wall.transform.parent = GlobalReference.transform;
        Desk.transform.parent = GlobalReference.transform;
        Chair.transform.parent = GlobalReference.transform;
    }

    private void ResetGlobalPosition()
    {
        // Change global position
        GlobalReference.transform.position = new Vector3(ReturnReferencePosition().position.x, AttachReference.transform.position.y, ReturnReferencePosition().position.z);

        // Define wall rotation value
        Vector3 GlobalRotation = new Vector3(0, ReturnReferencePosition().eulerAngles.y, 0);

        // Change wall rotation
        GlobalReference.transform.rotation = Quaternion.Euler(GlobalRotation);
    }

    // Build room selection
    public void SetBuilding()
    {
        Building = true;

        InstructionCanvas.SetActive(true);

        LaserPointer.SetActive(false);

        MainMenu.SetActive(false);
    }

    // Load building from save
    public void LoadBuilding()
    {
        MainMenu.SetActive(false);

        LaserPointer.SetActive(false);

        // Step 1 - Wall position and rotation

        WallYrot = PlayerPrefs.GetFloat("WallRotationY", 0);

        WallPosition = new Vector3(PlayerPrefs.GetFloat("WallPositionX", 0), PlayerPrefs.GetFloat("WallPositionY", 0), PlayerPrefs.GetFloat("WallPositionZ", 0));

        _wallBuilder.UpdateWallPosition(WallPosition, WallYrot);

        // Step 2 - Desk position and rotation

        DeskYrot = PlayerPrefs.GetFloat("DeskRotationY", 0);

        DeskPosition = new Vector3(PlayerPrefs.GetFloat("DeskPositionX", 0), PlayerPrefs.GetFloat("DeskPositionY", 0), PlayerPrefs.GetFloat("DeskPositionZ", 0));

        _deskBuilder.UpdateDeskPosition(DeskPosition, DeskYrot);

        // Step 3 - Desk height

        DeskHeight = new Vector3(PlayerPrefs.GetFloat("DeskHeightX", 0), PlayerPrefs.GetFloat("DeskHeightY", 0), PlayerPrefs.GetFloat("DeskHeightZ", 0));

        _deskBuilder.UpdateDeskHeight(DeskHeight);

        // Step 4 - Desk right

        DeskRight = new Vector3(PlayerPrefs.GetFloat("DeskRightX", 0), PlayerPrefs.GetFloat("DeskRightY", 0), PlayerPrefs.GetFloat("DeskRightZ", 0));

        _deskBuilder.UpdateDeskRight(DeskRight);

        // Step 5 - Desk left

        DeskLeft = new Vector3(PlayerPrefs.GetFloat("DeskLeftX", 0), PlayerPrefs.GetFloat("DeskLeftY", 0), PlayerPrefs.GetFloat("DeskLeftZ", 0));

        _deskBuilder.UpdateDeskLeft(DeskLeft);

        // Step 6 - Desk back

        DeskBack = new Vector3(PlayerPrefs.GetFloat("DeskBackX", 0), PlayerPrefs.GetFloat("DeskBackY", 0), PlayerPrefs.GetFloat("DeskBackZ", 0));

        _deskBuilder.UpdateDeskBack(DeskBack);

        // Step 7 - Chair position and rotation

        ChairYrot = PlayerPrefs.GetFloat("ChairRotationY", 0);

        ChairPosition = new Vector3(PlayerPrefs.GetFloat("ChairPositionX", 0), PlayerPrefs.GetFloat("ChairPositionY", 0), PlayerPrefs.GetFloat("ChairPositionZ", 0));

        _chairBuilder.UpdateChairPosition(ChairPosition, ChairYrot);

        // Step 8 - Chair height

        ChairHeight = new Vector3(PlayerPrefs.GetFloat("ChairHeightX", 0), PlayerPrefs.GetFloat("ChairHeightY", 0), PlayerPrefs.GetFloat("ChairHeightZ", 0));

        _chairBuilder.UpdateChairHeight(ChairHeight);

        // Step 9 - Chair right

        ChairRight = new Vector3(PlayerPrefs.GetFloat("ChairRightX", 0), PlayerPrefs.GetFloat("ChairRightY", 0), PlayerPrefs.GetFloat("ChairRightZ", 0));

        _chairBuilder.UpdateChairRight(ChairRight);

        // Step 10 - Chair left

        ChairLeft = new Vector3(PlayerPrefs.GetFloat("ChairLeftX", 0), PlayerPrefs.GetFloat("ChairLeftY", 0), PlayerPrefs.GetFloat("ChairLeftZ", 0));

        _chairBuilder.UpdateChairLeft(ChairLeft);

        // Step 11 - Chair back

        ChairBack = new Vector3(PlayerPrefs.GetFloat("ChairBackX", 0), PlayerPrefs.GetFloat("ChairBackY", 0), PlayerPrefs.GetFloat("ChairBackZ", 0));

        _chairBuilder.UpdateChairBack(ChairBack);

        // Step 12 - Chair back height

        ChairBackHeight = new Vector3(PlayerPrefs.GetFloat("ChairBackHeightX", 0), PlayerPrefs.GetFloat("ChairBackHeightY", 0), PlayerPrefs.GetFloat("ChairBackHeightZ", 0));

        _chairBuilder.UpdateChairBackHeight(ChairBackHeight);

        // Make objects child of global reference position
        CombineScene();

        // Next click will realign position
        BuildStage = 12;

        Building = true;

    }
}
