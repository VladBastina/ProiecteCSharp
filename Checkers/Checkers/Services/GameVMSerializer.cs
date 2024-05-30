using Checkers.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Checkers.Services
{
    class GameVMSerializer
    {
        public void SerializeObject(GameVM entity,string path)
        {
            entity.BoardVM.ReconfigCells();
            XmlSerializer xmlser = new XmlSerializer(typeof(GameVM));
            using (FileStream fileStr = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlser.Serialize(fileStr, entity);
            }
            MessageBox.Show("Game saved Succesfully!");
        }
        public GameVM DeserializeObject(string filePath)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(GameVM));
            FileStream file = new FileStream(filePath, FileMode.Open);
            var w = (xmlser.Deserialize(file) as GameVM);
            GameVM game = (w as GameVM).Clone();
            return game;
        }
    }
}
