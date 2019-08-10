using System;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Spa_System.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Spa_SystemContext(
                serviceProvider.GetRequiredService<DbContextOptions<Spa_SystemContext>>()))
            {

                if (context.Beautician.Any()) //if the database is not empty
                {
                    return;
                }

                var beautician = new Beautician[]
                {
                new Beautician{
                            Name = "Sally Spa", ContactNumber = "012-211 1234", Age = 21},
                new Beautician
                        {
                            Name = "Kelly Junior",ContactNumber = "012-161 1314", Age = 31
                        },
                        new Beautician
                        {
                            Name = "John Wick",ContactNumber = "012-001 3951", Age = 44
                        },
                        new Beautician
                        {
                            Name = "Papa John",ContactNumber = "018-391 0314", Age = 37
                        },
                        new Beautician {Name = "Daddy Mike", ContactNumber = "019-294 9201", Age = 42}
                };

                foreach (Beautician b in beautician)
                {
                    context.Beautician.Add(b);
                }
                context.SaveChanges();

                context.Treatment.AddRange(
                      new Treatment { Name = "Cucumber Facial" },
                      new Treatment { Name = "Cherry Tomato Body Scrub" },
                      new Treatment { Name = "Milk Bath" },
                      new Treatment { Name = "Surprise Facial and Body Massage" },
                      new Treatment { Name = "Seaweed SM Wrap" });

                context.SaveChanges();

                context.Packages.AddRange(
                    new Package { PackageName = "Super Face Package", Price = 299 },
                    new Package { PackageName = "Super Body Package", Price = 599 },
                    new Package { PackageName = "Royal Spa", Price = 1299 },
                    new Package { PackageName = "Just The Body", Price = 399 },
                    new Package { PackageName = "Creampie Special", Price = 99 });

                context.SaveChanges();

                context.PackageTreatment.AddRange(
                    new PackageTreatment { PackageID = 1, TreatmentID = 1 },
                    new PackageTreatment { PackageID = 1, TreatmentID = 2 },
                    new PackageTreatment { PackageID = 1, TreatmentID = 3 },
                    new PackageTreatment { PackageID = 2, TreatmentID = 4 },
                    new PackageTreatment { PackageID = 3, TreatmentID = 5 },
                    new PackageTreatment { PackageID = 3, TreatmentID = 1 },
                    new PackageTreatment { PackageID = 4, TreatmentID = 2 },
                    new PackageTreatment { PackageID = 4, TreatmentID = 5 },
                    new PackageTreatment { PackageID = 5, TreatmentID = 2 },
                    new PackageTreatment { PackageID = 5, TreatmentID = 4 }
                    );

                context.SaveChanges();

                context.Customer.AddRange(
                    new Customer { Name = "Sammy Sowantbeauty", Age = 29, ContactNumber = "012-213 1267", Gender = "F" },
                    new Customer { Name = "Jake Farron", Age = 21, ContactNumber = "012-213 4729", Gender = "M" },
                    new Customer { Name = "Soh Wai Kah", Age = 20, ContactNumber = "012-129 0471", Gender = "M" },
                    new Customer { Name = "Katarina Ballarina", Age = 27, ContactNumber = "012-184 9432", Gender = "F" },
                    new Customer { Name = "Aunty Cindy", Age = 34, ContactNumber = "012-213 5839", Gender = "F" },
                    new Customer { Name = "Uncle Wil Son", Age = 33, ContactNumber = "012-490 4931", Gender = "M" },
                    new Customer { Name = "Anne Anna Anbelle", Age = 29, ContactNumber = "012-103 0105", Gender = "F" }

                    );

                context.SaveChanges();

                CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                context.PackageAppointment.AddRange(
                        new PackageAppointment { AppointmentDate = DateTime.Parse("09/12/2019", CultureInfo.CurrentCulture), AppointmentTime = DateTime.Parse("1 PM"), BeauticianID = 2, CustomerID = 1, PackageID = 2, discountGiven = 0, Status = "Registered/Unpaid" },
                        new PackageAppointment { AppointmentDate = DateTime.Parse("09/1/2019", CultureInfo.CurrentCulture), AppointmentTime = DateTime.Parse("2 PM"), BeauticianID = 1, CustomerID = 1, PackageID = 3, discountGiven = 0, Status = "Registered/Unpaid" },
                        new PackageAppointment { AppointmentDate = DateTime.Parse("08/31/2019", CultureInfo.CurrentCulture), AppointmentTime = DateTime.Parse("10 AM"), BeauticianID = 3, CustomerID = 3, PackageID = 1, discountGiven = 0, Status = "Registered/Unpaid" },
                        new PackageAppointment { AppointmentDate = DateTime.Parse("09/10/2019", CultureInfo.CurrentCulture), AppointmentTime = DateTime.Parse("11 AM"), BeauticianID = 4, CustomerID = 4, PackageID = 2, discountGiven = 0, Status = "Registered/Unpaid" },
                        new PackageAppointment { AppointmentDate = DateTime.Parse("09/20/2019", CultureInfo.CurrentCulture), AppointmentTime = DateTime.Parse("12 PM"), BeauticianID = 2, CustomerID = 3, PackageID = 5, discountGiven = 0, Status = "Registered/Unpaid" },
                        new PackageAppointment { AppointmentDate = DateTime.Parse("09/1/2019", CultureInfo.CurrentCulture), AppointmentTime = DateTime.Parse("12 PM"), BeauticianID = 1, CustomerID = 5, PackageID = 3, discountGiven = 0, Status = "Registered/Unpaid" },
                        new PackageAppointment { AppointmentDate = DateTime.Parse("09/2/2019", CultureInfo.CurrentCulture), AppointmentTime = DateTime.Parse("1 PM"), BeauticianID = 1, CustomerID = 4, PackageID = 3, discountGiven = 0, Status = "Registered/Unpaid" },
                        new PackageAppointment { AppointmentDate = DateTime.Parse("09/2/2019", CultureInfo.CurrentCulture), AppointmentTime = DateTime.Parse("3 PM"), BeauticianID = 5, CustomerID = 6, PackageID = 4, discountGiven = 0, Status = "Registered/Unpaid" },
                        new PackageAppointment { AppointmentDate = DateTime.Parse("09/3/2019", CultureInfo.CurrentCulture), AppointmentTime = DateTime.Parse("10 AM"), BeauticianID = 5, CustomerID = 3, PackageID = 1, discountGiven = 0, Status = "Registered/Unpaid" },
                        new PackageAppointment { AppointmentDate = DateTime.Parse("09/5/2019", CultureInfo.CurrentCulture), AppointmentTime = DateTime.Parse("9 AM"), BeauticianID = 2, CustomerID = 7, PackageID = 4, discountGiven = 0, Status = "Registered/Unpaid" },
                        new PackageAppointment { AppointmentDate = DateTime.Parse("09/10/2019", CultureInfo.CurrentCulture), AppointmentTime = DateTime.Parse("10 AM"), BeauticianID = 1, CustomerID = 6, PackageID = 5, discountGiven = 0, Status = "Registered/Unpaid" },
                        new PackageAppointment { AppointmentDate = DateTime.Parse("09/15/2019", CultureInfo.CurrentCulture), AppointmentTime = DateTime.Parse("1 PM"), BeauticianID = 5, CustomerID = 3, PackageID = 5, discountGiven = 0, Status = "Registered/Unpaid" },
                        new PackageAppointment { CustomerID = 5, PackageID = 5, discountGiven = 0, Status = "Registered/Unpaid" },
                        new PackageAppointment { CustomerID = 3, PackageID = 2, discountGiven = 0, Status = "Registered/Unpaid" },
                        new PackageAppointment { CustomerID = 1, PackageID = 1, discountGiven = 0, Status = "Registered/Unpaid" },
                        new PackageAppointment { CustomerID = 2, PackageID = 3, discountGiven = 0, Status = "Registered/Unpaid" },
                        new PackageAppointment { CustomerID = 3, PackageID = 4, discountGiven = 0, Status = "Registered/Unpaid" },
                        new PackageAppointment { CustomerID = 6, PackageID = 2, discountGiven = 0, Status = "Registered/Unpaid" },
                        new PackageAppointment { CustomerID = 7, PackageID = 1, discountGiven = 0, Status = "Registered/Unpaid" }

                    );
                context.SaveChanges();

                //context.CustomerPackages.AddRange(
                //    new CustomerPackage { CustomerID = 1, PackageID = 1, discountGiven = 0, Status = "Registered"},
                //    new CustomerPackage { CustomerID = 1, PackageID = 5, discountGiven = 0, Status = "Registered" },
                //    new CustomerPackage { CustomerID = 1, PackageID = 3, discountGiven = 0, Status = "Registered" },
                //    new CustomerPackage { CustomerID = 4, PackageID = 1, discountGiven = 0, Status = "Registered"},
                //    new CustomerPackage { CustomerID = 2, PackageID = 2, discountGiven = 0, Status = "Registered" },
                //    new CustomerPackage { CustomerID = 7, PackageID = 5, discountGiven = 0, Status = "Registered" },
                //    new CustomerPackage { CustomerID = 5, PackageID = 4, discountGiven = 0, Status = "Registered" },
                //    new CustomerPackage { CustomerID = 6, PackageID = 3, discountGiven = 0, Status = "Registered" },
                //    new CustomerPackage { CustomerID = 2, PackageID = 1, discountGiven = 0, Status = "Registered"},
                //    new CustomerPackage { CustomerID = 2, PackageID = 2, discountGiven = 0, Status = "Registered" },
                //    new CustomerPackage { CustomerID = 5, PackageID = 3, discountGiven = 0, Status = "Registered" },
                //    new CustomerPackage { CustomerID = 6, PackageID = 2, discountGiven = 0, Status = "Registered" },
                //    new CustomerPackage { CustomerID = 7, PackageID = 3, discountGiven = 0, Status = "Registered" },
                //    new CustomerPackage { CustomerID = 1, PackageID = 4, discountGiven = 0, Status = "Registered" },
                //    new CustomerPackage { CustomerID = 3, PackageID = 5, discountGiven = 0, Status = "Registered" },
                //    new CustomerPackage { CustomerID = 5, PackageID = 5, discountGiven = 0, Status = "Registered" },
                //    new CustomerPackage { CustomerID = 6, PackageID = 2, discountGiven = 0, Status = "Registered" },
                //    new CustomerPackage { CustomerID = 7, PackageID = 3, discountGiven = 0, Status = "Registered" },
                //    new CustomerPackage { CustomerID = 3, PackageID = 5, discountGiven = 0, Status = "Registered" },
                //    new CustomerPackage { CustomerID = 2, PackageID = 1, discountGiven = 0, Status = "Registered"}

                //    );
                //context.SaveChanges();


                //context.Appointment.AddRange(
                //    new PackageAppointment { AppointmentDate = DateTime.Parse("09/12/2019"), AppointmentTime = DateTime.Parse("1 PM"), BeauticianID = 2, CustomerPackageID = 2 },
                //    new PackageAppointment { AppointmentDate = DateTime.Parse("09/1/2019"), AppointmentTime = DateTime.Parse("2 PM"), BeauticianID = 1, CustomerPackageID = 1 },
                //    new PackageAppointment { AppointmentDate = DateTime.Parse("08/31/2019"), AppointmentTime = DateTime.Parse("10 AM"), BeauticianID = 3, CustomerPackageID = 3 },
                //    new PackageAppointment { AppointmentDate = DateTime.Parse("09/10/2019"), AppointmentTime = DateTime.Parse("11 AM"), BeauticianID = 4, CustomerPackageID = 4 },
                //    new PackageAppointment { AppointmentDate = DateTime.Parse("09/20/2019"), AppointmentTime = DateTime.Parse("12 PM"), BeauticianID = 2, CustomerPackageID = 3 },
                //    new PackageAppointment { AppointmentDate = DateTime.Parse("09/1/2019"), AppointmentTime = DateTime.Parse("12 PM"), BeauticianID = 1, CustomerPackageID = 5 },
                //    new PackageAppointment { AppointmentDate = DateTime.Parse("09/2/2019"), AppointmentTime = DateTime.Parse("1 PM"), BeauticianID = 1, CustomerPackageID = 9 },
                //    new PackageAppointment { AppointmentDate = DateTime.Parse("09/2/2019"), AppointmentTime = DateTime.Parse("3 PM"), BeauticianID = 5, CustomerPackageID = 8 },
                //    new PackageAppointment { AppointmentDate = DateTime.Parse("09/3/2019"), AppointmentTime = DateTime.Parse("10 AM"), BeauticianID = 5, CustomerPackageID = 3 },
                //    new PackageAppointment { AppointmentDate = DateTime.Parse("09/5/2019"), AppointmentTime = DateTime.Parse("9 AM"), BeauticianID = 2, CustomerPackageID = 7 },
                //    new PackageAppointment { AppointmentDate = DateTime.Parse("09/10/2019"), AppointmentTime = DateTime.Parse("10 AM"), BeauticianID = 1, CustomerPackageID = 6 },
                //    new PackageAppointment { AppointmentDate = DateTime.Parse("09/15/2019"), AppointmentTime = DateTime.Parse("1 PM"), BeauticianID = 5, CustomerPackageID = 3 }
                //);

            }

        }
    }
}
