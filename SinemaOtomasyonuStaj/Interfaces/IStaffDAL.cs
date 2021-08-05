using System.Data;

namespace SinemaOtomasyonuStaj.DataAccesLayer
{
    interface IStaffDAL
    {
        bool addCustomer(string fullname, int gender, int type);
        DataSet getCustomerTable();
        DataSet getSessions();
        bool seatisEmpty(int seatNo, int sessionID);
        bool sellTicket(int customerID, int sessionID, int seatNo, int price);
        bool staffLogin(string username, string password);
    }
}