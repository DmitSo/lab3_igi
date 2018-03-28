using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab1_ef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab2_igi.Controllers
{
    public class MainController : Controller
    {
        static List<Room> rooms = new List<Room>()
        {
            new Room(){ RoomId = 1, RoomNo = "1", Capacity = 2, Cost = 200, CostDate = new DateTime(2015,9,1)},
            new Room(){ RoomId = 2, RoomNo = "2", Capacity = 2, Cost = 200, CostDate = new DateTime(2015,9,2)},
            new Room(){ RoomId = 3, RoomNo = "3", Capacity = 3, Cost = 300, CostDate = new DateTime(2015,9,3)},
            new Room(){ RoomId = 4, RoomNo = "4", Capacity = 3, Cost = 300, CostDate = new DateTime(2015,9,4)},
            new Room(){ RoomId = 5, RoomNo = "5", Capacity = 4, Cost = 400, CostDate = new DateTime(2015,9,5)},
        };

        static List<ServiceType> serviceTypes = new List<ServiceType>()
        {
            new ServiceType() { ServiceTypeId = 1, Name = "Уборка", Cost = 100},
            new ServiceType() { ServiceTypeId = 2,Name = "Обед в номер", Cost = 150},
            new ServiceType() { ServiceTypeId = 3,Name = "Пополнение бара", Cost = 120},
            new ServiceType() { ServiceTypeId = 4,Name = "Элитное пополнение бара", Cost = 510}
        };

        static List<Employee> employees = new List<Employee>()
        {
            new Employee() { EmployeeId = 1, Name = "Ахмед"},
            new Employee() { EmployeeId = 2, Name = "Амир"},
            new Employee() { EmployeeId = 3, Name = "Алексей"},
            new Employee() { EmployeeId = 4, Name = "Виктория"},
            new Employee() { EmployeeId = 5, Name = "Зульфия"},
            new Employee() { EmployeeId = 6, Name = "Алла"}
        };

        [Route("gr")]
        public ActionResult GetRooms()
        {
            return View(rooms);
        }

        [Route("gst")]
        public ActionResult GetServiceTypes()
        {
            return View(serviceTypes);
        }

        [Route("gemp")]
        public ActionResult GetEmployees()
        {
            return View(employees);
        }

        [HttpGet]
        public ActionResult AddRoom()
        {
            var room = new Room();
            return View(room);
        }

        [HttpPost]
        public ActionResult AddRoom(Room room)
        {
            room.CostDate = DateTime.Now;
            room.RoomId = rooms.Last().RoomId + 1;//
            rooms.Add(room);
            return Redirect("~/Home/Index");
        }
    }
}