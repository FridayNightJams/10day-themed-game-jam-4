using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private IPlayerInfoController playerInfoController;
    [SerializeField] private GameObject playerModel;
    protected PlayerInfo playerInfo;

    private static PlayerManager instance = null;
    public static PlayerManager Instance() { return instance; }
    private void Awake() => instance = this;

    private void Start()
    {
        playerInfo = PlayerInfoData.Instance().GetPlayerInfo();
        playerInfoController = new PlayerInfoControllerImpl();
    }

    public void GiveGold(int amount) => playerInfo.gold += amount;

    public void GetHit(int dmg)
    {
        playerInfo.gold -= dmg;
        if (playerInfo.gold <= 0) playerInfo.gold = 0;
    }

    public PlayerInfo GetPlayerInfo()
    {
        return playerInfo;
    }

    private void OnColliderEnter(Collider hit)
    {
        if (hit.gameObject.tag.Equals("Enemy")) GetHit(hit.gameObject.GetComponent<EnemyAI>().GetCreature().damage);
    }

    public GameObject GetPlayerModel()
    {
        return playerModel;
    }

    public void Save() => playerInfoController.UpdatePlayerInfoRequest(playerInfo);
    public void Load() => playerInfoController.GetPlayerInfoRequest();
}
