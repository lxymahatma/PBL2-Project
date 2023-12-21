using System.Collections;
using System.Linq;
using UnityEngine;

// ReSharper disable NotDisposedResourceIsReturned

namespace Scripts
{
    public class LineAnimator : MonoBehaviour
    {
        [Tooltip("Animation duration in seconds")]
        [SerializeField] private float animationDuration = 5f;

        [Tooltip("Animation speed, left 0 to automatically calculate speed")]
        [SerializeField] private float animationSpeed;

        private Line[] _lines;

        private void Start()
        {
            var lineRenders = GetComponentsInChildren<LineRenderer>();
            _lines = new Line[lineRenders.Length];

            for (var i = 0; i < lineRenders.Length; i++)
            {
                _lines[i] = new Line(lineRenders[i]);
            }

            StartCoroutine(StartAnimation());
        }

        private IEnumerator StartAnimation() => _lines.Select(AnimateLine).GetEnumerator();

        private IEnumerator AnimateLine(Line line)
        {
            line.LineGameObject.SetActive(true);

            var segmentDuration = animationDuration / line.PositionsCount;

            for (var i = 0; i < line.PositionsCount - 1; i++)
            {
                var startPosition = line.LinePositions[i];
                var endPosition = line.LinePositions[i + 1];

                for (float t = 0; t <= 1; t += Time.deltaTime / segmentDuration)
                {
                    var pos = Vector3.Lerp(startPosition, endPosition, t);

                    // animate all other points except point at index i
                    for (var j = i + 1; j < line.PositionsCount; j++)
                    {
                        line.LineRenderer.SetPosition(j, pos);
                    }

                    yield return null;
                }
            }
        }
    }
}