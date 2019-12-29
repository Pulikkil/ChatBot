using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommerceBot.Model;
using CommerceBot.Repository;
using System.Linq;

namespace CommerceBot.Services
{
    public class ServiceOperations : ICabanaReservationOperations, IHotelReservationOperations
    {
        public  Cabana GetCabana(string name)
        {
            Cabana cabana = null;
            using (var dbContext = new CommerceBotConext())
            {
                cabana = dbContext.Cabanas
                    .Where(t => t.CabanaName.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                    .FirstOrDefault();
            }
            return cabana;
        }

        public async Task<IList<Cabana>> GetCabanaAvailability(string reservationChoice, CabanaQuery searchQuery)
        {
            await Task.Delay(1500);
            var cabanas = new List<Cabana>();
            var random = new Random(1);

            var selectedLocationID = 0;
            using (var dbContext = new CommerceBotConext())
            {
                var query = from st in dbContext.Locations
                            where st.LocationName.Equals(reservationChoice, StringComparison.InvariantCultureIgnoreCase)
                            select st.LocationID;
                selectedLocationID = query.FirstOrDefault();

                var queryCabana = dbContext.Cabanas
                                  .Include("Location")
                                  .Where(c => c.LocationID == selectedLocationID);
                cabanas = queryCabana.ToList();
            }

            cabanas.Sort((h1, h2) => h1.PriceStarting.CompareTo(h2.PriceStarting));

            return cabanas;
        }

        public Task<IList<string>> GetExistingReservations(int userId)
        {
            var locations = new List<string>();
            using (var dbContext = new  CommerceBotConext())
            {
                var query = from st in dbContext.Locations
                            select st.LocationName;
                locations = query.ToList();
            }
            return Task.FromResult<IList<string>>(locations);
            // return Task.FromResult<IList<string>>(new[] { "Hawaii", "Los Angeles" });
        }

        public async Task<UserProfile> GetUserInformation(string name, string email)
        {
            await Task.Delay(1567);
            return new UserProfile { Id = 42, Name = name, EMail = email };
        }

        public async Task<CabanaReservation> ReserveCabana(int hotelReservationId, int cabanaId, DateTime startDate, int days)
        {
            CabanaReservation cr = new CabanaReservation()
            {
                CabanaId = cabanaId,
                ReservationId = hotelReservationId,
                StartDate = startDate,
                Days = days
            };

            // Talk to back end
            await Task.Delay(1234);

            cr.CabanaBookingId = 32768;
            return cr;
        }
    }
}