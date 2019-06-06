using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace FarmHub.Common
{
    public static class ErrorList
    {
        //Login
        public static string LOGIN_WRONGPASS = "Tài Khoản hoặc mật khẩu không chính xác";
        public static string LOGIN_LOCKED = "Tài Khoản đã bị khóa";
        //Register
        public static string REGISTER_ERROR = "Đăng kí tài khoản không thành công";
        //Profile
        public static string UPDATE_ERROR = "Cập nhật thông tin không thành công";
        public static string DELETE_ERROR = "Xóa không thông tin không thành công";
        //Edit Password
        public static string EDITPASSWORD_ERROR = "Cập nhật mật khẩu không thành công";
        public static string WRONGPASSWORD_ERROR = "Mật khẩu cũ không chính xác";
        public static string PASSWORDCONFIRM_ERROR = "Mật khẩu cũ và mật khẩu xác nhận không khớp";

    }
}