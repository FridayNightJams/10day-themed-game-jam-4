using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    protected PlayerInfo playerInfo;
    [SerializeField] private float detectionRadius;
    [SerializeField] private Transform target;
    [SerializeField] private List<Transform> targets;

    [Header("Prefabs")]
    [SerializeField] private GameObject playerAttackPrefab;

    private TargetCast targetCast;

    private void Start()
    {
        targetCast = GetComponent<TargetCast>();
        playerInfo = PlayerManager.Instance().GetPlayerInfo();
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag.Equals("Enemy"))
            {
                if (!targets.Contains(hitCollider.gameObject.transform))
                {
                    targets.Add(hitCollider.gameObject.transform);
                }
            }
        }

        if (target != null) Debug.DrawLine(transform.position, target.position, Color.red);
        if (target == null) targetCast.DestroyTarget();
    }

    public void Shoot()
    {
        if (target == null) target = NextCloseTarget();
        if (target != null) Attack();
    }

    private Transform NextCloseTarget()
    {
        Transform targ = null;

        foreach (Transform t in targets)
        {
            if (t != null && Vector3.Distance(t.position, transform.position) <= 12) targ = t;
        }

        return targ;
    }

    private void Attack()
    {
        targetCast.TargetingArk(transform.position, target.position);
        GameObject castObject = (GameObject)Instantiate(playerAttackPrefab);
        castObject.GetComponent<CastSpell>().SetTrajectory(targetCast.GetTrajectoryPoints());
    }

}
