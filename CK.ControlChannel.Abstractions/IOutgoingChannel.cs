using System.Threading.Tasks;

namespace CK.ControlChannel.Abstractions
{
    /// <summary>
    /// An outgoing channel, bound to a remote endpoint.
    /// </summary>
    public interface IOutgoingChannel
    {
        /// <summary>
        /// Name of the channel.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Returns true if data can be sent on this channel.
        /// </summary>
        bool CanSend { get; }

        /// <summary>
        /// Sends a message payload asynchronously on this channel.
        /// </summary>
        /// <returns>An awaitable task, which completes when the message payload has been successfully sent on this channel.</returns>
        Task SendAsync( byte[] payload );
    }

}
