using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormNhapLieu.Models
{
    public class KhachHang
    {
        private int id;
        string tenKH;
        string soDT;
        string diaChiKH;
        string email;
        string gioiTinh;

        public KhachHang(int id, string tenKH, string soDT, string diaChiKH, string email, string gioiTinh)
        {
            Id = id;
            TenKH = tenKH;
            SoDT = soDT;
            DiaChiKH = diaChiKH;
            Email = email;
            GioiTinh = gioiTinh;
        }

        public KhachHang() { }

        public int Id { get => id; set => id = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public string DiaChiKH { get => diaChiKH; set => diaChiKH = value; }
        public string Email { get => email; set => email = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }

    }
}