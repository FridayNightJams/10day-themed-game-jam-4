using System;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInfoControllerImpl : IPlayerInfoController
{
    public PlayerInfo GetPlayerInfoRequest()
    {
        PlayerInfo playerInfo = new PlayerInfo();
        playerInfo = JsonUtility.FromJson<PlayerInfo>(PlayerPrefs.GetString("PlayerInfo"));
        return playerInfo;
    }

    public void UpdatePlayerInfoRequest(PlayerInfo playerInfo)
    {
        PlayerPrefs.SetString("PlayerInfo", JsonUtility.ToJson(playerInfo));
    }
}