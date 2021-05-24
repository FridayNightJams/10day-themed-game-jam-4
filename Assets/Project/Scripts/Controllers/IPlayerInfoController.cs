using System;
using UnityEngine;

public interface IPlayerInfoController
{
    PlayerInfo GetPlayerInfoRequest();
    void UpdatePlayerInfoRequest(PlayerInfo playerInfo);
}


