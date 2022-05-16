using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Controllers
{
    public class FriendController : Controller
    {
        //private static List<FriendModel> friends = new List<FriendModel>()
        //{
        //    new FriendModel { Id = 8, Ime = "TestIme1", MestoZiveenje = "TestMesto1"},
        //    new FriendModel { Id = 9, Ime = "TestIme2", MestoZiveenje = "TestMesto2"},
        //    new FriendModel { Id = 10, Ime = "TestIme3", MestoZiveenje = "TestMesto3"}
        //};

        public ApplicationDbContext _context;

        public FriendController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        public ActionResult Index()
        {
            //var friendsList = friends.ToList();
            var friendsList = _context.Friends.ToList();
            return View(friendsList);
        }

        [HttpGet]
        public ActionResult AddFriend()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFriend(FriendModel friend)
        {
            if (!ModelState.IsValid)
            {
                return View("AddFriend", friend);
            }
            //friends.Add(friend);
            _context.Friends.Add(friend);
            _context.SaveChanges();
            var friends = _context.Friends.ToList();
            return View("Index", friends);
        }

        [HttpGet]
        public ActionResult EditFriend(int Id)
        {
            //FriendModel friend = friends.Single(f => f.Id == Id);
            FriendModel friend = _context.Friends.Single(f => f.Id == Id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        [HttpPost]
        public ActionResult EditFriend(FriendModel friend)
        {
            if (!ModelState.IsValid)
            {
                return View("EditFriend", friend);
            }

            //var friends = _context.Friends.ToList();

            //for (int i = 0; i < friends.Count; i++)
            //{
            //    if (friend.Id == friends[i].Id)
            //    {
            //        friends[i] = friend;
            //    }
            //}

            var friendInDB = _context.Friends.Single(f => f.Id == friend.Id);
            TryUpdateModel(friendInDB);
            _context.SaveChanges();
            return View("Index", _context.Friends.ToList());
        }

        public ActionResult DeleteFriend(int Id)
        {
            //FriendModel toRemove = friends.Single(friend => friend.Id == Id);
            FriendModel toRemove = _context.Friends.ToList().Single(friend => friend.Id == Id);
            if (toRemove != null)
            {
                //friends.Remove(toRemove);
                _context.Friends.Remove(toRemove);
                _context.SaveChanges();
            }
            //return View("Index", friends);
            return View("Index", _context.Friends.ToList());
        }
    }
}