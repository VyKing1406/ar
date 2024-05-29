using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DisplayComponentController : MonoBehaviour
{
    public GameObject form;
    public GameObject MaintenanceInstruction;
    public MaintenanceInstructionController maintenanceInstructionController;
    public GameObject CreateButton;
    public GameObject EditButton;
    public GameObject DisplayButton;
    public GameObject DashBoard;
    public GameObject Prediction;

    void Start() {
        DataControler.RootTracked += RootTracked;
        form.SetActive(false);
        // MaintenanceInstruction.SetActive(false);
        // CreateButton.SetActive(false);
        // EditButton.SetActive(false);
        DisplayButton.SetActive(false);
        DashBoard.SetActive(false);
        Prediction.SetActive(false);
    }

    void Update()
    {
        
    }

    private void RootTracked() {
        DisplayButton.SetActive(true);
    }

    public void DisplayButtonOnclick() {
        DashBoard.SetActive(true);
        DisplayButton.SetActive(false);
        Prediction.SetActive(true);
        DashBoard.transform.position = DataControler.rootTransform.position + new Vector3(-0.4f, 0.6f, 0f);
        Prediction.transform.position = DataControler.rootTransform.position + new Vector3(0.4f, 0.6f, 0f);
        form.transform.position = DataControler.rootTransform.position + new Vector3(-1f, 0.5f, -0.8f);
    }

    public void MaintenanceTabOnClick() {
        MaintenanceInstruction.SetActive(true);
    }

    public void SensorDataTabOnClick() {
        MaintenanceInstruction.SetActive(false);
    }



}