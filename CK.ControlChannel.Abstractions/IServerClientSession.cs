using System.Collections.Generic;

namespace CK.ControlChannel.Abstractions
{
    /// <summary>
    /// A session opened between the client and server
    /// </summary>
    public interface IServerClientSession
    {
        /// <summary>
        /// Session identifier, set by the server on successful authentication
        /// </summary>
        string SessionId { get; }

        /// <summary>
        /// Name given by the client when starting this session, for identification and display
        /// </summary>
        string ClientName { get; }

        /// <summary>
        /// Returns true if this session is still connected.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Returns true if this session was successfully authenticated by the server,
        /// and can send and receive messages.
        /// </summary>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Data provided by the client when authenticating.
        /// Contents depend on implementation.
        /// </summary>
        IReadOnlyDictionary<string, string> ClientData { get; }

        /// <summary>
        /// Gets an outgoing channel with the given <paramref name="channelName"/> connected in this <see cref="IServerClientSession"/>.
        /// </summary>
        /// <param name="channelName">Name of the channel to obtain.</param>
        /// <returns>An <see cref="IOutgoingChannel"/> with the given <paramref name="channelName"/> connected to this <see cref="IServerClientSession"/>.</returns>
        IOutgoingChannel GetOutgoingChannel( string channelName );
    }
}
