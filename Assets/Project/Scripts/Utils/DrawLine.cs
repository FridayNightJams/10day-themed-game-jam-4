using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public float points = 12;
    public float height = 2;

    [HideInInspector]
    public Vector3 start;
    [HideInInspector]
    public Vector3 finish;
    [HideInInspector]
    public List<Vector3> trajectory;

    LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.useWorldSpace = false;
        createPoints();
    }

    public void createPoints()
    {
        Vector3 highest = new Vector3(
        (start.x + finish.x) / 2,
        height,
        (start.z + finish.z) / 2);

        List<Vector3> pointList = new List<Vector3>();

        for (float ratio = 0; ratio <= 1; ratio += 1 / points)
        {
            Vector3 tan1 = Vector3.Lerp(start, highest, ratio);
            Vector3 tan2 = Vector3.Lerp(highest, finish, ratio);
            Vector3 curve = Vector3.Lerp(tan1, tan2, ratio);

            pointList.Add(curve);
        }

        line.positionCount = pointList.Count;
        line.SetPositions(pointList.ToArray());
        trajectory.AddRange(pointList);
    }
}
