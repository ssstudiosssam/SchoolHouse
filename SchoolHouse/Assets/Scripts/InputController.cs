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

    public GameObject Wall, Desk, Chair, Floor;

    public GameObject AttachReference;

    public GameObject GlobalReference;

    // Start is called before the first frame update
    void Start()
    {
        ReturnReferencePosition();
    }

    // Update is called once per frame
    void Update()
    {
        //OVRInput.Update();

        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            if (BuildStage == 0)
            {
                _wallBuilder.UpdateWallPosition(ReturnReferencePosition().transform);

                Ins1.SetActive(false);
                Ins2.SetActive(true);
            }

            if (BuildStage == 1)
            {
                _deskBuilder.UpdateDeskPosition(ReturnReferencePosition().transform);

                Ins2.SetActive(false);
                Ins3.SetActive(true);
            }

            if (BuildStage == 2)
            {
                _deskBuilder.UpdateDeskHeight(ReturnReferencePosition().transform);

                Ins3.SetActive(false);
                Ins4.SetActive(true);
            }

            if (BuildStage == 3)
            {
                _deskBuilder.UpdateDeskRight(ReturnReferencePosition().transform);

                Ins4.SetActive(false);
                Ins5.SetActive(true);
            }

            if (BuildStage == 4)
            {
                _deskBuilder.UpdateDeskLeft(ReturnReferencePosition().transform);

                Ins5.SetActive(false);
                Ins6.SetActive(true);
            }

            if (BuildStage == 5)
            {
                _deskBuilder.UpdateDeskBack(ReturnReferencePosition().transform);

                Ins6.SetActive(false);
                Ins7.SetActive(true);
            }

            if (BuildStage == 6)
            {
                _chairBuilder.UpdateChairPosition(ReturnReferencePosition().transform);

                Ins7.SetActive(false);
                Ins8.SetActive(true);
            }

            if (BuildStage == 7)
            {
                _chairBuilder.UpdateChairHeight(ReturnReferencePosition().transform);

                Ins8.SetActive(false);
                Ins9.SetActive(true);
            }

            if (BuildStage == 8)
            {
                _chairBuilder.UpdateChairRight(ReturnReferencePosition().transform);

                Ins9.SetActive(false);
                Ins10.SetActive(true);
            }

            if (BuildStage == 9)
            {
                _chairBuilder.UpdateChairLeft(ReturnReferencePosition().transform);

                Ins10.SetActive(false);
                Ins11.SetActive(true);
            }

            if (BuildStage == 10)
            {
                _chairBuilder.UpdateChairBack(ReturnReferencePosition().transform);

                Ins11.SetActive(false);
                Ins12.SetActive(true);
            }

            if (BuildStage == 11)
            {
                _chairBuilder.UpdateChairBackHeight(ReturnReferencePosition().transform);

                Ins12.SetActive(false);
                InstructionCanvas.SetActive(false);

                // Set reset position
                GlobalReference.transform.position = AttachReference.transform.position;

                GlobalReference.transform.rotation = AttachReference.transform.rotation;

                // Make objects child of global reference position
                Wall.transform.parent = GlobalReference.transform;
                Desk.transform.parent = GlobalReference.transform;
                Chair.transform.parent = GlobalReference.transform;
                Floor.transform.parent = GlobalReference.transform;
            }

            if (BuildStage > 11)
            {
                ResetGlobalPosition();
            }

            BuildStage++;
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

    private void ResetGlobalPosition()
    {
        // Change global position
        GlobalReference.transform.position = new Vector3(ReturnReferencePosition().position.x, AttachReference.transform.position.y, ReturnReferencePosition().position.z);

        // Define wall rotation value
        Vector3 GlobalRotation = new Vector3(0, ReturnReferencePosition().eulerAngles.y, 0);

        // Change wall rotation
        GlobalReference.transform.rotation = Quaternion.Euler(GlobalRotation);
    }
}
