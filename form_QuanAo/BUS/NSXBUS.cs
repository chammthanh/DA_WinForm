using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;
namespace BUS
{
    public class NSXBUS
    {
        public static DataTable LayDSNSX()
        {
            return NSXDAO.LayDSNSX();
        }
        public static bool ThemNSX(NSXDTO nsx)
        {
            return NSXDAO.ThemNSX(nsx);
        }
        public static bool SuaNSX(NSXDTO nsx)
        {
            return NSXDAO.SuaNSX(nsx);
        }
        public static bool XoaNSX(NSXDTO nsx)
        {
            return NSXDAO.XoaNSX(nsx);
        }
        public static bool KT(int masx)
        {
            return NSXDAO.KT(masx);
        }
        public static DataTable TimKiem(int masx)
        {
            return NSXDAO.TimKiem(masx);
        }
    }
}
