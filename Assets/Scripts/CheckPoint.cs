using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour, IPunObservable
{
    bool checkPointReached = false;
    List<GameObject> players = new List<GameObject>();

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting && players.Count == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            checkPointReached = true;
            Debug.Log("Check point reached is true");
            stream.SendNext(checkPointReached);
        }
        else if (stream.IsReading)
        {
            checkPointReached = (bool)stream.ReceiveNext();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        players.Add(collision.gameObject);
        Debug.Log("player");
    }
}
