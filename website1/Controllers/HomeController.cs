using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website1.Models;


namespace website1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        


        public ActionResult Index()
        {
            //DanhSachNV.danhSachNhanVien = DanhSachNV.them5NV();
            return View(DanhSachNV.danhSachNhanVien);
        }

        public ActionResult sapXepTheoDiem()
        {
            DanhSachNV.danhSachNhanVien = DanhSachNV.danhSachNhanVien.OrderBy(t => t.DiemThi).ToList();
            return RedirectToAction("index");
        }

        public ActionResult congDiemChoNhanVien()
        {
            DanhSachNV.danhSachNhanVien.ForEach(t => t.DiemThi += 0.5);
            return RedirectToAction("index") ;
        }
        //-------------------------------------------------------------------------------------------
        //tạo form nhập liệu tự động và lưu thông tin 
        public ActionResult them1NVMoi()
        {
            return View(new NhanVien());
        }
        [HttpPost]
        public ActionResult them1NVMoi(NhanVien model)
        {
            DanhSachNV.danhSachNhanVien.Add(new NhanVien(model.MaNV, model.TenNV, model.NgaySinh, model.DiemThi));
            return RedirectToAction("index");
        }

        //-------------------------------------------------------------------------------------------

        public ActionResult xuatNVCoDiemCaoNhat()
        {
            NhanVien nv = DanhSachNV.danhSachNhanVien.FirstOrDefault(t => t.DiemThi == DanhSachNV.danhSachNhanVien.Max(a => a.DiemThi));
            return View(nv);
        }




        //-------------------------------------------------------------------------------------------
        //tạo form nhập liệu và lưu thông tin bằng tay
        public ActionResult them()
        {
            return View(new NhanVien());
        }

        [HttpPost]
        public ActionResult LuuThemMoi(NhanVien nv)
        {
            //xử lý lưu
            DanhSachNV.danhSachNhanVien.Add(new NhanVien(nv.MaNV,nv.TenNV,nv.NgaySinh,nv.DiemThi));
            return RedirectToAction("index");
        }

        //-------------------------------------------------------------------------------------------
    }
}