using Microsoft.EntityFrameworkCore;
using RestApiHomework.Asp.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiHomework.Asp.Net.data
{
    public class MainContext : DbContext
    {

        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
            if(!Dishes.Any())
            {
                Dishes.Add(new Dish()
                {
                    Name = "Plate"
                });
                Dishes.Add(new Dish()
                {
                    Name = "Fork"
                });
                Dishes.Add(new Dish()
                {
                    Name = "Knife"
                });
                SaveChanges();
            }

            if (!Fruits.Any())
            {
                Fruits.Add(new Fruit()
                {
                    Name = "Apple"
                });
                Fruits.Add(new Fruit()
                {
                    Name = "Orange"
                });
                Fruits.Add(new Fruit()
                {
                    Name = "Kiwi"
                });
                SaveChanges();
            }

            if (!Vegetables.Any())
            {
                Vegetables.Add(new Vegetable()
                {
                    Name = "Cucumber"
                });
                Vegetables.Add(new Vegetable()
                {
                    Name = "Tomato"
                });
                Vegetables.Add(new Vegetable()
                {
                    Name = "Carrot"
                });
                SaveChanges();
            }
        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Vegetable> Vegetables { get; set; }
    }
}
