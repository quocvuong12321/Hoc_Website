using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH_ThemXoaSua.Models;
namespace TH_ThemXoaSua.Controllers
{
    public class BaiVietController : Controller
    {
        // GET: BaiViet
        QuanLyBaiVietEntities db = new QuanLyBaiVietEntities();
        public ActionResult DanhSach()
        {
            
            return View(db.BaiViets.ToList());
        }

        public ActionResult ThemMoi()
        {

            return View(new BaiViet());
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(BaiViet model, HttpPostedFileBase fname)
        {
            if (string.IsNullOrEmpty(model.TENBAIVIET))
            {
                ModelState.AddModelError("", "Thiếu tên bài viết");
                return View(model);
            }

            string rootFolder = Server.MapPath("/img/");
            string path = rootFolder + fname.FileName;
            fname.SaveAs(path);
            model.HINHANH = fname.FileName;
            db.BaiViets.Add(model);
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }

        //Các bước nhúng ckEditor
        //1. Tải bộ plugin vào project (dùng install-package CkEditor
        //2. Kéo thả file JS vào layout
        //3. Thay đổi input nội dung thành textarea, có đặt id cho input
        //4. Viết lệnh js cho textarea
        //5. Lưu dữ liệu: - thêm kiểm tra html  cho action lưu dữ liệu


        public ActionResult ChinhSua(int id)
        {
            return View(db.BaiViets.FirstOrDefault(t => t.ID == id));
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(BaiViet model)
        {
            BaiViet bv = db.BaiViets.FirstOrDefault(t => t.ID == model.ID);
            if (string.IsNullOrEmpty(model.TENBAIVIET))
            {
                ModelState.AddModelError("", "Thiếu tên bài viết");
                return View(model);
            }

            bv.NOIDUNG = model.NOIDUNG;
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }


        public ActionResult Xoa(int id)
        {
            db.BaiViets.Remove(db.BaiViets.Find(id));
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }

        public ActionResult ChiTiet(int id)
        {
            return View(db.BaiViets.Find(id));
        }
    }
}