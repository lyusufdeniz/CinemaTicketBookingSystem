using SinemaOtomasyonuStaj.DataAcces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SinemaOtomasyonuStaj.DataAccesLayer
{
    class ManagerDAL : IManagerDAL
    {
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        private string query;
        public bool managerLogin(string username, string password)
        {

            if (username.Length == 0 && password.Length == 0)
            {
                return false;
            }
            else
            {
                query = "SELECT * FROM Managers where managerUserName=@P1 AND managerPassword=@P2";
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



        }
        public int countManagers()
        {
            query = "SELECT COUNT(*) FROM Managers";
            DbConnection.Connect();
            cmd = new SqlCommand(query, DbConnection.conn);
            Int32 count = (Int32)cmd.ExecuteScalar();
            DbConnection.Disconnect();
            return count;
        }
        public int countStaff()
        {
            query = "SELECT COUNT(*) FROM Staff";
            DbConnection.Connect();
            cmd = new SqlCommand(query, DbConnection.conn);
            Int32 count = (Int32)cmd.ExecuteScalar();
            DbConnection.Disconnect();
            return count;
        }
        public int countGenders()
        {
            query = "SELECT COUNT(*) FROM Customers where customerGender=0";
            DbConnection.Connect();
            cmd = new SqlCommand(query, DbConnection.conn);
            Int32 male =(Int32)cmd.ExecuteScalar();
            query = "SELECT COUNT(*) FROM Customers";
            DbConnection.Connect();
            cmd = new SqlCommand(query, DbConnection.conn);

            Int32 all = (Int32)cmd.ExecuteScalar();

            float f = (System.Single)male / (System.Single)all;
            int count = Convert.ToInt32(f*100);
            DbConnection.Disconnect();
            return count;
        }
        public int countTickets()
        {
            query = "SELECT COUNT(*) FROM Tickets";
            DbConnection.Connect();
            cmd = new SqlCommand(query, DbConnection.conn);
            Int32 count = (Int32)cmd.ExecuteScalar();
            DbConnection.Disconnect();
            return count;
        }
        public int countCustomers()
        {
            query = "SELECT COUNT(*) FROM Customers";
            DbConnection.Connect();
            cmd = new SqlCommand(query, DbConnection.conn);
            Int32 count = (Int32)cmd.ExecuteScalar();
            DbConnection.Disconnect();
            return count;
        }
        public bool addHall(string hallname, int hallcapacity)
        {
            if (hallname.Length >= 1 && hallcapacity >= 10)
            {
                try
                {
                    DbConnection.Connect();
                    query = "INSERT INTO Halls values(@P1,@P2)";
                    cmd = new SqlCommand(query, DbConnection.conn);
                    cmd.Parameters.AddWithValue("@P1", hallname);
                    cmd.Parameters.AddWithValue("@P2", hallcapacity);
                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                    return false;

                }
            }
            else return false;


        }
        public bool addMovie(string moviename, string moviedirector, DateTime movieduration)
        {
            if (moviename.Length >= 1 && moviedirector.Length >= 1 && movieduration.ToString().Length >= 1)
            {
                try
                {
                    DbConnection.Connect();
                    query = "INSERT INTO Movies values(@P1,@P2,@P3)";
                    cmd = new SqlCommand(query, DbConnection.conn);
                    cmd.Parameters.AddWithValue("@P1", moviename);
                    cmd.Parameters.AddWithValue("@P2", moviedirector);
                    cmd.Parameters.AddWithValue("@P3", movieduration);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;

                }
            }
            else return false;


        }
        public List<string> getMovies()
        {
            List<string> movies = new List<string>();
            query = "SELECT * FROM Movies";
            cmd = new SqlCommand(query, DbConnection.conn);
            DbConnection.Connect();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                movies.Add(dr["movieName"].ToString());

            }
            return movies;


        }
        public List<string> getHalls()
        {
            List<string> halls = new List<string>();
            query = "SELECT * FROM Halls";
            cmd = new SqlCommand(query, DbConnection.conn);
            DbConnection.Connect();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                halls.Add(dr["hallName"].ToString());

            }
            return halls;


        }
        private int getmovieidbyname(string moviename)
        {
            query = "SELECT movieID FROM Movies where movieName=@P1";
            cmd = new SqlCommand(query, DbConnection.conn);
            cmd.Parameters.AddWithValue("@P1", moviename);
            DbConnection.Connect();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return Int32.Parse(dr["movieID"].ToString());

            }
            else return 0000;

        }
        private int gethallIDbyname(string hallname)
        {
            query = "SELECT hallID FROM Halls where hallName=@P1";
            cmd = new SqlCommand(query, DbConnection.conn);
            cmd.Parameters.AddWithValue("@P1", hallname);
            DbConnection.Connect();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return Int32.Parse(dr["hallID"].ToString());

            }
            else return 0000;

        }
        public bool addSession(string moviename, string time, string hallname)
        {
            int movieid = getmovieidbyname(moviename);
            int hallid = gethallIDbyname(hallname);
           
            if (hallname.Length >= 1 && time.ToString().Length >= 1 && hallname.Length >= 1)
            {

                try
                {
                    if(sessionControl(hallname,time))
                    {
                        DbConnection.Connect();
                        query = "INSERT INTO Sessions values(@P1,@P2,@P3)";
                        cmd = new SqlCommand(query, DbConnection.conn);
                        cmd.Parameters.AddWithValue("@P1", movieid);
                        cmd.Parameters.AddWithValue("@P2", hallid);
                        cmd.Parameters.AddWithValue("@P3", time.ToString());
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("aynı saatte aynı salonda farklı bir seans mevcut");
                        return false;
                    }
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                    return false;

                }
            }
            else return false;

        }
        public bool sessionControl(string hallname, string time)
        {
       
            int hallid = gethallIDbyname(hallname);
            query = "SELECT * FROM Sessions where hallID=@P1 AND time=@P2";
            cmd = new SqlCommand(query, DbConnection.conn);
            cmd.Parameters.AddWithValue("@P1", hallid);
            cmd.Parameters.AddWithValue("@P2", time);
            DbConnection.Connect();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                DbConnection.Disconnect();
                dr.Close();
                return false;
            }
            else
            {
                DbConnection.Disconnect();
                dr.Close();
                return true;
            }

        }

        public DataSet getPersonelTable()
        {
            try
            {
                DbConnection.Connect();
                query = "SELECT *FROM STAFF";
                da = new SqlDataAdapter(query, DbConnection.conn);
                da.Fill(ds, "Staff");
                DbConnection.Disconnect();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return ds;
            }


        }
        public DataSet getManagerTable()
        {
            try
            {
                DbConnection.Connect();
                query = "SELECT *FROM Managers";
                da = new SqlDataAdapter(query, DbConnection.conn);
                da.Fill(ds, "Managers");
                DbConnection.Disconnect();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return ds;
            }


        }

        public bool addStaff(string username, string pw, string name, string surname, string manageruserid)
        {
            if (username.Length >= 1 && pw.Length >= 1 && name.Length >= 1 && surname.Length >= 1 && manageruserid.Length >= 1)
            {
                try
                {
                    DbConnection.Connect();
                    query = "INSERT INTO Staff values(@P1,@P2,@P3,@P4,@P5)";
                    cmd = new SqlCommand(query, DbConnection.conn);
                    cmd.Parameters.AddWithValue("@P1", username);
                    cmd.Parameters.AddWithValue("@P2", pw);
                    cmd.Parameters.AddWithValue("@P3", name);
                    cmd.Parameters.AddWithValue("@P4", surname);
                    cmd.Parameters.AddWithValue("@P5", manageruserid);
                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException ex)
                {
                    int errorno = ex.Number;
                    switch (errorno)
                    {
                        case 2627:
                            MessageBox.Show(username + " adlı başka bir personel bulunmaktadır!");
                            break;
                        case 2628:
                            MessageBox.Show("Girilen bilgiler cok uzun...");
                            break;

                        default:
                            break;
                    }
                    return false;
                }
            }
            else return false;


        }
        public bool updatetaff(string username, string pw, string name, string surname, string selectedusername)
        {
            if (username.Length >= 1 && pw.Length >= 1 && name.Length >= 1 && surname.Length >= 1 && selectedusername.Length >= 1)
            {
                try
                {
                    DbConnection.Connect();
                    query = "UPDATE Staff SET staffUserName=@P1,staffPassword=@P2,staffName=@P3,staffSurname=@P4 WHERE staffUserName=@P5";
                    cmd = new SqlCommand(query, DbConnection.conn);
                    cmd.Parameters.AddWithValue("@P1", username);
                    cmd.Parameters.AddWithValue("@P2", pw);
                    cmd.Parameters.AddWithValue("@P3", name);
                    cmd.Parameters.AddWithValue("@P4", surname);
                    cmd.Parameters.AddWithValue("@P5", selectedusername);

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException ex)
                {
                    int errorno = ex.Number;
                    switch (errorno)
                    {
                        case 2627:
                            MessageBox.Show(username + " adlı başka bir personel bulunmaktadır!");
                            break;
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
        public bool deleteStaff(string staffusername)
        {
            if (!String.IsNullOrEmpty(staffusername))
            {
                try
                {
                    DbConnection.Connect();
                    query = "DELETE Staff WHERE staffUserName=@P1";
                    cmd = new SqlCommand(query, DbConnection.conn);
                    cmd.Parameters.AddWithValue("@P1", staffusername);

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException ex)
                {
                    int errorno = ex.Number;
                    switch (errorno)
                    {


                        default:
                            MessageBox.Show(ex.Message.ToString());
                            break;
                    }
                    return false;
                }
            }
            else return false;

        }

        public bool addManager(string username, string pw, string name, string surname)
        {
            if (username.Length >= 1 && pw.Length >= 1 && name.Length >= 1 && surname.Length >= 1)
            {
                try
                {
                    DbConnection.Connect();
                    query = "INSERT INTO Managers values(@P1,@P2,@P3,@P4)";
                    cmd = new SqlCommand(query, DbConnection.conn);
                    cmd.Parameters.AddWithValue("@P1", username);
                    cmd.Parameters.AddWithValue("@P2", pw);
                    cmd.Parameters.AddWithValue("@P3", name);
                    cmd.Parameters.AddWithValue("@P4", surname);

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException ex)
                {
                    int errorno = ex.Number;
                    switch (errorno)
                    {
                        case 2627:
                            MessageBox.Show(username + " adlı başka bir Yönetici bulunmaktadır!");
                            break;
                        case 2628:
                            MessageBox.Show("Girilen bilgiler cok uzun...");
                            break;

                        default:
                            break;
                    }
                    return false;
                }
            }
            else return false;


        }
        public bool updateManager(string username, string pw, string name, string surname, string selectedusername)
        {
            if (username.Length >= 1 && pw.Length >= 1 && name.Length >= 1 && surname.Length >= 1 && selectedusername.Length >= 1)
            {
                try
                {
                    DbConnection.Connect();
                    query = "UPDATE Managers SET managerUserName=@P1,managerPassword=@P2,managerName=@P3,managerSurname=@P4 WHERE managerUserName=@P5";
                    cmd = new SqlCommand(query, DbConnection.conn);
                    cmd.Parameters.AddWithValue("@P1", username);
                    cmd.Parameters.AddWithValue("@P2", pw);
                    cmd.Parameters.AddWithValue("@P3", name);
                    cmd.Parameters.AddWithValue("@P4", surname);
                    cmd.Parameters.AddWithValue("@P5", selectedusername);

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException ex)
                {
                    int errorno = ex.Number;
                    switch (errorno)
                    {
                        case 2627:
                            MessageBox.Show(username + " adlı başka bir Yönetici bulunmaktadır!");
                            break;
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
        public bool deleteManager(string managerusername)
        {
            if (!String.IsNullOrEmpty(managerusername))
            {
                try
                {
                    DbConnection.Connect();
                    query = "DELETE Managers WHERE managerUserName=@P1";
                    cmd = new SqlCommand(query, DbConnection.conn);
                    cmd.Parameters.AddWithValue("@P1", managerusername);

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException ex)
                {
                    int errorno = ex.Number;
                    switch (errorno)
                    {


                        default:
                            MessageBox.Show(ex.Message.ToString());
                            break;
                    }
                    return false;
                }
            }
            else return false;

        }






    }
}

