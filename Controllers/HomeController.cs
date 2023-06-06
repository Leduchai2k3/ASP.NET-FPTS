using System.Data.Entity;
using System.Diagnostics;
using App.Models;
using App.Models.DatLenhs;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using DatLenhModel = App.Models.DatLenhs.DatLenh;
namespace MVC.Controllers;

public class HomeController : Controller
{
    public class HomeViewModel
    {
        public List<DatLenh> DatLenhList { get; set; }
        public DatLenh NewDatLenh { get; set; }
    }

    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }
    public string Thongbao { set; get; }
    public int Id { get; private set; }

    public IActionResult Index()
    {
        List<DatLenhModel> datLenhs = _context.Homes.ToList();
        Console.WriteLine(datLenhs);
        return View(datLenhs); // Truyền List datLenhs vào View
    }


    [HttpPost]
    public IActionResult Delete(int id)
    {
        var datLenh = _context.Homes.Find(id);
        if (datLenh != null)
        {
            _context.Homes.Remove(datLenh);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }



    [HttpPost]
    public IActionResult Index(DatLenhModel datLenh)
    {
        if (ModelState.IsValid)
        {
            _context.Homes.Add(datLenh);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            List<DatLenhModel> datLenhs = _context.Homes.ToList();
            ViewData["DatLenhs"] = datLenhs;
            return View(datLenh);
        }
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var datLenh = _context.Homes.Find(id);
        if (datLenh != null)
        {
            return View(datLenh);
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Edit(DatLenhModel updatedDatLenh)
    {
        var datLenh = _context.Homes.Find(updatedDatLenh.Id);
        if (datLenh != null)
        {
            // Cập nhật các trường dữ liệu của datLenh với dữ liệu từ updatedDatLenh
            datLenh.MaCK = updatedDatLenh.MaCK;
            datLenh.KhoiLuong = updatedDatLenh.KhoiLuong;
            datLenh.Gia = updatedDatLenh.Gia;

            if (ModelState.IsValid)
            {
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(datLenh);
            }
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    public IActionResult Auto()
    {
        return View();
    }
}
