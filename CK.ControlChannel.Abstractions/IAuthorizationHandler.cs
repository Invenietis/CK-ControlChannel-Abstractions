namespace CK.ControlChannel.Abstractions
{
    public interface IAuthorizationHandler
    {
        /// <summary>
        /// Returns true if the client is authorized to start a session.
        /// </summary>
        /// <param name="s">The client session to verify</param>
        /// <returns>True if the client is authorized to start a session; otherwise false</returns>
        bool OnAuthorizeSession( IServerClientSession s );
    }
}
