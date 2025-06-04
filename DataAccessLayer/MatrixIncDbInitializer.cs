using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class MatrixIncDbInitializer
    {
        public static void Initialize(MatrixIncDbContext context)
        {
            // Look for any customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            // TODO: Hier moet ik nog wat namen verzinnen die betrekking hebben op de matrix.
            // - Denk aan de m3 boutjes, moertjes en ringetjes.
            // - Denk aan namen van schepen
            // - Denk aan namen van vliegtuigen            
            var customers = new Customer[]
            {
                new Customer { Name = "Neo", Address = "123 Elm St" , Active=true},
                new Customer { Name = "Morpheus", Address = "456 Oak St", Active = true },
                new Customer { Name = "Trinity", Address = "789 Pine St", Active = true },
                new Customer { Name = "Agent Smith", Address = "101 Maple St", Active = true },
                new Customer { Name = "Oracle", Address = "202 Cedar St", Active = true },
                new Customer { Name = "Cypher", Address = "303 Birch St", Active = true },
                new Customer { Name = "Tank", Address = "404 Spruce St", Active = true },
            };
            context.Customers.AddRange(customers);

            var orders = new Order[]
            {
                new Order { Customer = customers[0], OrderDate = DateTime.Parse("2021-01-01")},
                new Order { Customer = customers[0], OrderDate = DateTime.Parse("2021-02-01")},
                new Order { Customer = customers[1], OrderDate = DateTime.Parse("2021-02-01")},
                new Order { Customer = customers[2], OrderDate = DateTime.Parse("2021-03-01")}
            };  
            context.Orders.AddRange(orders);

            //var products = new Product[]
            //{
            //    new Product {Name = "Nebuchadnezzar", Description = "Het schip waarop Neo voor het eerst de echte wereld leert kennen", Price = 10000.00m },
            //    new Product {Name = "Jack-in Chair", Description = "Stoel met een rugsteun en metalen armen waarin mensen zitten om ingeplugd te worden in de Matrix via een kabel in de nekpoort", Price = 500.50m },
            //    new Product {Name = "EMP (Electro-Magnetic Pulse) Device", Description = "Wapentuig op de schepen van Zion", Price = 129.99m },
            //    new Product {Name = "Hovercraft Pilot Helmet", Description = "Helm gedragen door piloten van Zion-schepen tijdens missies", Price = 349.99m },
            //    new Product {Name = "Oracle's Cookie Jar", Description = "Koektrommel waaruit Neo een koekje krijgt van de Oracle", Price = 24.95m },
            //    new Product {Name = "Agent Smith Earpiece", Description = "Communicatieapparaat gedragen door de kwaadaardige agenten", Price = 129.00m },
            //    new Product {Name = "Matrix Reloaded Jacket", Description = "Leren jas gedragen door Neo in het tweede deel van de trilogie", Price = 299.99m },
            //    new Product {Name = "Dojo Training Program", Description = "Virtuele trainingsomgeving waarin Morpheus Neo traint", Price = 599.00m },
            //    new Product {Name = "Red Pill", Description = "De pil die Neo kiest om de waarheid te ontdekken", Price = 49.99m },
            //    new Product {Name = "Blue Pill", Description = "De pil waarmee je terugkeert naar je oude leven in de Matrix", Price = 49.99m },
            //    new Product {Name = "Zion Access Key", Description = "Digitale sleutel om toegang te krijgen tot de ondergrondse stad Zion", Price = 999.00m },
            //    new Product {Name = "Sentinel Drone", Description = "Mechanische octopus die de mens opspoort en elimineert", Price = 1999.95m },
            //    new Product {Name = "Matrix Code Rain Display", Description = "Een holografisch scherm dat de vallende groene Matrix-code laat zien", Price = 299.99m },
            //    new Product {Name = "Neo's Sunglasses", Description = "Iconische zonnebril zonder poten, gedragen door The One", Price = 199.00m },
            //    new Product {Name = "Trinity's Motorcycle", Description = "Krachtige motorfiets gebruikt in Matrix achtervolgingsscènes", Price = 8499.50m },
            //    new Product {Name = "Operator Console", Description = "Werkstation voor crewleden zoals Tank om gebruikers te begeleiden", Price = 1200.00m },
            //    new Product {Name = "Construct Program Chip", Description = "Virtuele omgeving voor training en wapenselectie", Price = 750.00m },
            //    new Product {Name = "Architect's Chair", Description = "Stoel van waaruit de Architect het lot van de Matrix overziet", Price = 888.88m },
            //    new Product {Name = "Merovingian's Keymaker", Description = "Sleutelmaker die toegang geeft tot verborgen delen van de Matrix", Price = 450.00m },
            //};
            var products = new Product[]
                {
                    new Product {Name = "Nebuchadnezzar", Description = "Het schip waarop Neo voor het eerst de echte wereld leert kennen", Price = 10000.00m, ImageURL = "https://auctions.potterauctions.com/ItemImages/000055/117_048_1_med.jpeg" },
                    new Product {Name = "Jack-in Chair", Description = "Stoel met een rugsteun en metalen armen waarin mensen zitten om ingeplugd te worden in de Matrix via een kabel in de nekpoort", Price = 500.50m, ImageURL = "https://d2t1xqejof9utc.cloudfront.net/screenshots/pics/2d5b01cc30cc15b24e134c1a519924e4/large.png" },
                    new Product {Name = "EMP (Electro-Magnetic Pulse) Device", Description = "Wapentuig op de schepen van Zion", Price = 129.99m, ImageURL = "https://codegreenprep.com/wp-content/uploads/2016/06/emp2b.jpg" },
                    new Product {Name = "Hovercraft Pilot Helmet", Description = "Helm gedragen door piloten van Zion-schepen tijdens missies", Price = 349.99m, ImageURL = "https://www.telegraph.co.uk/multimedia/archive/02442/F35-helmet_2442961a.jpg" },
                    new Product {Name = "Agent Smith Earpiece", Description = "Communicatieapparaat gedragen door de kwaadaardige agenten", Price = 129.00m, ImageURL = "https://media.tenor.com/qJxax76J-AMAAAAe/matrix-agent-smith.png" },
                    new Product {Name = "Matrix Reloaded Jacket", Description = "Leren jas gedragen door Neo in het tweede deel van de trilogie", Price = 299.99m, ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQTcdfmYnNIOYkY_vzW-umPDhZ8YuQJRo2a4w&s" },
                    new Product {Name = "Dojo Training Program", Description = "Virtuele trainingsomgeving waarin Morpheus Neo traint", Price = 599.00m, ImageURL = "https://i.pinimg.com/736x/35/bc/d9/35bcd98104516822b32c0fe20588f3b8.jpg" },
                    new Product {Name = "Red Pill", Description = "De pil die Neo kiest om de waarheid te ontdekken", Price = 49.99m, ImageURL = "https://sm.ign.com/t/ign_gr/photo/default/red-pill-1631115199789_6xpr.1080.jpg" },
                    new Product {Name = "Blue Pill", Description = "De pil waarmee je terugkeert naar je oude leven in de Matrix", Price = 49.99m, ImageURL = "https://static.vecteezy.com/system/resources/previews/037/481/341/non_2x/ai-generated-blue-capsule-pill-isolated-on-transparent-background-generative-ai-png.png" },
                    new Product {Name = "Zion Access Key", Description = "Digitale sleutel om toegang te krijgen tot de ondergrondse stad Zion", Price = 999.00m, ImageURL = "https://upload.wikimedia.org/wikipedia/commons/9/9b/The.Matrix.glmatrix.2.png" },
                    new Product {Name = "Sentinel Drone", Description = "Mechanische octopus die de mens opspoort en elimineert", Price = 1999.95m, ImageURL = "https://media.licdn.com/dms/image/v2/C5612AQEbH7omi3Zb3g/article-cover_image-shrink_720_1280/article-cover_image-shrink_720_1280/0/1520225186984?e=2147483647&v=beta&t=ZB_TlKUeHM0EIpeMev9E2vOhZn3q1xCYfmeNI5ciRzo" },
                    new Product {Name = "Matrix Code Rain Display", Description = "Een holografisch scherm dat de vallende groene Matrix-code laat zien", Price = 299.99m, ImageURL = "https://www.indiewire.com/wp-content/uploads/2017/10/matrix-code.jpg?w=600&h=337&crop=1" },
                    new Product {Name = "Neo's Sunglasses", Description = "Iconische zonnebril zonder poten, gedragen door The One", Price = 199.00m, ImageURL = "https://i.ebayimg.com/images/g/fq0AAOSwCmFbOzH3/s-l1200.jpg" },
                    new Product {Name = "Trinity's Motorcycle", Description = "Krachtige motorfiets gebruikt in Matrix achtervolgingsscènes", Price = 8499.50m, ImageURL = "https://www.slashgear.com/img/gallery/what-motorcycle-did-carrie-anne-moss-ride-in-the-matrix-reloaded/intro-1736886857.jpg" },
                    //new Product {Name = "Operator Console", Description = "Werkstation voor crewleden zoals Tank om gebruikers te begeleiden", Price = 1200.00m, ImageURL = "https://static.wikia.nocookie.net/matrix/images/3/3a/Operator_console.jpg" },
                    //new Product {Name = "Construct Program Chip", Description = "Virtuele omgeving voor training en wapenselectie", Price = 750.00m, ImageURL = "https://static.wikia.nocookie.net/matrix/images/7/7e/Construct_program_chip.jpg" },
                    //new Product {Name = "Architect's Chair", Description = "Stoel van waaruit de Architect het lot van de Matrix overziet", Price = 888.88m, ImageURL = "https://static.wikia.nocookie.net/matrix/images/4/4d/Architect_chair.jpg" },
                    //new Product {Name = "Merovingian's Keymaker", Description = "Sleutelmaker die toegang geeft tot verborgen delen van de Matrix", Price = 450.00m, ImageURL = "https://static.wikia.nocookie.net/matrix/images/8/8f/Keymaker.jpg" },
                };
            context.Products.AddRange(products);

            var parts = new Part[]
            {
                new Part { Name = "Tandwiel", Description = "Overdracht van rotatie in bijvoorbeeld de motor of luikmechanismen"},
                new Part { Name = "M5 Boutje", Description = "Bevestiging van panelen, buizen of interne modules"},
                new Part { Name = "Hydraulische cilinder", Description = "Openen/sluiten van zware luchtsluizen of bewegende onderdelen"},
                new Part { Name = "Koelvloeistofpomp", Description = "Koeling van de motor of elektronische systemen."}
            };
            context.Parts.AddRange(parts);

            context.SaveChanges();

            context.Database.EnsureCreated();
        }
    }
}
