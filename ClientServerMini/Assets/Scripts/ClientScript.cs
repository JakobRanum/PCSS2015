using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using UnityEngine.UI;
using System.Text;
using System.Threading;
using System;
using System.Collections.Generic;



public class ClientScript : MonoBehaviour {
    TcpClient client;
    NetworkStream stream;
    StreamReader reader;
    StreamWriter writer;

    public GameObject Lobby;
    public GameObject Chat;

    public string IPAddress;
    public string nickname;

    public InputField IP;
    public InputField nick;
	public InputField message; 
	public Text chatContent; 

	void Start () {
		chatContent.text = ""; 
		Lobby.SetActive(true);
		Chat.SetActive(false);


	}
	
	void Update () {

		//recievedMessages();

	}


    public void parseIPAddress(){
        this.IPAddress = IP.text;
        print(this.IPAddress);
    }

    public void parseNickname(){
    	

        this.nickname = nick.text;
        print(this.nickname);

    }


	

	public void initConnection ()
	{
		if (this.nickname != "") {

			

			//stream = client.GetStream (); 

		
			Lobby.SetActive(false);
			Chat.SetActive(true);

			client = new TcpClient (IPAddress, 11000);

			Thread senderThread = new Thread (recievedMessages);
			senderThread.Start(client);


		} else if (this.nickname == "") {

			nick.GetComponent<Image> ().color = Color.red;	
	
		}

	}

	public void sendMessages (object argument)
	{
		TcpClient client = (TcpClient)argument;
		writer = new StreamWriter (client.GetStream(), Encoding.ASCII) { AutoFlush = true };


		while (Chat.activeSelf == true) {
			writer.WriteLine (nickname + ": " + message.text);
			message.text = "";
		}


	}

	public List<String> messages = new List<string>();

	public void recievedMessages (object argument)
	{

		TcpClient client = (TcpClient)argument;

			try{
				StreamReader reader = new StreamReader(client.GetStream(), Encoding.ASCII);

				Console.WriteLine("Now listening to client");

				while (client.Connected) {
					if (true) {
						try{
							string message = reader.ReadLine();
							if (message != null){

								addMSG(message);
								messages.Add(message);
							}

						}
						catch{
							reader.Close();
							client.Close();
							Console.WriteLine("Connection Error");
							break;
						}
					}
				}
				Console.WriteLine("Client disconnected");

			}

		catch (ThreadAbortException){
				client.Close();
				Console.WriteLine("Connection error...");
			}

			finally{
				Console.WriteLine("finally");
			}



						
	}
	public void addMSG (String msg)
	{
		Debug.Log(msg);
		chatContent.text += msg + "\n";
	}


	// Here we quit
	public void quit ()
	{
		Application.Quit(); //This is application quit.


	}

	//Here we go back to lobby
	public void backToLobby ()
	{
		//StopCoroutine(recievedMessages());
		//StopCoroutine(sendMessages());

		Lobby.SetActive(true); //this sets the lobbycontent to true
		Chat.SetActive(false); //this is chatcontent setactive to false.
		nick.text = ""; // Here we set the nickname to empty string

	}


}
