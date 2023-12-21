using UnityEngine;

namespace Scripts
{
    public class Line
    {
        public LineRenderer LineRenderer { get; }
        public GameObject LineGameObject { get; }
        public int PositionsCount { get; }
        public Vector3[] LinePositions { get; }

        public Line(LineRenderer lineRenderer)
        {
            LineRenderer = lineRenderer;
            LineGameObject = lineRenderer.gameObject;
            PositionsCount = lineRenderer.positionCount;
            LinePositions = new Vector3[PositionsCount];

            LineGameObject.SetActive(false);

            for (var i = 0; i < PositionsCount; i++)
            {
                LinePositions[i] = LineRenderer.GetPosition(i);
            }
        }
    }
}