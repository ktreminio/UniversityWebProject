namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Extensions
{
    public static class DateTimeExtension
    {
        public static int GetAge(this DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
