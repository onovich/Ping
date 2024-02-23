using System.Net;
using System.Net.Sockets;
using System;

public static class IPHelper {

    public static string GetLocalIpAddress() {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList) {
            if (ip.AddressFamily == AddressFamily.InterNetwork) {
                return ip.ToString();
            }
        }
        throw new Exception("Local IP Address Not Found!");
    }
}
