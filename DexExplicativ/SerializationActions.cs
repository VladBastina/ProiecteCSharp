using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DexExplicativ
{
    class SerializationActions
    {
        public ObservableCollection<WordClass> words;
        public SerializationActions(ObservableCollection<WordClass> words)
        {
            this.words = words;
        }
        public void SerializeObject(ObjectToSerialize entity)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(ObjectToSerialize));
            FileStream fileStr = new FileStream("output.xml", FileMode.Create);
            xmlser.Serialize(fileStr, entity);
            fileStr.Dispose();
        }
        public void DeserializeObject()
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(ObjectToSerialize));
            FileStream file = new FileStream("output.xml", FileMode.Open);
            //se schimba referinta la colectie prin reinitializarea ei cu un alt obiect - binding-ul era facut pe primul obiect
            //this.cars = (xmlser.Deserialize(file) as ObjectToSerialize).Cars;
            //din acest motiv repopulez colectia this.cars cu elementele colectiei obtinute prin deserializare
            var w = (xmlser.Deserialize(file) as ObjectToSerialize).Words;
            words.Clear();
            foreach (var word in w)
            {
                words.Add(word);
            }
            file.Dispose();
        }
    }
}
