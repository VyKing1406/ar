using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonClick : MonoBehaviour
{
    public GameObject contentPage;
    public GameObject maintenancePage;

    /*public void LoadSceen(string sceenName)
    {
        SceneManager.LoadScene(sceenName);
        //Global.resetData();
    }*/
    public void Start(){
        contentPage.SetActive(true);
        maintenancePage.SetActive(false);
    }
    public void contentPageActive()
    {
        contentPage.SetActive(true);
        maintenancePage.SetActive(false);
    }
    
    public void maintenancePageActive()
    {
        contentPage.SetActive(false);
        maintenancePage.SetActive(true);
    }
}
