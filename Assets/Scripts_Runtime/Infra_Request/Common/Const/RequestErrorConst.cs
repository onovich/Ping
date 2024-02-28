using System.Collections.Generic;

namespace Ping.Requests {

    public static class RequestErrorMessages {

        public static readonly Dictionary<int, string> ErrorMessages = new Dictionary<int, string> {
            {-1, "Socket error occurred."},
            {0, "Operation completed successfully."},
            {995, "Operation aborted."},
            {997, "IO operation pending."},
            {10004, "Operation interrupted."},
            {10013, "Access denied."},
            {10014, "Bad address."},
            {10022, "Invalid argument."},
            {10024, "Too many open sockets."},
            {10035, "Operation would block."},
            {10036, "Operation now in progress."},
            {10037, "Operation already in progress."},
            {10038, "Socket operation on non-socket."},
            {10039, "Destination address required."},
            {10040, "Message too long."},
            {10041, "Protocol wrong type for socket."},
            {10042, "Bad protocol option."},
            {10043, "Protocol not supported."},
            {10044, "Socket type not supported."},
            {10045, "Operation not supported."},
            {10046, "Protocol family not supported."},
            {10047, "Address family not supported by protocol family."},
            {10048, "Address already in use."},
            {10049, "Cannot assign requested address."},
            {10050, "Network is down."},
            {10051, "Network is unreachable."},
            {10052, "Network dropped connection on reset."},
            {10053, "Software caused connection abort."},
            {10054, "Connection reset by peer."},
            {10055, "No buffer space available."},
            {10056, "Socket is already connected."},
            {10057, "Socket is not connected."},
            {10058, "Cannot send after socket shutdown."},
            {10060, "Connection timed out."},
            {10061, "Connection refused."},
            {10064, "Host is down."},
            {10065, "No route to host."},
            {10067, "Too many processes."},
            {10091, "Network subsystem is unavailable."},
            {10092, "WINSOCK.DLL version out of range."},
            {10093, "Successful WSAStartup not yet performed."},
            {10101, "Graceful shutdown in progress."},
            {10109, "Class type not found."},
            {11001, "Host not found."},
            {11002, "Try again."},
            {11003, "No recovery possible."},
            {11004, "No data record of requested type."}
        };

    }

}
