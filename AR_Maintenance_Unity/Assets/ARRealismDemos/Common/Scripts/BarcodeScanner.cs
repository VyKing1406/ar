using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using TMPro;

public class BarcodeScanner : MonoBehaviour
{
    public Text resultText;
    public BarcodeBehaviour mBarcodeBehaviour;
    public GameObject switchButton;
    public GameObject startButton;
    //public GameObject trackDeviceButton;
    public static string qr = "";
    void Start()
    {
        resultText.text = "Hello, please scan QR code";
        mBarcodeBehaviour = GetComponent<BarcodeBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startButton)
        {
            if (mBarcodeBehaviour != null && mBarcodeBehaviour.InstanceData != null)
            {
                Debug.Log(mBarcodeBehaviour.InstanceData.Text);
                if (mBarcodeBehaviour.InstanceData.Text == "https://me-qr.com/mtvCiIeM")
                {
                    qr = "00001";
                }
                else if (mBarcodeBehaviour.InstanceData.Text == "https://me-qr.com/NGYFS5Za")
                {
                    qr = "00002";
                }
                //qr = mBarcodeBehaviour.InstanceData.Text;
                resultText.text = "This is device " + qr;
                startButton.SetActive(false);
                switchButton.SetActive(true);
                //trackDeviceButton.SetActive(true);
            }
            else
            {
                //qr = "No QR";
                //Debug.Log(qr);
                //mBarcodeBehaviour = GetComponent<BarcodeBehaviour>();
            }
        }
    }

/*    public void startScan()
    {
        resultText.text = "Scaning...";
        //mBarcodeBehaviour = GetComponent<BarcodeBehaviour>();
    }*/

    public string GetData()
    {
        return qr;
    }
}
