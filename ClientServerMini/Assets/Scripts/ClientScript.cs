using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using UnityEngine.UI;

public class ClientScript : MonoBehaviour {
    TcpClient client;
    NetworkStream stream;
    StreamReader reader;
    StreamWriter writer;

    public string IPAddress;
    public string nickname;

    public InputField IP;
    public InputField nick;

	void Start () {
	}
	
//	void Update () {
//	
//	}


    public void parseIPAddress(){
        this.IPAddress = IP.text;
        print(this.IPAddress);
    }

    public void parseNickname(){
        this.nickname = nick.text;
        print(this.nickname);
    }
}
