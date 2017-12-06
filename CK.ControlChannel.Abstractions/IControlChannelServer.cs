using CK.Core;
using System.Collections.Generic;

namespace CK.ControlChannel.Abstractions
{
    /// <summary>
    /// Delegate called when handling data received on an incoming channel
    /// </summary>
    /// <param name="monitor">A monitor created by this <see cref="IControlChannelServer"/> upon receiving data</param>
    /// <param name="payload">Data received</param>
    /// <param name="clientSession">Session of this client</param>
    public delegate void ServerChannelDataHandler( IActivityMonitor monitor, byte[] payload, IServerClientSession clientSession );

    /// <summary>
    /// Control channel server interface
    /// </summary>
    public interface IControlChannelServer
    {
        /// <summary>
        /// Gets the host bound to this <see cref="IControlChannelServer"/>
        /// </summary>
        string Host { get; }

        /// <summary>
        /// Gets the port bound to this <see cref="IControlChannelServer"/>
        /// </summary>
        int Port { get; }

        /// <summary>
        /// Returns true if connections to this <see cref="IControlChannelServer"/> are securely encrypted.
        /// </summary>
        bool IsSecure { get; }

        /// <summary>
        /// Returns true if this <see cref="IControlChannelServer"/> is actively listening to connections.
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// Causes this instance of <see cref="IControlChannelServer"/> to start listening to connections
        /// </summary>
        void Open();

        /// <summary>
        /// Causes this instance of <see cref="IControlChannelServer"/> to stop listening to connections
        /// </summary>
        void Close();

        /// <summary>
        /// Registers a data handler for the given <paramref name="channelName"/>.
        /// </summary>
        /// <param name="channelName">Name of the channel</param>
        /// <param name="handler">Data handler</param>
        void RegisterChannelHandler( string channelName, ServerChannelDataHandler handler );

        /// <summary>
        /// Gets the client sessions that are connected and have been successfully authenticated with this <see cref="IControlChannelServer"/>.
        /// </summary>
        IEnumerable<IServerClientSession> ActiveSessions { get; }
    }

}
