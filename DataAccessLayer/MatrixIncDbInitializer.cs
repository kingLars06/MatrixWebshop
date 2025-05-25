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

            var products = new Product[]
            {
                new Product {Name = "Nebuchadnezzar", Description = "Het schip waarop Neo voor het eerst de echte wereld leert kennen", Price = 10000.00m },
                new Product {Name = "Jack-in Chair", Description = "Stoel met een rugsteun en metalen armen waarin mensen zitten om ingeplugd te worden in de Matrix via een kabel in de nekpoort", Price = 500.50m },
                new Product {Name = "EMP (Electro-Magnetic Pulse) Device", Description = "Wapentuig op de schepen van Zion", Price = 129.99m },
                new Product {Name = "Hovercraft Pilot Helmet", Description = "Helm gedragen door piloten van Zion-schepen tijdens missies", Price = 349.99m },
                new Product {Name = "Oracle's Cookie Jar", Description = "Koektrommel waaruit Neo een koekje krijgt van de Oracle", Price = 24.95m },
                new Product {Name = "Agent Smith Earpiece", Description = "Communicatieapparaat gedragen door de kwaadaardige agenten", Price = 129.00m },
                new Product {Name = "Matrix Reloaded Jacket", Description = "Leren jas gedragen door Neo in het tweede deel van de trilogie", Price = 299.99m },
                new Product {Name = "Dojo Training Program", Description = "Virtuele trainingsomgeving waarin Morpheus Neo traint", Price = 599.00m },
                new Product {Name = "Red Pill", Description = "De pil die Neo kiest om de waarheid te ontdekken", Price = 49.99m },
                new Product {Name = "Blue Pill", Description = "De pil waarmee je terugkeert naar je oude leven in de Matrix", Price = 49.99m },
                new Product {Name = "Zion Access Key", Description = "Digitale sleutel om toegang te krijgen tot de ondergrondse stad Zion", Price = 999.00m },
                new Product {Name = "Sentinel Drone", Description = "Mechanische octopus die de mens opspoort en elimineert", Price = 1999.95m },
                new Product {Name = "Matrix Code Rain Display", Description = "Een holografisch scherm dat de vallende groene Matrix-code laat zien", Price = 299.99m },
                new Product {Name = "Neo's Sunglasses", Description = "Iconische zonnebril zonder poten, gedragen door The One", Price = 199.00m },
                new Product {Name = "Trinity's Motorcycle", Description = "Krachtige motorfiets gebruikt in Matrix achtervolgingsscènes", Price = 8499.50m },
                new Product {Name = "Operator Console", Description = "Werkstation voor crewleden zoals Tank om gebruikers te begeleiden", Price = 1200.00m },
                new Product {Name = "Construct Program Chip", Description = "Virtuele omgeving voor training en wapenselectie", Price = 750.00m },
                new Product {Name = "Architect's Chair", Description = "Stoel van waaruit de Architect het lot van de Matrix overziet", Price = 888.88m },
                new Product {Name = "Merovingian's Keymaker", Description = "Sleutelmaker die toegang geeft tot verborgen delen van de Matrix", Price = 450.00m },



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
