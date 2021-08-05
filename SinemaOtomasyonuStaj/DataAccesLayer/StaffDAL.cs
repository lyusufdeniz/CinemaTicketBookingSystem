using SinemaOtomasyonuStaj.DataAcces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace SinemaOtomasyonuStaj.DataAccesLayer
{
    class StaffDAL : IStaffDAL
    {
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        private string query;
        public bool staffLogin(string username, string password)
        {


            query = "SELECT * FROM Staff where staffUserName=@P1 AND staffPassword=@P2";
            cmd = new SqlCommand(query, DbConnection.conn);
            cmd.Parameters.AddWithValue("@P1", username);
            cmd.Parameters.AddWithValue("@P2", password);
            DbConnection.Connect();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                DbConnection.Disconnect();
                dr.Close();
                return true;
            }
            else
            {
                DbConnection.Disconnect();
                dr.Close();
                return false;
            }

        }
        public bool addCustomer(string fullname, int gender, int type)
        {
            if (fullname.Length >= 1 && gender >= 0 && type >= 0)
            {
                try
                {
                    DbConnection.Connect();
                    query = "INSERT INTO Customers values(@P1,@P2,@P3)";
                    cmd = new SqlCommand(query, DbConnection.conn);
                    cmd.Parameters.AddWithValue("@P1", fullname);
                    cmd.Parameters.AddWithValue("@P2", gender);
                    cmd.Parameters.AddWithValue("@P3", type);

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException ex)
                {
                    int errorno = ex.Number;
                    switch (errorno)
                    {

                        case 2628:
                            MessageBox.Show("Girilen bilgiler cok uzun...");
                            break;

                        default:
                            MessageBox.Show(ex.Message.ToString());
                            break;
                    }
                    return false;
                }
            }
            else return false;


        }
        public DataSet getCustomerTable()
        {
            try
            {
                DbConnection.Connect();
                query = "SELECT *FROM Customers";
                da = new SqlDataAdapter(query, DbConnection.conn);
                da.Fill(ds, "Customers");
                DbConnection.Disconnect();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return ds;
            }


        }
        public DataSet getSessions()
        {
            try
            {
                DbConnection.Connect();
                query = @"SELECT Halls.hallID, Halls.hallName, Halls.seatCapacity, Movies.movieName, Sessions.sessionID, Sessions.movieID, Sessions.time
                    FROM Halls INNER JOIN
                         Sessions ON Halls.hallID = Sessions.hallID INNER JOIN
                         Movies ON Sessions.movieID = Movies.movieID";
                da = new SqlDataAdapter(query, DbConnection.conn);
                da.Fill(ds, "Sessions");
                DbConnection.Disconnect();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return ds;
            }


        }
        public bool seatisEmpty(int seatNo, int sessionID)
        {


            query = "SELECT * FROM Tickets where sessionID=@P1 AND seatNo=@P2";
            cmd = new SqlCommand(query, DbConnection.conn);
            cmd.Parameters.AddWithValue("@P1", sessionID);
            cmd.Parameters.AddWithValue("@P2", seatNo);
            DbConnection.Connect();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                DbConnection.Disconnect();
                dr.Close();
                return true;
            }
            else
            {
                DbConnection.Disconnect();
                dr.Close();
                return false;
            }

        }
        public bool sellTicket(int customerID, int sessionID, int seatNo, int price)
        {
            try
            {
                DbConnection.Connect();
                query = "INSERT INTO Tickets values(@P1,@P2,@P3,@P4)";
                cmd = new SqlCommand(query, DbConnection.conn);
                cmd.Parameters.AddWithValue("@P1", customerID);
                cmd.Parameters.AddWithValue("@P2", sessionID);
                cmd.Parameters.AddWithValue("@P3", seatNo);
                cmd.Parameters.AddWithValue("@P4", price);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

        }
        public DataSet getticketControlTable()
        {
            try
            {
                DbConnection.Connect();
                query = @"SELECT        Tickets.ticketID AS [Bilet No], Tickets.ticketCustomerID AS [Üye No], Tickets.seatNo AS [Koltuk No], Tickets.ticketPrice AS [Bilet Ücreti], Halls.hallName AS [Salon  Adı], Sessions.time AS Saat, 
                         Customers.customerFullName AS[Üye Adı], Customers.customerType AS[Üye Tipi], Movies.movieName AS[Film Adı]
                        FROM Movies INNER JOIN
                         Tickets INNER JOIN
                         Sessions INNER JOIN
                         Halls ON Sessions.hallID = Halls.hallID ON Tickets.sessionID = Sessions.sessionID ON Movies.movieID = Sessions.movieID INNER JOIN
                         Customers ON Tickets.ticketCustomerID = Customers.customerID";
                da = new SqlDataAdapter(query, DbConnection.conn);
                da.Fill(ds, "Customers");
                DbConnection.Disconnect();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return ds;
            }


        }
    }
}
