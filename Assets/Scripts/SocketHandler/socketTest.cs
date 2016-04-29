using UnityEngine;
using System.Collections;

using System.Net.Sockets;
using System;
using Abrio;
using System.Net;
using System.Collections.Generic;


public class socketTest : MonoBehaviour,Observerable {
    private Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    private byte[] _recieveBuffer = new byte[8142];
    private bool isConnectionSuccess=false;
   
    private  List<BallMovementObserver> ballObservers = new List<BallMovementObserver>();
    //for incoming data
    byte[] bytes = new byte[1024];
    private void SetupServer()
    {
        try
        {
            _clientSocket.Connect(new IPEndPoint(IPAddress.Parse("172.17.9.222"), 8000));

            int numberOfByte = _clientSocket.Receive(_recieveBuffer);
            Debug.Log("resnum:" + numberOfByte);
            bytes = new byte[numberOfByte];
            Buffer.BlockCopy(_recieveBuffer, 0, bytes, 0, numberOfByte);
            Debug.Log(BasicEvent.Deserialize(bytes));
        }
        catch (SocketException ex)
        {
            Debug.Log(ex.Message);
        }

      //  _clientSocket.BeginReceive(_recieveBuffer, 0, _recieveBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);

    }

    private void ReceiveCallback(IAsyncResult AR)
    {
        //Check how much bytes are recieved and call EndRecieve to finalize handshake
        int recieved = _clientSocket.EndReceive(AR);

        if (recieved <= 0)
            return;

        //Copy the recieved data into new buffer , to avoid null bytes
        byte[] recData = new byte[recieved];
        Buffer.BlockCopy(_recieveBuffer, 0, recData, 0, recieved);

        //Process data here the way you want , all your bytes will be stored in recData
        if(Response.Deserialize(recData).Type == "3")
            Debug.Log("Connection Success");
        if (Response.Deserialize(recData).Type == "3")
            Debug.Log("Connection Success");

        //Start receiving again
        _clientSocket.BeginReceive(_recieveBuffer, 0, _recieveBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
    }

    private void SendData(byte[] data)
    {
        

       _clientSocket.Send(data);
        

       int numberOfByte= _clientSocket.Receive(_recieveBuffer);
      // Debug.Log("resnum:" + numberOfByte);
       bytes = new byte[numberOfByte];
       Buffer.BlockCopy(_recieveBuffer, 0, bytes, 0, numberOfByte);
        Debug.Log(Response.Deserialize(bytes).Type);
    }
	// Use this for initialization
	void Start () {
        //Debug.Log("start socket");
        SetupServer();
       // Debug.Log("after setup socket");
        
        AuthEvent authEvent = new AuthEvent();
        authEvent.DeviceId = "koosha";
        authEvent.UserId = "bardia";
        authEvent.PrivateKey = "123123";

        SendData(AuthEvent.SerializeToBytes(authEvent));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    

    void Observerable.registerBallMovementObserver(BallMovementObserver observer)
    {
        ballObservers.Add(observer);
    }

    void Observerable.notifyBallMovementObservers(float newX,float newY,float newVelocity)
    {
        for (int i = 0; i < ballObservers.Count; i++)
        {
            ballObservers[i].updatePosition(newX, newY, newVelocity);
        }
        
    }
}
