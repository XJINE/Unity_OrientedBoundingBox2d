using UnityEngine;

[System.Serializable]
public class OrientedBoundingBox2d
{
    #region Field

    public Vector2 position;
    public Vector2 scale;
    public float   rotation;
    public Color   color;

    Vector2 halfScale;
    Vector2 unitVectorX;
    Vector2 unitVectorY;

    #endregion Field

    #region Method

    public void Initialize()
    {
        Quaternion rotation = Quaternion.AngleAxis(this.rotation, Vector3.forward);

        this.halfScale   = scale * 0.5f;
        this.unitVectorX = rotation * Vector2.right;
        this.unitVectorY = rotation * Vector2.up;
    }

    public bool Collide(Vector2 point)
    {
        Vector2 dir = point - this.position;

        float x = Vector2.Dot(dir, this.unitVectorX) / this.halfScale.x;

        if (Mathf.Abs(x) > 1) { return false; }

        float y = Vector2.Dot(dir, this.unitVectorY) / this.halfScale.y;

        return Mathf.Abs(y) < 1;
    }

    public virtual void DrawGizmos()
    {
        #if UNITY_EDITOR

        Matrix4x4 tempMatrix = Gizmos.matrix;
        Color     tempColor  = Gizmos.color;

        Gizmos.color = this.color;

        Gizmos.matrix = Matrix4x4.TRS(position, Quaternion.AngleAxis(rotation, Vector3.forward), scale);
        Gizmos.DrawWireCube (Vector3.zero, Vector3.one);

        Gizmos.matrix = tempMatrix;
        Gizmos.DrawLine(this.position, this.position + this.unitVectorY * halfScale.y);

        Gizmos.color = tempColor;

        #endif // UNITY_EDITOR
    }

    #endregion Method
}