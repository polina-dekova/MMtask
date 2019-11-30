using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MentorMateTask
{




    public class Rootobject
    {
        public string Name { get; set; }
        public int PlayerSince { get; set; }
        public string Position { get; set; }
        public float Rating { get; set; }
    }



    public class Response : IEnumerable<Rootobject> , IComparer<int>
    {
        public List<Rootobject> Files { get; set; }

        public int Compare(int x, int y)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Rootobject> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

   

    class Program
    {
        
           static void Main(string[] args) { 

        

            //read the file system contents
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:");

            FileInfo[] fileNames = directoryInfo.GetFiles("*.json");
            Dictionary<int, string> fileDictionary = new Dictionary<int, string>();

            string fileToFind;
            do
            {
                Console.WriteLine("Please enter the name of .json file: ");
                fileToFind = Console.ReadLine().Trim();
            }
            while (fileToFind == "");

            Console.WriteLine(fileNames[0].FullName);
            var pathJson = fileNames[0].FullName;
            var res = JsonConvert.DeserializeObject<List<Rootobject>>(File.ReadAllText(pathJson));



            Console.WriteLine("Enter Year:");
            int yearsofplay;
            yearsofplay = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Rating:");
            float ratingPlayer;
            ratingPlayer = float.Parse(Console.ReadLine());
            Console.WriteLine("");

            //read the file system contents
            DirectoryInfo directoryInfo2 = new DirectoryInfo(@"C:");

            FileInfo[] fileNames2 = directoryInfo.GetFiles("*.csv");
            Dictionary<int, string> fileDictionary2 = new Dictionary<int, string>();

            string fileToFind2;
            do
            {
                Console.WriteLine("Please enter the name of .CSV file ");
                fileToFind2 = Console.ReadLine().Trim();
            }
            while (fileToFind == "");

            Console.WriteLine(fileNames2[0].FullName);
            var pathCsv = fileNames2[0].FullName;

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@pathCsv, true))
            {
                file.WriteLine("Name" +"," +"Rating");
                


                foreach (var f in res)
                {
                    if (f.PlayerSince < yearsofplay)
                        if (f.Rating > ratingPlayer)
                        {
                            var sortedQuery = res.OrderByDescending(x => x.Rating);
                            var sortedList = sortedQuery.ToList();
                            foreach (var obj in sortedQuery)
                            {
                                if (obj.Rating == obj.Rating)
                                {
                                    var sortedQuery2 = sortedQuery.OrderBy(x => x.Name);
                                    var sortedList2 = sortedQuery2.ToList();

                                }
                                file.WriteLine(obj.Name + "," + " " + obj.Rating);
                                //Console.WriteLine("{0}, {1}", obj.Name, obj.Rating);

                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Such player doesn't exist!");
                        }

                    file.Close();
                    
                }
            }
            

            
            Console.ReadLine();









        }
        

    }




}







