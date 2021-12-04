namespace Samson.Web.Application.Resources
{
    /// <summary>
    /// Represent set of messages for BusinessLogicException. Allow to show human-readable messages and identify BusinessLogicExceptionByMessage.
    /// </summary>
    public static class ApplicationMessage
    {
        public static string ClientNotFound = "Nie znaleziono klienta";
        public static string GymPassNotFound = "Nie znaleziono karnetu";
        public static string LoginAlreadyExist = "Ten login jest już zajęty";
        public static string UserAlreadySignedUpEvent = "To konto już jest zapisane na to wydarzenie";
        public static string TooManyParticipants = "Na to wydarzenie jest już zapisana maksymalna ilość uczestników";
        public static string EventNoLongerAvailable = "To wydarzenie nie jest już dostępne";

        public static string ClientNotTakePart =
            "Nie można zrezygnować, ponieważ użytkownik nie brał wogóle udziału w wydarzeniu";

        public static string EventNotFound = "Nie znaleziono wydarzenia";
        public static string ExerciseMachineNotFound = "Nie znaleziono maszyny do ćwiczeń";
        public static string NotValidSubscription = "Użytkownik nie posiada ważnego karnetu";
        public static string GymIsFull = "Na siłowni osiągnięto limit ilości osób";
        public static string GymObjectNotFound = "Nie znaleziono siłowni";
        public static string IndividualTrainingNotFound = "Nie znaleziono treningu indywidualnego";
        public static string InvalidPassword = "Niepoprawne hasło użytkownika";
        public static string InvalidUser = "Nie znaleziono użytkownika o tym loginie";
        public static string InvalidPasswordToDelete = "Hasło niepoprawne. Nie można usunąć konta";
        public static string UserNotFound = "Nie można odnaleźć użytkownika";
    }
}
