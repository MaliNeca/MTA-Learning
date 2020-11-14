using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private string _roomName = "PrviRoom";


    public void OnClick_CreateRoom()
    {
        
        //Create Room
        if (!PhotonNetwork.IsConnected)
        {
            Debug.Log("PhotonNetwork is not connected");
            return;
        }
        Debug.Log("PhotonNetwork is connected!!!");

        //JoinOrCreateRoom
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        
        
        PhotonNetwork.JoinOrCreateRoom(_roomName, options, TypedLobby.Default);


    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room successfully.", this);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room creation failed: " + message, this);
        

    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Join room sucssefully ", this);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Join room failed: " + message, this);

    }
}
