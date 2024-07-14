using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormNhapLieu.Models;

namespace FormNhapLieu.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult DanhSach()
        {
            return View(DanhSachKhachHang.dsKhachHang);
        }

        public ActionResult ThemMoi()
        {
            return View(new KhachHang() { Id = 0 });
        }
        [HttpPost]
        public ActionResult ThemMoi(KhachHang model, FormCollection c, HttpPostedFileBase fname)
        {

            if (ModelState.IsValid)
            {

                model.GioiTinh = getGioiTinh(c);

                saveFileImage(fname);
                model.TenAnh = "/Content/Images/" + fname.FileName;

                DanhSachKhachHang.dsKhachHang.Add(model);
                return RedirectToAction("DanhSach");


            }

            return View();
        }

        public string getGioiTinh(FormCollection c)
        {
            string gt = "";
            if (c["m"] != null)
                gt += c["m"] + " ";
            if (c["wm"] != null)
                gt += c["wm"] + " ";
            if (c["k"] != null)
                gt += c["k"] + " ";
            return gt;
        }

        public void saveFileImage(HttpPostedFileBase fname)
        {
            string rootfolder = Server.MapPath("/Content/Images/");
            string path = rootfolder + fname.FileName;
            fname.SaveAs(path);
        }
        //Cập nhật thông tin
        public ActionResult CapNhat(int id)
        {
            var khachHang = DanhSachKhachHang.dsKhachHang.FirstOrDefault(t => t.Id == id);
            //Truyền thông tin đối tượng cần sửa sang bên View
            return View(khachHang);
        }

        [HttpPost]
        public ActionResult CapNhat(KhachHang model)
        {
            var kh = DanhSachKhachHang.dsKhachHang.FirstOrDefault(t => t.Id == model.Id);

            kh.Id = model.Id;
            kh.TenKH = model.TenKH;
            kh.Email = model.Email;
            kh.SoDT = model.SoDT;
            kh.DiaChiKH = model.DiaChiKH;
            kh.GioiTinh = model.GioiTinh;
            kh.TenAnh = model.TenAnh;
            return RedirectToAction("danhsach");
        }

        public ActionResult Xoa(int idkh)
        {
            var kh = DanhSachKhachHang.dsKhachHang.FirstOrDefault(t => t.Id == idkh);
            DanhSachKhachHang.dsKhachHang.Remove(kh);
            return RedirectToAction("danhsach");
        }
    }
}