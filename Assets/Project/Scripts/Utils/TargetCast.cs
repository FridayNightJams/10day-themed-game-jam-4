using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCast : MonoBehaviour
{
    [Header("Targeting Settings")]
    private Transform predictTarget;
    private GameObject targetCircle;
    private Vector3 lastMouseCastingPosition;
    private List<Vector3> trajectoryPoints;

    [Header("Prefabs")]
    [SerializeField] private GameObject drawLinePrefab;
    [SerializeField] private GameObject drawCirclePrefab;

    public void TargetingLine(Vector3 start, Vector3 end)
    {
        if (end != lastMouseCastingPosition)
        {
            if (predictTarget != null) Destroy(predictTarget.gameObject);
            if (targetCircle != null) Destroy(targetCircle);

            predictTarget = CreateLine(start, end);
            predictTarget.GetComponent<DrawLine>().height = 1;
            predictTarget.GetComponent<DrawLine>().points = 1;
            lastMouseCastingPosition = end;
        }
    }

    public void TargetingArk(Vector3 start, Vector3 end)
    {
        if (end != lastMouseCastingPosition)
        {
            if (predictTarget != null) Destroy(predictTarget.gameObject);
            if (targetCircle != null) Destroy(targetCircle);

            predictTarget = CreateLine(start, end);
            predictTarget.GetComponent<DrawLine>().height = 7;
            predictTarget.GetComponent<DrawLine>().points = 12;
            lastMouseCastingPosition = end;
        }
    }

    public void DestroyTarget()
    {
        if (predictTarget != null) Destroy(predictTarget.gameObject);
        if (targetCircle != null) Destroy(targetCircle);
    }

    private Transform CreateLine(Vector3 posA, Vector3 posB)
    {
        GameObject go = (GameObject)Instantiate(drawLinePrefab);
        go.name = "Line";
        go.GetComponent<DrawLine>().start = posA;
        go.GetComponent<DrawLine>().finish = posB;
        return go.transform;
    }

    public bool IsDistanceAcceptable(Vector3 start, Vector3 end, float limit)
    {
        return Vector3.Distance(start, end) < limit;
    }

    public List<Vector3> GetTrajectoryPoints()
    {
        return predictTarget.GetComponent<DrawLine>().trajectory;
    }
}
