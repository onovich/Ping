using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ping.Server {

    public class AABB {

        Vector2 min;
        Vector2 max;

        public AABB(Vector2 min, Vector2 max) {
            this.min = min;
            this.max = max;
        }

        public bool Contains(Vector2 point) {
            return point.x >= min.x && point.x <= max.x && point.y >= min.y && point.y <= max.y;
        }

        public bool Intersects(AABB other) {
            return min.x <= other.max.x && max.x >= other.min.x && min.y <= other.max.y && max.y >= other.min.y;
        }

        public Vector2 GetMin() {
            return min;
        }

        public Vector2 GetMax() {
            return max;
        }

        public Vector2 GetCenter() {
            return (min + max) / 2;
        }

        public Vector2 GetSize() {
            return max - min;
        }

        public float GetHeight() {
            return max.y - min.y;
        }

        public float GetWidth() {
            return max.x - min.x;
        }

        public void SetCenter(Vector2 center) {
            var size = GetSize();
            min = center - size / 2;
            max = center + size / 2;
        }

    }

}