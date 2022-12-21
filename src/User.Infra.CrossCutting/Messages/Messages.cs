using User.Infra.CrossCutting.Properties;

namespace User.Infra.CrossCutting.Messages
{
    public static class Messages
    {
        /// <summary>
        /// return something similar to "System error, contact the administrator of system."
        /// </summary>
        /// <returns></returns>
        public static string SystemError
        {
            get
            {
                return Resources.SystemError;
            }
        }

        /// <summary>
        /// return something similar to "Successfully created user."
        /// </summary>
        /// <returns></returns>
        public static string UserCreated
        {
            get 
            {
                return Resources.UserCreated;
            }
        }

        /// <summary>
        /// return something similar to "Successfully updated user."
        /// </summary>
        /// <returns></returns>
        public static string UserUpdated
        {
            get
            {
                return Resources.UserUpdated;
            }
        }
        
        /// <summary>
        /// return something similar to "Successfully deleted user."
        /// </summary>
        /// <returns></returns>
        public static string UserDeleted
        {
            get
            {
                return Resources.UserDeleted;
            }
        } 
        
        /// <summary>
        /// return something similar to "Successfully updated user password."
        /// </summary>
        /// <returns></returns>
        public static string UserPassworUpdated
        {
            get
            {
                return Resources.UserPassworUpdated;
            }
         }
        
        /// <summary>
        /// return something similar to "User not found."
        /// </summary>
        /// <returns></returns>
        public static string UserNotFound
        {
            get
            {
                return Resources.UserNotFound;
            }        }

        /// <summary>
        /// return something similar to "Successfully authenticated user."
        /// </summary>
        /// <returns></returns>
        public static string AuthenticatedUser
        {
            get
            {
                return Resources.AuthenticatedUser;
            }        }

        /// <summary>
        /// return something similar to "Unauthorized user."
        /// </summary>
        /// <returns></returns>
        public static string UnauthorizedUser
        {
            get
            {
                return Resources.UnauthorizedUser;
            }        }
    }
}
