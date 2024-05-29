using UnityEngine;
using UnityEngine.UI;
using System;
using WebSocketSharp;
using TMPro;

public class WebSocketConnection : MonoBehaviour
{
    private WebSocket socket;
    public TMP_Text pH;
    public TMP_Text NITO;
    public TMP_Text HUMIDITY;
    public TMP_Text PHOTPHO;
    public TMP_Text KALI;
    public TMP_Text RELAY1;
    public TMP_Text RELAY2;
    public TMP_Text TEMPERATURE;
    //public TMP_Text SENSOR2;
    public TMP_Text TEMPERATURE_Predict;
    public TMP_Text HUMIDITY_Predict;
    public TMP_Text PH_Predict;
    public TMP_Text SoidSensor_Predict;
    public TMP_Text inforCabinet;
    public string ph;
    public string nito;
    public string humidity;
    public string photpho;
    public string kali;
    public string relay1;
    public string relay2;
    public string temperature;
    public string temperature_Predict;
    public string humidity_Predict;
    public string ph_Predict;
    public string soidsensor_Predict;
    public TMP_Text[] textObjects;

    /*string linkSocket = "ws://192.168.0.115:8080/websocket?id=" + SimpleBarcodeScanner.qr;*/
    //private string linkSocket = "ws://10.229.33.207:8080/websocket?stationId=" + "bkair_0001";
    //private string linkSocket = "wss://ar-application-service.onrender.com/websocket?stationId=bkair_0001";
    private string linkSocket = "ws://192.168.110.233:8080/websocket?stationId=air_0002";

    //string linkSocket = "ws://iot-server-da6s.onrender.com/websocket?id=bkair_0001";
    private void Start()
    {
        // Thiết lập kết nối WebSocket
        Debug.Log(linkSocket);
        socket = new WebSocket(linkSocket);
        socket.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;
        // Đăng ký các sự kiện
        socket.OnOpen += OnSocketOpen;
        socket.OnMessage += OnSocketMessage;
        socket.OnError += OnSocketError;
        socket.OnClose += OnSocketClose;

        // Kết nối tới máy chủ
        socket.Connect();
        textObjects = FindObjectsOfType<TMP_Text>();
        // Gán đối tượng thích hợp 
        //inforCabinet.text ="Tủ " + SimpleBarcodeScanner.qr;
        
        foreach (TMP_Text textObject in textObjects)
        {
            if (textObject.name == "pH")
            {
                pH = textObject;
            }
            else if (textObject.name == "NITO")
            {
                NITO = textObject;
            }
            else if (textObject.name == "HUMIDITY")
            {
                HUMIDITY = textObject;
            }
            else if (textObject.name == "PHOTPHO")
            {
                PHOTPHO = textObject;
            }
            else if (textObject.name == "KALI")
            {
                KALI = textObject;
            }
            else if (textObject.name == "RELAY1")
            {
                RELAY1 = textObject;
            }
            else if (textObject.name == "RELAY2")
            {
                RELAY2 = textObject;
            }
            else if (textObject.name == "TEMPERATURE")
            {
                TEMPERATURE = textObject;
            }
        }
    }

    private void OnDestroy()
    {
        // Đóng kết nối WebSocket trước khi đối tượng bị hủy
        if (socket != null && socket.IsAlive)
        {
            socket.Close();
        }
    }
    void Update()
    {
        pH.text = ph;
        NITO.text = nito;
        HUMIDITY.text = humidity;
        KALI.text = kali;
        RELAY1.text = relay1;
        RELAY2.text = relay2;
        PHOTPHO.text = photpho;
        TEMPERATURE.text = temperature;
        HUMIDITY_Predict.text = humidity_Predict;
        TEMPERATURE_Predict.text = temperature_Predict;
        PH_Predict.text = ph_Predict;
        SoidSensor_Predict.text = soidsensor_Predict;
        //Debug.Log(inforCabinet.text);
    }

    private void OnSocketOpen(object sender, System.EventArgs e)
    {
        Debug.Log("WebSocket connection opened");

        // Gửi tin nhắn tới máy chủ
        //socket.Send("co,no2,o3,so2,humidity,pm10,pm2_5,co2,temperature");
        socket.Send(ScanBarcode.qr);
    }

    private void OnSocketMessage(object sender, MessageEventArgs e)
    {
        //Debug.Log("Received message from server: " + e.Data);
        SimpleJSON.JSONNode jData = SimpleJSON.JSONNode.Parse(e.Data);
        //Debug.Log(jData);
        //Debug.Log(jData);
        Debug.Log(jData["value"]);
        if (jData["type"] == "PRESENT")
        {
            if (jData["id"] == "ph_0002")
            {
                ph = jData["value"];
                Debug.Log(ph);
            }
            else if (jData["id"] == "Nito_0002")
            {
                nito = jData["value"];
            }
            else if (jData["id"] == "temp_0002")
            {
                temperature = jData["value"];
            }
            else if (jData["id"] == "humi_0002")
            {
                humidity = jData["value"];
            }
            else if (jData["id"] == "Photpho_0002")
            {
                photpho = jData["value"];
            }
            else if (jData["id"] == "Kali_0002")
            {
                kali = jData["value"];
            }
            else if (jData["id"] == "Relay_0001")
            {
                if (jData == "true")
                {
                    relay1 = "ON";
                }
                else
                {
                    relay1 = "OFF";
                }
            }
            else if (jData["id"] == "Relay_0002")
            {
                if (jData == "true")
                {
                    relay2 = "ON";
                }
                else
                {
                    relay2 = "OFF";
                }
            }
        }
        if (jData["type"] == "PREDICTION")
        {
            if (jData["id"] == "ph_0002")
            {
                ph_Predict = jData["value"];
            }
            else if (jData["id"] == "temp_0002")
            {
                temperature_Predict = jData["value"];
            }
            else if (jData["id"] == "humi_0002")
            {
                humidity_Predict = jData["value"];
            }
            else if(jData["id"] == "soidsensor_0002"){
                soidsensor_Predict = jData["value"];
            }
        }


        }

    private void OnSocketError(object sender, ErrorEventArgs e)
    {
        Debug.LogError("WebSocket error: " + e.Message);
    }

    private void OnSocketClose(object sender, CloseEventArgs e)
    {
        Debug.Log("WebSocket connection closed with code: " + e.Code);
    }
}