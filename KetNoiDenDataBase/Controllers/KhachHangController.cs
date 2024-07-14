using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KetNoiDenDataBase.Models;

namespace KetNoiDenDataBase.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        KhachHangEntities db = new KhachHangEntities();
        public ActionResult DanhSach()
        {
            

            return View(db.KHACHANGs);
        }

        
        public ActionResult Them()
        {
            return View(new KHACHANG());
        }
        [HttpPost]
        public ActionResult Them(KHACHANG model)
        {
            if (ModelState.IsValid)
            {
                db.KHACHANGs.Add(model);
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            return View();
        }

        public ActionResult Xoa(int id)
        {
            KHACHANG xoa = db.KHACHANGs.FirstOrDefault(m => m.ID == id);
                db.KHACHANGs.Remove(xoa);
                db.SaveChanges();
            return RedirectToAction("DanhSach");
        }

        public ActionResult Sua(int id)
        {
            KHACHANG sua = db.KHACHANGs.FirstOrDefault(m => m.ID == id);
            return View(sua);
        }
        [HttpPost]
        public ActionResult Sua(KHACHANG model)
        {
            KHACHANG kh = db.KHACHANGs.FirstOrDefault(k => k.ID == model.ID);
            if (ModelState.IsValid)
            {
                kh.TENKH = model.TENKH;
                kh.SODT = model.SODT;
                kh.DIACHI = model.DIACHI;
                kh.EMAIL = model.EMAIL;
                kh.GIOITINH = model.GIOITINH;
                kh.TENANH = model.TENANH;
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            return View();
        }
    }
}