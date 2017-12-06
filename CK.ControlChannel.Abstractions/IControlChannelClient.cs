using CK.Core;
using System.Threading.Tasks;

namespace CK.ControlChannel.Abstractions
{
    /// <summary>
    /// Delegate called when handling data received on an incoming channel from the connected server
    /// </summary>
    /// <param name="monitor">A monitor created by this <see cref="IControlChannelClient"/> upon receiving data</param>
    /// <param name="payload">Data received</param>
    public delegate void ClientChannelDataHandler( IActivityMonitor monitor, byte[] payload );

    /// <summary>
    /// Client for IControlChannelServer implementations.
    /// </summary>
    public interface IControlChannelClient
    {
        /// <summary>
        /// Gets the server host bound to this <see cref="IControlChannelClient"/>
        /// </summary>
        string Host { get; }

        /// <summary>
        /// Gets the server port bound to this <see cref="IControlChannelClient"/>
        /// </summary>
        int Port { get; }

        /// <summary>
        /// Returns true if connections with this <see cref="IControlChannelClient"/> are securely encrypted.
        /// </summary>
        bool IsSecure { get; }

        /// <summary>
        /// Returns true if this <see cref="IControlChannelClient"/> has established a connection with the server.
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// Registers a data handler for message payloads coming in an incoming channel with the given <paramref name="channelName"/>.
        /// </summary>
        /// <param name="channelName">Name of the channel</param>
        /// <param name="handler">Data handler</param>
        Task RegisterChannelHandlerAsync( string channelName, ClientChannelDataHandler handler );

        /// <summary>
        /// Opens, or gets an already-open outgoing channel with the server.
        /// </summary>
        /// <param name="channelName">Name of the channel to obtain.</param>
        /// <returns>An awaitable task resolving with an <see cref="IOutgoingChannel"/> with the given <paramref name="channelName"/>.</returns>
        Task<IOutgoingChannel> OpenOutgoingChannelAsync( string channelName );
    }
}
