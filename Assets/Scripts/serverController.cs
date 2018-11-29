﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//Should be declared identically to the gameParameters class in clientController.
public class gameParameters : MessageBase
{
    public int param;
    public string respawnTime;
    public string[] input;
    public string inputForHint;
    public int[] bitMapSubString1, bitMapSubString2, bitMapSubString3;
    public int[] No_of_blanks;
    public int[] SpawnInterval;
    public bool[] AlphabetsFaceUser;
    public bool[] spin;
    public bool[] repeatSolution;
    public int FlyingSpeed;
    public int RotationSpeed;
    //private enum EHeightLevel{Crouch, Waist, Chest, Head, VerticalReach};
    //private float[] HeightCalibrationData = { 0, 0, 0, 0, 0 };
    // public float CrouchHeight { get { return HeightCalibrationData[(int)EHeightLevel.Crouch]; } private set { } }
    //public float WaistHeight ;
    // public float ChestHeight { get { return HeightCalibrationData[(int)EHeightLevel.Chest]; } private set { } }
    // public float HeadHeight { get { return HeightCalibrationData[(int)EHeightLevel.Head]; } private set { } }
    // public float VerticalReachHeight { get { return HeightCalibrationData[(int)EHeightLevel.VerticalReach]; } private set { } }

    // private enum EReachability { Close, ArmsLength, OutOfReach };
    // private float[] ReachabilityCalibrationData = { 0, 0, 0 };
    // public float CloseReachability { get { return ReachabilityCalibrationData[(int)EReachability.Close]; } private set { } }
    // public float ArmsLengthReachability { get { return ReachabilityCalibrationData[(int)EReachability.ArmsLength]; } private set { } }
    // public float OutOfReachReachability { get { return ReachabilityCalibrationData[(int)EReachability.OutOfReach]; } private set { } }
}

public class serverController : MonoBehaviour {

	public static short MSG_GAME_PARAMETERS_START = 1005;
	public static short MSG_GAME_PARAMETERS_UPDATE = 1006;
    public static short MSG_GAME_PARAMETERS_STOP = 1007;
    public Button btn_start_game, btn_stop_game;
    public InputField hint, puzzle1, puzzle2, puzzle3;
    public InputField[] No_Of_Blank_Text;// = new List<Text>();
    public InputField[] SpawnInterval;
    public Toggle[] AlphabetsFaceUser;
    public Toggle[] spin;
    public Toggle[] repeatSolution;
    public InputField FlyingSpeed;
    public InputField RotationSpeed;

    // Use this for initialization
    void Start ()
    {
        //Start the server.
        btn_start_game.onClick.AddListener(startGame);
        btn_stop_game.onClick.AddListener(stopGame);
        NetworkServer.Listen(4444);
        Debug.Log("Server started successfully.");
        NetworkServer.RegisterHandler(MsgType.Connect, OnConnected);
        NetworkServer.RegisterHandler(MsgType.Disconnect, OnDisconnected);
        btn_start_game.interactable = false;



        //ClientDiscovery cD = new ClientDiscovery();
        //NetworkDiscovery x = new NetworkDiscovery();
        //x.Initialize();
        //x.StartAsServer();
        //cD.startServer();
    }
	
	// Update is called once per frame
	void Update ()
    {
            
    }

	void OnConnected(NetworkMessage netMsg)
	{
        btn_start_game.interactable = true;
        Debug.Log("Client connected.");
	}
    public void OnDisconnected(NetworkMessage netMsg)
    {
        Debug.Log("Client disconnected.");
        btn_start_game.interactable = false;
    }


    void stopGame()
    {
        gameParameters msg = new gameParameters();
        NetworkServer.SendToAll(MSG_GAME_PARAMETERS_STOP, msg);
    }


    void startGame()
    {
        Debug.Log("Sending Start Message to client...");
        gameParameters msg = new gameParameters();
        
        msg.input = new string[3];

        msg.SpawnInterval = new int[3];
        msg.SpawnInterval[0] = int.Parse(SpawnInterval[0].text);
        msg.SpawnInterval[1] = int.Parse(SpawnInterval[1].text);
        msg.SpawnInterval[2] = int.Parse(SpawnInterval[2].text);
        msg.input[0] = puzzle1.text;
        msg.input[1] = puzzle2.text;
        msg.input[2] = puzzle3.text;
        msg.AlphabetsFaceUser = new bool[3];
        msg.AlphabetsFaceUser[0] = AlphabetsFaceUser[0].isOn;
        msg.AlphabetsFaceUser[1] = AlphabetsFaceUser[1].isOn;
        msg.AlphabetsFaceUser[2] = AlphabetsFaceUser[2].isOn;
        msg.spin = new bool[3];
        msg.spin[0] = spin[0].isOn;
        msg.spin[1] = spin[1].isOn;
        msg.spin[2] = spin[2].isOn;
        msg.repeatSolution = new bool[3];
        msg.repeatSolution[0] = repeatSolution[0].isOn;
        msg.repeatSolution[1] = repeatSolution[1].isOn;
        msg.repeatSolution[2] = repeatSolution[2].isOn;
        msg.FlyingSpeed = int.Parse(FlyingSpeed.text);
        msg.RotationSpeed = int.Parse(RotationSpeed.text);
        List<int[]> bitMapSubString = new List<int[]>();
        //msg.input.Add(puzzle2.text);
        //msg.input.Add(puzzle3.text);
        msg.No_of_blanks = new int[3];

        msg.inputForHint = hint.text;
        for (int j = 0; j < 3; j++)
        {
            msg.No_of_blanks[j] = int.Parse(No_Of_Blank_Text[j].text);

            int[] temp = new int[msg.input[j].Length];
            bitMapSubString.Add(temp);
            System.Random rnd = new System.Random();
            for (int i = 0; i < bitMapSubString[j].Length; i++)
            {
                bitMapSubString[j][i] = 1;

            }
            int rand_id;
            if (msg.No_of_blanks[j] > msg.input[j].Length - 2)
                msg.No_of_blanks[j] = msg.input[j].Length / 2;

            //Debug.Log("No Blanks:" + No_of_blanks[j]);
            //ContainerCollider.setBlanks(No_of_blanks[j]);
            //Countdown.setBlanksInCountdown(No_of_blanks[j]);

            while (msg.No_of_blanks[j] != 0)
            {
                rand_id = rnd.Next(1, msg.input[j].Length - 1);
                if (bitMapSubString[j][rand_id] != 0)
                {
                    bitMapSubString[j][rand_id] = 0;
                    msg.No_of_blanks[j]--;

                }
            }
        }
        msg.bitMapSubString1 = bitMapSubString[0];
        msg.bitMapSubString2 = bitMapSubString[1];
        msg.bitMapSubString3 = bitMapSubString[2];
        //for(int i = 0; i<bitMapSubString[0].Length; i++)
        //    Debug.Log("Blanks: " + bitMapSubString[0][i]);


        NetworkServer.SendToAll(MSG_GAME_PARAMETERS_START, msg);
        Debug.Log("Sent message to client: "+msg.inputForHint);
    }

}
public class ClientDiscovery : NetworkDiscovery
{
    void Start()
    {
        //Application.runInBackground = true;
        startServer();
    }

    //Call to create a server
    public void startServer()
    {
        Initialize();
        StartAsServer();
        Debug.Log("Server started");
    }

}

