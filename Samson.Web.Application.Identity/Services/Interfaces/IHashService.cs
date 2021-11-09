namespace Samson.Web.Application.Identity.Services.Interfaces
{
    /// <summary>
    /// Service to hash password and validate it
    /// </summary>
    public interface IHashService
    {
        /// <summary>
        /// Compare password to hash
        /// </summary>
        /// <param name="password">Passed password</param>
        /// <param name="hashedPassword">Stored hashed password</param>
        /// <returns></returns>
        public bool Verify(string password, string hashedPassword);

        /// <summary>
        /// Hash password
        /// </summary>
        /// <param name="password">Password to hash</param>
        /// <returns>Hashed password</returns>
        public string HashPassword(string password);
    }
}
