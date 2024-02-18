using UnityEngine;
using System.Runtime.CompilerServices;

namespace Ping {

    public static class PLog {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log(string msg) {
            Debug.Log(msg);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LogWarning(string msg) {
            Debug.LogWarning(msg);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LogError(string msg) {
            Debug.LogError(msg);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LogAssert(bool condition, string msg) {
            Debug.Assert(condition, msg);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LogAssertWithoutMsg(bool condition) {
            Debug.Assert(condition);
        }

    }

}