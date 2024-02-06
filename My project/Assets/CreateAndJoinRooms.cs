using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createInput, joinInput;

    public void CreateRoom()
    {
        string roomName = createInput.text;
        if (!string.IsNullOrEmpty(roomName))
        {
            PhotonNetwork.CreateRoom(roomName);
        }
        else
        {
            Debug.Log("Room name is empty");
        }
    }

    public void JoinRoom()
    {
        string roomName = joinInput.text;
        if (!string.IsNullOrEmpty(roomName))
        {
            PhotonNetwork.JoinRoom(roomName);
        }
        else
        {
            Debug.Log("Room name is empty");
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room creation failed: " + message);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Join room failed: " + message);
    }
}
