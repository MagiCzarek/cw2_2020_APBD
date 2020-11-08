using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Cw2
{
    class ConsoleApp1
    {
        static void Main(string[] args)
        {

            try
            {
                //adres w programie jest w data dane.csv
                Console.WriteLine("Podaj sciezkę źródłową");

                var csvPath = Console.ReadLine();
                if (csvPath == "")
                {
                    csvPath = @"C:\Users\Czarek\Documents\GitHub\cw2_2020_APBD\ConsoleApp1\ConsoleApp1\Data\dane.csv";
                }

                //wynik dzialania aplikacje jest w data result.xmlresult.xml
                Console.WriteLine("Podaj ścieżkę docelową");

                //"xml"
                var xmlPath = Console.ReadLine();
                if (xmlPath == "")
                {
                    xmlPath = @"C:\Users\Czarek\Documents\GitHub\cw2_2020_APBD\ConsoleApp1\ConsoleApp1\Data\result.xml";
                    Console.WriteLine("Podaj format");
                }

                string format = Console.ReadLine();
                if (format == "")
                {
                    format = "xml";
                }
              

                string[] source = File.ReadAllLines(csvPath);
                XElement xml = new XElement("Root",
                    from str in source
                    let fields = str.Split(',')
                    select new XElement("studenci",
                        new XAttribute("student_indexNumber", "s" + fields[4]),
                        new XElement("fname", fields[0]),
                        new XElement("lname", fields[1]),
                        new XElement("birthdate", fields[5]),
                        new XElement("email", fields[6]),
                        new XElement("mothersName", fields[7]),
                        new XElement("fathersname", fields[8]),
                        new XElement("studies",
                            new XElement("name", fields[2]),
                            new XElement("mode", fields[3])
                        )
                    )
                );
                xml.Save(String.Concat(xmlPath + "result.xml"));
            }catch(Exception ex)
            {
                string filePath = @"C:\Users\Czarek\Documents\GitHub\cw2_2020_APBD\ConsoleApp1\ConsoleApp1\log.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
            }
        }
       
    }
}