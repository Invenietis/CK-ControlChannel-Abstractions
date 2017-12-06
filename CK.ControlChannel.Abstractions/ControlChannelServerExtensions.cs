using CK.ControlChannel.Abstractions;
using System;
using System.Threading.Tasks;

namespace CK.ControlChannel
{
    public static class ControlChannelServerExtensions
    {
        /// <summary>
        /// Broadcasts data on a given channel to all connected and authenticated clients
        /// </summary>
        /// <param name="this">The <see cref="IControlChannelServer"/> to use</param>
        /// <param name="channelName">The name of the channel</param>
        /// <param name="payload">The data to send</param>
        public static async Task BroadcastAsync( this IControlChannelServer @this, string channelName, byte[] payload )
        {
            if( @this == null ) { throw new ArgumentNullException( nameof( @this ) ); }
            if( channelName == null ) { throw new ArgumentNullException( nameof( channelName ) ); }

            foreach( IServerClientSession session in @this.ActiveSessions )
            {
                IOutgoingChannel channel = session.GetOutgoingChannel( channelName );
                if( channel.CanSend )
                {
                    await channel.SendAsync( payload );
                }
            }
        }
    }
}
