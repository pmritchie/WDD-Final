using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Ritchie_Patrick_dbsreview
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MySQLDatabase db = new MySQLDatabase();
            db.Connect("dbsAdmin", "Olivia01!", "SampleAPIData");
            bool programIsRunning = true;
            // Console.WriteLine("Please enter the name of the City you want to look up and press return.");
            do
            {
                Console.Clear();
                string city = Validation.WhiteNull("Please enter the name of the City you want to look up and press return. ");
                DataTable data = new DataTable();
                db.Query("SELECT city, temp, pressure, humidity FROM weather WHERE city ='" + city + "'", data);


                int numberOfResults = data.Select().Length;
                if (numberOfResults == 0)
                {
                    Console.WriteLine("No Data Available for selected city.");

                }
                else
                {

                    for (int i = 0; i < numberOfResults; i++)
                    {
                        Console.WriteLine("City: " +data.Rows[i]["city"].ToString() +"\n" +
                           "Temperature: " +data.Rows[i]["temp"].ToString()+ "\n" +
                           "Humidity: "+ data.Rows[i]["humidity"].ToString()+"\n" +
                           "Pressure: "+data.Rows[i]["pressure"].ToString()+"\n");
                    }


                }
                string newSearch = Validation.WhiteNull("Would you like to search again? (Yes/No)");
                 
                
                    if (newSearch == "no")
                    {
                        programIsRunning = false;
                    }
                    else if (newSearch == "yes")
                    {
                        programIsRunning = true;
                    }




                Console.Clear();
            } while (programIsRunning);
            db.CloseConnection();

        }
    }
}
