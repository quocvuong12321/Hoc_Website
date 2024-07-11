using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website1.Models
{
    public static class DanhSachNV
    {
        static List<NhanVien>  dsNV = new List<NhanVien>();
        public static List<NhanVien> danhSachNhanVien { get => dsNV; set => dsNV = value; }

        public static List<NhanVien> them5NV()
        {
            List<NhanVien> danhSachNhanVien = new List<NhanVien>();

            danhSachNhanVien.Add(new NhanVien("NV01", "Nguyen Van A", new DateTime(2004, 1, 1), 8.5));
            danhSachNhanVien.Add(new NhanVien("NV02", "Le Thi B", new DateTime(2005, 2, 2), 9.0));
            danhSachNhanVien.Add(new NhanVien("NV03", "Tran Van C", new DateTime(2006, 3, 3), 8.8));
            danhSachNhanVien.Add(new NhanVien("NV04", "Pham Thi D", new DateTime(2004, 4, 4), 9.2));
            danhSachNhanVien.Add(new NhanVien("NV05", "Hoang Van E", new DateTime(2005, 5, 5), 8.7));

            return danhSachNhanVien;
        }
    }
}