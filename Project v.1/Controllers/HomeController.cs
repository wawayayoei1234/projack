using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Project_v._1.Models;

namespace Project_v._1.Controllers
{
    public class HomeController : Controller
    {
        private IMongoCollection<register_user> hubCollection;
        private IMongoCollection<job> collectionjob;
        public HomeController()
        {
            var dbcilent = new MongoClient("mongodb://Beeradmin:beer8640@cluster0-shard-00-00-pqdfa.azure.mongodb.net:27017,cluster0-shard-00-01-pqdfa.azure.mongodb.net:27017,cluster0-shard-00-02-pqdfa.azure.mongodb.net:27017/test?replicaSet=Cluster0-shard-0&ssl=true&authSource=admin");
            var database = dbcilent.GetDatabase("hub");
            hubCollection = database.GetCollection<register_user>("register_user");
            collectionjob = database.GetCollection<job>("job");
        }

        public IActionResult Index()
        {
            var result = collectionjob.Find(it => true).ToList();

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(register_user data)
        {
            var item = new register_user
            {
                _id = Guid.NewGuid().ToString(),
                username = data.username,
                password = data.password,
                name_lastname = data.name_lastname,
                pictrue_profile = data.pictrue_profile,
                pictrue = data.pictrue
            };
            hubCollection.InsertOne(item);

            return RedirectToAction("Index");
        }

        public IActionResult Details(string id)
        {
            var select = collectionjob.Find(it => it._id == id).ToList().FirstOrDefault();

            return View(select);
        }

        public IActionResult Edit(string id)
        {
            var select = collectionjob.Find(it => it._id == id).ToList().FirstOrDefault();
            return View(select);
        }

        [HttpPost]
        public IActionResult Edit(job data)
        {

            var def = Builders<job>.Update
                        .Set(it => it.pictruejob, data.pictruejob)
                        .Set(it => it.namejob, data.namejob)
                        .Set(it => it.detail, data.detail)
                        .Set(it => it.phone, data.phone)
                        .Set(it => it.location, data.location)
                        .Set(it => it.price, data.price);

            collectionjob.UpdateOne(it => it._id == data._id, def);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string id)
        {
            var select = collectionjob.Find(it => it._id == id).ToList().FirstOrDefault();

            return View(select);
        }

        [HttpDelete]
        public IActionResult Delete(register_user data, string id)
        {
            collectionjob.DeleteOne(it => it._id == id);

            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(login dataLogin)
        {
            var item = hubCollection.Find(it => it.username == dataLogin.idname && it.password == dataLogin.pword).FirstOrDefault();
            if (item != null)
            {

                return RedirectToAction("Details", new { id = item._id });
            }
            else
            {
                return View();
            }
        }

        public IActionResult Logout()
        {

            return View();
        }

        public IActionResult register_job()
        {

            return View();
        }

        [HttpPost]
        public IActionResult register_job(job data)
        {
            var item = new job
            {
                _id = Guid.NewGuid().ToString(),
                pictruejob = data.pictruejob,
                namejob = data.namejob,
                detail = data.detail,
                phone = data.phone,
                location = data.location,
                price = data.price
            };
            collectionjob.InsertOne(item);

            return RedirectToAction("Index");
        }
    }
}
