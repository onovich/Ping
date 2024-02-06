using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ping {

    public static class CommonExtension {

        public static Vector3 ToVector3(this Vector2 vector2) {
            var vector3 = new Vector3(vector2.x, vector2.y, 0);
            return vector3;
        }

        public static Vector2 ToVector2(this Vector3 vector3) {
            var vector2 = new Vector2(vector3.x, vector3.y);
            return vector2;
        }

        public static Vector3Int RoundToVector3Int(this Vector3 vector3) {
            var vector3Int = new Vector3Int(Mathf.RoundToInt(vector3.x), Mathf.RoundToInt(vector3.y), Mathf.RoundToInt(vector3.z));
            return vector3Int;
        }

        public static Vector2Int RoundToVector2Int(this Vector2 vector2) {
            var vector2Int = new Vector2Int(Mathf.RoundToInt(vector2.x), Mathf.RoundToInt(vector2.y));
            return vector2Int;
        }

        public static Vector3Int ToVector3Int(this Vector2Int vector2Int) {
            var vector3Int = new Vector3Int(vector2Int.x, vector2Int.y, 0);
            return vector3Int;
        }

        public static Vector2Int ToVector2Int(this Vector3Int vector3Int) {
            var vector2Int = new Vector2Int(vector3Int.x, vector3Int.y);
            return vector2Int;
        }

        public static bool GetNearestCell(this Vector2Int[] cells, int cellLen, Vector2 pos, float radius, Predicate<Vector2Int> predicate, out Vector2Int result) {
            Vector2Int nearestCell = Vector2Int.zero;
            float nearestDistance = float.MaxValue;
            float radiusSqr = radius * radius;
            bool has = false;
            for (int i = 0; i < cellLen; i++) {
                Vector2Int cell = cells[i];
                float disSqr = Vector2.SqrMagnitude(cell - pos);
                if (predicate(cell) && disSqr <= radiusSqr && disSqr < nearestDistance) {
                    nearestDistance = disSqr;
                    nearestCell = cell;
                    has = true;
                }
            }
            result = nearestCell;
            return has;
        }

        public static TValue GetOrAdd<TKey, TValue>(this SortedList<TKey, TValue> sortedList, TKey key, Func<TValue> valueFactory) {
            if (!sortedList.TryGetValue(key, out TValue value)) {
                value = valueFactory();
                sortedList.Add(key, value);
            }
            return value;
        }

        public static TValue GetOrAdd<TKey, TValue>(this SortedDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueFactory) {
            if (!dictionary.TryGetValue(key, out TValue value)) {
                value = valueFactory();
                dictionary.Add(key, value);
            }
            return value;
        }

        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueFactory) {
            if (!dictionary.TryGetValue(key, out TValue value)) {
                value = valueFactory();
                dictionary.Add(key, value);
            }
            return value;
        }

    }

}