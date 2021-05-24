using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    public float speed;
    public int damage;

    private List<Vector3> trajectory;
    private int counter;
    private Vector3 target;

    void Start()
    {
        if (trajectory.Count == 0) return;
        counter = 0;
        target = trajectory[counter];
        damage = PlayerManager.Instance().GetPlayerInfo().damage;
    }

    void Update()
    {
        if (target == null && trajectory.Count == 0) return;
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            if (counter < trajectory.Count)
            {
                target = trajectory[counter];
                counter++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetTrajectory(List<Vector3> traject)
    {
        this.trajectory = traject;
    }

    private void OnTriggerEnter(Collider hit)
    {
        Debug.Log(hit.gameObject.tag);
        if (hit.gameObject.tag.Equals("Enemy"))
        {
            hit.gameObject.GetComponent<EnemyAI>().GetHit(damage);
            PlayerManager.Instance().GiveGold(damage);
        }
    }
}
