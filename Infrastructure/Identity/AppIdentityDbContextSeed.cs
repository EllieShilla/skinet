using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Bob",
                    Email = "bob@test.com",
                    UserName = "bob@test.com",
                    Address = new Address
                    {
                        FirstName = "Bob",
                        LastName = "Bobbity",
                        Street = "10 The Street",
                        City = "Kyiv",
                        District = "Kyiv region",
                        ZipCode = "01033"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}

// eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImJvYkB0ZXN0LmNvbSIsImdpdmVuX25hbWUiOiJCb2IiLCJuYmYiOjE2NzI5MjE0OTgsImV4cCI6MTY3MzUyNjI5OCwiaWF0IjoxNjcyOTIxNDk4LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MTc4In0.FMt_UlvSF1mTR9CcY8NNq05SMA_70Ht7SEjm1C1C5gyMMMFu3odpGpo8ODCx5mYH4jNSG-c9ozSl-8AT7vrKJQ