using System;
using System.Windows.Forms;
using Npgsql;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PgSql
{
    public class LopHS
    {
        public int SoLuong { get; set; }
        public List<HocSinh> DanhSachHocSinh { get; set; }
    }
    public class HocSinh
    {
        public int ID { get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string GioiTinh { get; set; }

        public HocSinh()
        {

        }
        public HocSinh(int id, String hoten, int tuoi, string gioitinh)
        {
            ID = id;
            HoTen = hoten;
            Tuoi = tuoi;
            GioiTinh = gioitinh;
        }
    }

    public class PostGreSQL
    {
        List<string> dataItems = new List<string>();

        public void PostgreSQL()
        {
        }

        public List<string> PostgreSQLtest1()
        {
            {
                string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=230798; Database=hocsinh;";
                NpgsqlConnection connection = new NpgsqlConnection(connstring);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM test", connection);

                NpgsqlDataReader dataReader = command.ExecuteReader();
                for (int i = 0; dataReader.Read(); i++)
                {
                    dataItems.Add(dataReader[0].ToString() + "  /  " + dataReader[1].ToString() + "  /  " + dataReader[2].ToString() + "  /  " + dataReader[3].ToString() + "\r\n");
                }
                connection.Close();
                return dataItems;
            }
        }

        public List<string> PostgreSQLtest2()
        {
            String json_data = File.ReadAllText(@"C:\Users\ADMIN\Desktop\DanhSachHocSinh.json");
            LopHS List = JsonConvert.DeserializeObject<LopHS>(json_data);
            List<HocSinh> DanhSach = List.DanhSachHocSinh;
            
            string connstring = "Server=localhost; Port=5432; User Id=uyen; Password=230798; Database=hocsinh;";
            NpgsqlConnection connection = new NpgsqlConnection(connstring);
            connection.Open();


            NpgsqlCommand command;
            command = new NpgsqlCommand("DELETE FROM test;",connection);
            command.ExecuteNonQuery();

            foreach (HocSinh HS in DanhSach)
            {
                string str = "INSERT INTO test(id,hovaten,tuoi,gioitinh) VALUES (" + HS.ID + ",'" + HS.HoTen + "'," + HS.Tuoi + ",'" + HS.GioiTinh + "');";
                command = new NpgsqlCommand(str, connection);
                command.ExecuteNonQuery();
                dataItems.Add(str + "\r\n");
            }


            connection.Close();
            return dataItems;
        }
    }
}