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

    Text text; 

    public GameObject Lobby;
    public GameObject Chat;

    public string IPAddress;
    public string nickname;

    public InputField IP;
    public InputField nick;
	public InputField message; 
	public Text chatContent; 

    Vector2 scroll;

	void Start () {
		chatContent.text = ""; 
		Lobby.SetActive(true);
		Chat.SetActive(false);
        

	}
	
	void Update () {

		recievedMessages();

	}


    public void parseIPAddress(){
        this.IPAddress = IP.text;
        print(this.IPAddress);
    }

    public void parseNickname(){
    	

        this.nickname = nick.text;
        print(this.nickname);

    }



	public void sendMessages(){

		//writer.WriteLine (nickname + ": " + message.text);
        chatContent.text += message.text + "\n";
        message.text = "";
		
	}

	public void initConnection ()
	{
		if (this.nickname != "") {

            Lobby.SetActive(false);
            Chat.SetActive(true);
			client = new TcpClient (IPAddress, 11000);
			stream = client.GetStream (); 
			reader = new StreamReader (stream); 
			writer = new StreamWriter (stream) { AutoFlush = true };


		} else if (this.nickname == "") {

			nick.GetComponent<Image> ().color = Color.red;	
	
		}

	}

	public void recievedMessages ()
	{

		if (reader.ReadLine () != null) {
			chatContent.text += reader.ReadLine () + "\n";
		}

	}

	// Here we quit
	public void quit ()
	{
		Application.Quit(); //This is application quit.


	}

	//Here we go back to lobby
	public void backToLobby ()
	{
		Lobby.SetActive(true); //this sets the lobbycontent to true
		Chat.SetActive(false); //this is chatcontent setactive to false.
		nick.text = ""; // Here we set the nickname to empty string
	}

    public void scrollBar(){
        float y = 0f; 
        y += 10; 
        scroll = new Vector2(0f, y); 

    }

}
