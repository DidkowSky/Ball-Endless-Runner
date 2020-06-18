using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    [CreateAssetMenu(fileName = "LevelSegments", menuName = "Tools/Level Segments")]
    public class LevelSegments : ScriptableObject
    {
        public List<TrailSegment> Segments = new List<TrailSegment>();

        public float GetMaxForwardExtensionValue()
        {
            var maxValue = 0.0f;

            for (int i = 0; i < Segments.Count; i++)
            {
                if (Segments[i].ForwardExtension > maxValue)
                    maxValue = Segments[i].ForwardExtension;
            }

            return maxValue;
        }
    }
}
