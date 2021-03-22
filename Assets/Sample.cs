using UnityEngine;

public class Sample : MonoBehaviour
{
    public GameObject point;

    public OrientedBoundingBox2d[] bounds;

    void Start()
    {
        foreach (OrientedBoundingBox2d obb in this.bounds)
        {
            obb.Initialize();
        }
    }

    void OnDrawGizmos()
    {
        foreach (OrientedBoundingBox2d obb in this.bounds)
        {
            obb.Initialize();
            obb.color = obb.Collide(point.transform.position) ? Color.red : Color.white;
            obb.DrawGizmos();
        }
    }
}