using CommerceBot.Model;

namespace CommerceBot.Repository.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    
    internal sealed class Configuration : DbMigrationsConfiguration<CommerceBotConext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CommerceBotConext context)
        {
            IList<Location> locations = new List<Location>();

            locations.Add(new Location() { LocationID=1, LocationName= "New Jersey" });
            locations.Add(new Location() { LocationID = 2, LocationName = "New York" });
            locations.Add(new Location() { LocationID = 3, LocationName = "Hawaii" });
            
            context.Locations.AddOrUpdate(locations.ToArray());

            IList<Cabana> cabanas = new List<Cabana>();

            cabanas.Add(new Cabana { 
                 CabanaID=1,
                 CabanaName= "The Langham",
                 LocationID=1,
                 PriceStarting=50,
                 Rating=4,
                 NumberOfReviews=100,
                 Image = $"https://placeholdit.imgix.net/~text?txtsize=35&txt=Cabana+The+Langham&w=500&h=260"
            });
            cabanas.Add(new Cabana
            {
                CabanaID = 2,
                CabanaName = "Hale Napili",
                LocationID = 1,
                PriceStarting = 150,
                Rating = 4,
                NumberOfReviews = 120,
                Image = $"https://placeholdit.imgix.net/~text?txtsize=35&txt=Cabana+The+Langham&w=500&h=260"
            });
            cabanas.Add(new Cabana
            {
                CabanaID = 3,
                CabanaName = "Acqualina Resort & Spa on the Beach",
                LocationID = 2,
                PriceStarting = 80,
                Rating = 5,
                NumberOfReviews = 245,
                Image = $"https://placeholdit.imgix.net/~text?txtsize=35&txt=Cabana+The+Langham&w=500&h=260"
            });
            cabanas.Add(new Cabana
            {
                CabanaID = 4,
                CabanaName = "Trump International Beach Resort Miami",
                LocationID = 3,
                PriceStarting = 100,
                Rating = 5,
                NumberOfReviews = 300,
                Image = $"https://placeholdit.imgix.net/~text?txtsize=35&txt=Cabana+The+Langham&w=500&h=260"
            });
            cabanas.Add(new Cabana
            {
                CabanaID = 5,
                CabanaName = "Montage Kapalua Bay",
                LocationID = 3,
                PriceStarting = 400,
                Rating = 5,
                NumberOfReviews = 1200,
                Image = $"https://placeholdit.imgix.net/~text?txtsize=35&txt=Cabana+The+Langham&w=500&h=260"
            });
            context.Cabanas.AddOrUpdate(cabanas.ToArray());
            base.Seed(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
