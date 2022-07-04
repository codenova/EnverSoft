using CsvHelper;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace EnverSoft
{
    class Program
    {
        public class CSVFile
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
        }
        static void Main(string[] args)
        {
            #region excercise#1
            //int[] list1 = new int[] { 1, 2, 3, 4, 5 };
            //int[] list2 = new int[] { 3, 4, 5, 6, 7 };

            ////Commons in both lists
            //var list3 = list1.Intersect(list2);

            //Console.WriteLine(String.Join(" ", list3));

            ////Only list1 not list2
            //var list4 = list1.Except(list2);
            //Console.WriteLine(String.Join(" ", list4));

            ////Only list2 not list1
            //var list5 = list2.Except(list1);
            //Console.WriteLine(String.Join(" ", list5));


            //Console.WriteLine("Press enter to continue!");
            //Console.ReadLine();

            #endregion excercise#1

            #region excesise#2
            //Please use relevent paths....
            string csvPath = @"C:\Users\F5311144\OneDrive - FRG\Desktop\NB\EnverSoft\EnverSoft\Data.csv";
            string txtPath = @"C:\Users\F5311144\OneDrive - FRG\Desktop\NB\EnverSoft\EnverSoft\Data.txt";

            var reader = new StreamReader(csvPath);

            StreamWriter streamWriter = new StreamWriter(txtPath);
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                //Please Run one method at the time.
                FirstOutPut(streamWriter, csv);
                //SecondOutPut(streamWriter, csv);
                //ThirdOutPut(streamWriter, csv);
                //FourthOutPut(streamWriter, csv);

                streamWriter.Close();
            }
            #endregion excesise#

        }

        private static void FirstOutPut(StreamWriter streamWriter, CsvReader csv)
        {
            var records = csv.GetRecords<CSVFile>();

            var firstRecords = from record in records
                               orderby record.FirstName, record.LastName
                               group record by new
                               {
                                   record.FirstName,
                                   record.LastName,

                               } into grp
                               select new { key = grp.Key, frequency = grp.Count() };

            foreach (var firstRecord in firstRecords)
            {
                streamWriter.WriteLine(firstRecord.key.LastName + "," + firstRecord.frequency + Environment.NewLine);
            }
            streamWriter.WriteLine("");
        }

        private static void SecondOutPut(StreamWriter streamWriter, CsvReader csv)
        {
            var records = csv.GetRecords<CSVFile>();
            var secondRecords = from record in records
                                orderby record.Address //--.Split(" ").OrderBy(s => s)

                                select record;

            foreach (var secondRecord in secondRecords)
            {
                streamWriter.WriteLine(secondRecord.Address + Environment.NewLine);
            }

            streamWriter.WriteLine("");
        }

        private static void ThirdOutPut(StreamWriter streamWriter, CsvReader csv)
        {
            var records = csv.GetRecords<CSVFile>();
            var thirdRecords = from record in records
                               orderby record.FirstName
                               select record;

            foreach (var thirdRecord in thirdRecords)
            {
                streamWriter.WriteLine(thirdRecord.FirstName + " " + thirdRecord.LastName);
            }
            streamWriter.WriteLine("");
        }

        private static void FourthOutPut(StreamWriter streamWriter, CsvReader csv)
        {
            var records = csv.GetRecords<CSVFile>();
            var fourthRecords = from record in records
                                orderby record.FirstName
                                group record by new
                                {
                                    record.FirstName,

                                } into grp
                                select new { key = grp.Key, frequency = grp.Count() };

            foreach (var fourthRecord in fourthRecords)
            {
                streamWriter.WriteLine(fourthRecord.key.FirstName + " ," + fourthRecord.frequency);
            }
            streamWriter.WriteLine("");
        }
    }
}
