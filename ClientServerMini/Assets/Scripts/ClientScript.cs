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
	public InputField message; 
	public Text chatContent; 

	void Start () {
		chatContent.text = ""; 
		//client = new TcpClient (IPAddress, 11000);
		//stream = client.GetStream (); 
		//reader = new StreamReader (stream); 
		//writer = new StreamWriter (stream) { AutoFlush = true }; 

	}
	
	void Update () {
	}


    public void parseIPAddress(){
        this.IPAddress = IP.text;
        print(this.IPAddress);
    }

    public void parseNickname(){
        this.nickname = nick.text;
        print(this.nickname);
    }

	public void initChatRoom(){
		Application.LoadLevel ("Chatroom"); 
	}

	public void sendMessages(){
		chatContent.text += message.text+"\n"; 
		message.text = ""; 
		message.interactable = true;
	}
}
