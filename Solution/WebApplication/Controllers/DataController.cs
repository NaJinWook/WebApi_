using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    [Route("api/Select")]
    public class DataController : Controller
    {
        private ArrayList list;
        MySqlConnection conn;
        // GET: api/<controller>
        [HttpGet]
        public ArrayList Select()
        {
            list = new ArrayList();
            conn = new MySqlConnection();

            DataBase db = new DataBase();

            conn.ConnectionString = string.Format("host={0};uid={1};pwd={2};port={3};database={4}", "gdc3.gudi.kr","root","1234", "24002","gudi");
            try
            {
                conn.Open();
                Console.WriteLine("성공");
                //list.Add("Success");

                MySqlDataReader sdr = db.GetReader("select * from Notice");
                while(sdr.Read())
                {
                    Hashtable ht = new Hashtable();
                    //string[] arr = new string[sdr.FieldCount];
                    for(int i = 0; i < sdr.FieldCount; i++)
                    {
                        ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
                        //arr[i] = sdr.GetValue(i).ToString();
                    }
                    
                    list.Add(ht);
                }
            }
            catch
            {
                Console.WriteLine("실패");
                list.Add("Fail");
            }
            return list;
        }

    }
}
