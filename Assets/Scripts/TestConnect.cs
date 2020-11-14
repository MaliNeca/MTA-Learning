using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConnect : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private string _roomName = "PrviRoom";
    // Start is called before the first frame update
    void Start()
    {
        print("Connecting to server.");
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;


        PhotonNetwork.ConnectUsingSettings();
       
    }


    public override void OnConnectedToMaster()
    {
        print("Connected to photon.");
        print(PhotonNetwork.LocalPlayer.NickName);

    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected from server for reason " + cause.ToString());

    }

 


}