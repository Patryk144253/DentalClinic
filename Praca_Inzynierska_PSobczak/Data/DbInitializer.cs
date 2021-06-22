using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Praca_Inzynierska_PSobczak.Models;

namespace Praca_Inzynierska_PSobczak.Data
{
    public class DbInitializer // klasa wypełniająca bazę danych w przypadku kiedy jest pusta , aby sprawdzać od razu funkcjonalności
    {
        public static void Initialize (ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any()) // szukamy czy w bazie posiadamy jakiś użytkowników
            {
                return; //jezeli są to nic nie robimy
            }

            var users = new User[]
            {
                new User {FirstName = "Client", LastName="Client1",Email = "Client1@user.pl", Password = "Password!2", UserType = (UserType)0}, //tworzymy szkielet dla uzytkownika
                 new User {FirstName = "Client", LastName="Client2",Email = "Client2@user.pl", Password = "Password!2", UserType = (UserType)0},
                  new User {FirstName = "Registar", LastName="Registar1",Email = "Registar1@user.pl", Password = "Password!2", UserType = (UserType)1},
                   new User {FirstName = "Admin", LastName="Admin1",Email = "Admin1@user.pl", Password = "Password!2", UserType = (UserType)2}
            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            var doctors = new Doctor[]
            {
                new Doctor{FirstName = "Doctor", LastName = "Doctor1"}
            };
            foreach (Doctor d in doctors)
            {
                context.Doctors.Add(d);
            }
            context.SaveChanges();

        }
    }
}
