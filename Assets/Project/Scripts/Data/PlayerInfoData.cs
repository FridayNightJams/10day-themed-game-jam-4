using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoData : MonoBehaviour
{
    private IPlayerInfoController playerInfoController;
    [SerializeField] private PlayerInfo playerInfo;

    private static PlayerInfoData instance = null;
    public static PlayerInfoData Instance() { return instance; }
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerInfoController = new PlayerInfoControllerImpl();
    }

    public void SavePlayerInfo()
    {
        playerInfoController.UpdatePlayerInfoRequest(playerInfo);
    }

    public void LoadPlayerInfo()
    {
        playerInfoController.GetPlayerInfoRequest();
    }

    public PlayerInfo GetPlayerInfo()
    {
        return playerInfo;
    }

}
