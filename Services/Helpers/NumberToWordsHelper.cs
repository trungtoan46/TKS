using System;
using System.Text;

namespace TKS.Services.Helpers
{
    public static class NumberToWordsHelper
    {
        private static readonly string[] hangDonVi = new string[] { "", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
        private static readonly string[] hangChuc = new string[] { "", "mười", "hai mươi", "ba mươi", "bốn mươi", "năm mươi", "sáu mươi", "bảy mươi", "tám mươi", "chín mươi" };
        private static readonly string[] donViTien = new string[] { "", "nghìn", "triệu", "tỷ" };

        public static string ChuyenSoThanhChu(double soTien)
        {
            if (soTien == 0) return "không";

            var chuoiSo = Math.Floor(soTien).ToString("0");
            var ketQua = new StringBuilder();
            var capSo = 0;
            var doDai = chuoiSo.Length;

            while (doDai > 0)
            {
                var nhom = doDai >= 3 ? chuoiSo.Substring(doDai - 3, 3) : chuoiSo.Substring(0, doDai);
                if (!string.IsNullOrEmpty(nhom) && nhom != "000")
                {
                    var chuSo = DocNhom(nhom);
                    if (!string.IsNullOrEmpty(chuSo))
                    {
                        if (ketQua.Length > 0) ketQua.Insert(0, " ");
                        if (capSo > 0) ketQua.Insert(0, " " + donViTien[capSo] + " ");
                        ketQua.Insert(0, chuSo);
                    }
                }

                doDai -= 3;
                capSo++;
            }

            var result = ketQua.ToString().Trim();
            return char.ToUpper(result[0]) + result.Substring(1);
        }

        private static string DocNhom(string nhom)
        {
            var ketQua = new StringBuilder();
            int hangTram = 0, hangChucSo = 0, hangDonViSo = 0;

            if (nhom.Length == 3)
            {
                hangTram = int.Parse(nhom[0].ToString());
                hangChucSo = int.Parse(nhom[1].ToString());
                hangDonViSo = int.Parse(nhom[2].ToString());
            }
            else if (nhom.Length == 2)
            {
                hangChucSo = int.Parse(nhom[0].ToString());
                hangDonViSo = int.Parse(nhom[1].ToString());
            }
            else if (nhom.Length == 1)
            {
                hangDonViSo = int.Parse(nhom[0].ToString());
            }

            if (hangTram > 0)
            {
                ketQua.Append(hangDonVi[hangTram] + " trăm");
                if (hangChucSo > 0 || hangDonViSo > 0) ketQua.Append(" ");
            }

            if (hangChucSo > 0)
            {
                if (hangChucSo == 1)
                {
                    ketQua.Append("mười");
                    if (hangDonViSo == 5) ketQua.Append(" lăm");
                    else if (hangDonViSo > 0) ketQua.Append(" " + hangDonVi[hangDonViSo]);
                }
                else
                {
                    ketQua.Append(hangChuc[hangChucSo]);
                    if (hangDonViSo == 1) ketQua.Append(" mốt");
                    else if (hangDonViSo == 5) ketQua.Append(" lăm");
                    else if (hangDonViSo > 0) ketQua.Append(" " + hangDonVi[hangDonViSo]);
                }
            }
            else if (hangDonViSo > 0)
            {
                if (hangTram > 0) ketQua.Append("lẻ ");
                ketQua.Append(hangDonVi[hangDonViSo]);
            }

            return ketQua.ToString();
        }

    }
} 