using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Creature creature;
    private NavMeshAgent agent;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.Instance().GetPlayerModel().transform;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }

    void FixedUpdate()
    {
        if (IsDead()) return;
        if (Vector3.Distance(transform.position, target.position) <= 1)
        {
            PlayerManager.Instance().GetHit(creature.damage);
            GetHit(creature.health);
        }
    }

    public Creature GetCreature()
    {
        return creature;
    }

    public bool IsDead()
    {
        if (creature.health > 0) return false;
        Destroy(gameObject);
        return true;
    }

    public void GetHit(int dmg)
    {
        if (IsDead()) return;
        creature.health -= dmg;
    }

}
