using Checkers.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Checkers.Services
{
    internal class StatisticsSerializer
    {
        private string filePath = @"C:\Users\vladb\VisualStudio\Checkers\Checkers\Resources\StatisticsFolder\statistics.xml";
        public void SerializeObject(Statistics entity)
        { 
            XmlSerializer xmlser = new XmlSerializer(typeof(Statistics));
            FileStream fileStr = new FileStream(filePath, FileMode.Create);
            xmlser.Serialize(fileStr, entity);
            fileStr.Dispose();
        }
        public Statistics DeserializeObject()
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(Statistics));
            FileStream file = new FileStream(filePath, FileMode.Open);
            //se schimba referinta la colectie prin reinitializarea ei cu un alt obiect - binding-ul era facut pe primul obiect
            //this.cars = (xmlser.Deserialize(file) as ObjectToSerialize).Cars;
            //din acest motiv repopulez colectia this.cars cu elementele colectiei obtinute prin deserializare
            var w = (xmlser.Deserialize(file) as Statistics);
            file.Dispose();
            Statistics statistics = (w as Statistics).Clone();
            return statistics;
        }
    }
}
