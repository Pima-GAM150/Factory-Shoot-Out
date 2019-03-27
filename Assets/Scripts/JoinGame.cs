using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class JoinGame : MonoBehaviourPunCallbacks
{

    const int gameSceneIndex = 3;
    public TextMeshProUGUI label;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        label.text = "Joining game...";
        PhotonNetwork.JoinRandomRoom();    
    }

    public override void OnJoinRandomFailed( short returnCode, string Message)
    {
        label.text = "Creating game...";
        PhotonNetwork.CreateRoom( null, new RoomOptions() { MaxPlayers = 6 }, null ); // create a RoomOptions object to control how players can join
    }

    public override void OnCreatedRoom()
    {
        label.text = "Created game...";
        SceneManager.LoadScene(gameSceneIndex);
    }

    public override void OnJoinedRoom()
    {
        label.text = "Joined room...";
        SceneManager.LoadScene(gameSceneIndex);
    }
}
