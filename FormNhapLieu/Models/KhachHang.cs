using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormNhapLieu.Models
{
    public class KhachHang
    {
        public KhachHang(int id, string tenKH, string soDT, string diaChiKH, string email, string gioiTinh, string tenAnh)
        {
            Id = id;
            TenKH = tenKH;
            SoDT = soDT;
            DiaChiKH = diaChiKH;
            Email = email;
            GioiTinh = gioiTinh;
            TenAnh = tenAnh;
        }
        public KhachHang() { }
        public int Id { get; set; }
        public string TenKH { get; set; }
        public string SoDT { get; set; }
        public string DiaChiKH { get; set; }
        public string Email { get; set; }
        public string GioiTinh { get; set; }
        public string TenAnh { get; set; }
    }
}