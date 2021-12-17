

namespace Samson.Web.Application.Models.Resources
{
    /// <summary>
    /// Represent set of messages for BusinessLogicException. Allow to show human-readable messages and identify BusinessLogicExceptionByMessage.
    /// </summary>
    public class DomainMessage
    {
        public static string EndDateIsEarlierThanStartDate = "Data rozpoczęcia powinna być przed datą zakończenia";
        public static string ClientIdIsRequired = "Informacja o użytkowniku jest obowiązkowa";
        public static string InvalidTrainingType = "Nieprawidłowy typ treningu";
    }
}
