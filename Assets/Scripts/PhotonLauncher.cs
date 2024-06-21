using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PhotonLauncher : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject buttonHost;
    [SerializeField] GameObject buttonClient;
    [SerializeField] GameObject TextLoading;
    [SerializeField] GameObject Play;
    [SerializeField] GameObject Text;


    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public void JoinAsHost()
    {
        Text.SetActive(true);
        PhotonNetwork.CreateRoom("Default", new RoomOptions { MaxPlayers = 2 });
        buttonHost.SetActive(false);
        buttonClient.SetActive(false);
    }

    public void JoinAsClient()
    {
        JoinRoom();
    }
   

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        TextLoading.SetActive(false);
        buttonHost.SetActive(true);
        buttonClient.SetActive(true);
        Debug.Log("Nice!");
    }

    private void JoinRoom()
    {
        PhotonNetwork.JoinRoom("Default");
        if(!PhotonNetwork.IsMasterClient)
        {
            TextLoading.SetActive(true);
            buttonHost.SetActive(false);
            buttonClient.SetActive(false);
        }
        

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Play.SetActive(true);
        Text.SetActive(false);

    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
