using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WA.DatabaseLayer.Context;
using WA.DatabaseLayer.Models;
using WA.Helpers;

namespace WA.MockData
{
    public static class MockData
    {
        public static async void SeedDatabase(IApplicationBuilder app)
        {
            var context = app.ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<ApplicationContext>();

            if (!context.Accounts.Any())
            {
                var data = new List<Account>
                {
                    new Account
                    {
                        Name = "Kemal Monteno",
                        Address = "Kemicina ulica",
                        ContactInfo = new List<ContactInfo>
                        {
                            new ContactInfo
                            {
                                Information = "071 Sarajevo",
                                Type = ContactTypes.Phone
                            },
                            new ContactInfo
                            {
                                Information = "Kamal.Monteno@Montenova.com",
                                Type = ContactTypes.Email
                            }
                        }
                    },
                    new Account
                    {
                        Name = "Ivo Andric",
                        Address = "Andriceva ulica",
                        ContactInfo = new List<ContactInfo>
                        {
                            new ContactInfo
                            {
                                Information = "123 456",
                                Type = ContactTypes.Phone
                            },
                            new ContactInfo
                            {
                                Information = "Ivo.Andric@Andriceva.com",
                                Type = ContactTypes.Email
                            }
                        }
                    }
                    ,new Account
                    {
                        Name = "France Presern",
                        Address = "Prešernova cesta",
                        ContactInfo = new List<ContactInfo>
                        {
                            new ContactInfo
                            {
                                Information = "123 456",
                                Type = ContactTypes.Phone
                            },
                            new ContactInfo
                            {
                                Information = "France.Persern@Persern.com",
                                Type = ContactTypes.Email
                            }
                        }
                    },
                    new Account
                    {
                        Name = "Mak Dizdar",
                        Address = "Maka Dizdara",
                        ContactInfo = new List<ContactInfo>
                        {
                            new ContactInfo
                            {
                                Information = "653 123",
                                Type = ContactTypes.Phone
                            },
                            new ContactInfo
                            {
                                Information = "Maka.Dizdara@Dizdareva.com",
                                Type = ContactTypes.Email
                            }
                        }
                    },
                    new Account
                    {
                        Name = "Alekse Santica",
                        Address = "Santiceva"
                    },new Account()
                    {
                        Name = "Ivan Cankar",
                        Address = "Cankarjev vrh",
                        ContactInfo = new List<ContactInfo>
                        {
                            new ContactInfo
                            {
                                Type = ContactTypes.Email
                            },
                            new ContactInfo
                            {
                                Type = ContactTypes.Phone
                            }
                        }
                    }
                };

                await context.AddRangeAsync(data);

                await context.SaveChangesAsync();
            }
        }
    }
}
