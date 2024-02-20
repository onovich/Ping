using System;
using System.IO;
using UnityEngine;

namespace Ping {

    public static class FileHelper {

        public static void SaveBytes(string path, byte[] data, int len) {
            using (var stream = File.Open(path, FileMode.Create)) {
                stream.Write(data, 0, len);
                stream.Flush();
            }
        }

        public static void LoadBytes(string path, byte[] buffer) {
            using (var stream = File.Open(path, FileMode.Open)) {
                stream.Read(buffer, 0, buffer.Length);
                stream.Flush();
            }
        }

        public static bool Exists(string path) {
            return File.Exists(path);
        }

    }

}