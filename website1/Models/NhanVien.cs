using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website1.Models
{
    public class NhanVien
    {
        private string maNV;
        private string tenNV;
        private DateTime ngaySinh;
        private double diemThi;
        public string MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public double DiemThi { get => diemThi; set => diemThi = value; }

        public NhanVien()
        {
        }
        public NhanVien(string manv,string tennv,DateTime ngsinh, double dt)
        {
            MaNV = manv;
            TenNV = tennv;
            NgaySinh = ngsinh;
            DiemThi = dt;
        }

        

    }
}