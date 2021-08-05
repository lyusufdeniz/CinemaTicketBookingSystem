using System;
using System.Collections.Generic;
using System.Data;

namespace SinemaOtomasyonuStaj.DataAccesLayer
{
    interface IManagerDAL
    {
        bool addHall(string hallname, int hallcapacity);
        bool addManager(string username, string pw, string name, string surname);
        bool addMovie(string moviename, string moviedirector, DateTime movieduration);
        bool addSession(string moviename, string time, string hallname);
        bool addStaff(string username, string pw, string name, string surname, string manageruserid);
        int countCustomers();
        int countManagers();
        int countStaff();
        int countTickets();
        bool deleteManager(string managerusername);
        bool deleteStaff(string staffusername);
        List<string> getHalls();
        DataSet getManagerTable();
        List<string> getMovies();
        DataSet getPersonelTable();
        bool managerLogin(string username, string password);
        bool updateManager(string username, string pw, string name, string surname, string selectedusername);
        bool updatetaff(string username, string pw, string name, string surname, string selectedusername);
    }
}