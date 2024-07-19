using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH_ThemXoaSua.Models;
namespace TH_ThemXoaSua.Controllers
{
    public class LoaiBaiVietController : Controller
    {
        // GET: LoaiBaiViet
        QuanLyBaiVietEntities db = new QuanLyBaiVietEntities();
        public ActionResult DanhSach()
        {
            List<LoaiBaiViet> lstLBV = db.LoaiBaiViets.ToList();
            return View(lstLBV);
        }


        public ActionResult ThemMoi() {
            return View();
        } 

        [HttpPost]
        public ActionResult ThemMoi(LoaiBaiViet model)
        {
            if (string.IsNullOrEmpty(model.TENLOAI))
            {
                ModelState.AddModelError("", "Thiếu thông tin tên loại");
                return View(model);
            }
            try {
                db.LoaiBaiViets.Add(model);
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        public ActionResult CapNhat(int id)
        {
            LoaiBaiViet lbv = db.LoaiBaiViets.Find(id);
            return View(lbv);
        }

        [HttpPost]
        public ActionResult CapNhat(LoaiBaiViet model)
        {
            LoaiBaiViet lbv = db.LoaiBaiViets.FirstOrDefault(t=>t.ID==model.ID);
            if (string.IsNullOrEmpty(model.TENLOAI))
            {
                ModelState.AddModelError("", "Thiếu thông tin tên loại");
                return View(model);
            }
            try
            {
                lbv.TENLOAI = model.TENLOAI;
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
        public ActionResult Xoa(int id)
        {
            db.LoaiBaiViets.Remove(db.LoaiBaiViets.FirstOrDefault(t=>t.ID==id));
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }
    }
}