using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class PlayerDisplayName : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerNameText;
    [SerializeField] PhotonView photonView;

    void Start()
    {
        playerNameText.text = photonView.Owner.NickName;
    }
}
