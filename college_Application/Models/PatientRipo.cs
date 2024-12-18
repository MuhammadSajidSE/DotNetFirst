namespace college_Application.Models
{
    public class PatientRipo
    {
        public static List<Patinets> Patients { get; set; } = new List<Patinets>()
        {
            new Patinets
                {
                    id = 1,
                    name = "Muhammad Sajid",
                    address = "Karachi",
                    sex = 'F',
                    emai = "Sajid@gmail.com"
                },
                new Patinets
                {
                    id = 2,
                    name = "saad",
                    address = "Karachi",
                    sex = 'B',
                    emai = "saad@gmail.com"
                },
                new Patinets
                {
                    id = 3,
                    name = "Huzaifa",
                    address = "Karachi",
                    sex = 'A',
                    emai = "huzaifa@gmail.com"
                },
        };
    }
}
