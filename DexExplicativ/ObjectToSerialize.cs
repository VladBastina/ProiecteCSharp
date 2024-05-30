using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace DexExplicativ
{
    [Serializable]
    public class ObjectToSerialize 
    {
        [XmlArray]
        public ObservableCollection<WordClass> Words { get; set; }

        [XmlIgnore]
        public ObservableCollection<WordClass> Recomandations { get; set; }

        private WordClass _selectedWord;

        [XmlIgnore]
        public WordClass SelectedWord {
            get {  return _selectedWord; } 
            set
            {
                if(value!=null) 
                {
                    if (value.Word != null)
                        _selectedWord.Word = value.Word;
                    if (value.Explenation != null)
                        _selectedWord.Explenation = value.Explenation;
                    if (value.Category != null)
                        _selectedWord.Category = value.Category;
                    if (value.ImagePath != null)
                        _selectedWord.ImagePath = value.ImagePath;
                }
            }
                 }

        [XmlIgnore]
        public ObservableCollection<string> CategoryList { get; set; }

        public ObjectToSerialize()
        {
            Words = new ObservableCollection<WordClass>();
            Recomandations = new ObservableCollection<WordClass>();
            _selectedWord = new WordClass();
            CategoryList = new ObservableCollection<string>();
        }

        public void updateRecomadations(string text, string category = "")
        {
            Recomandations.Clear();
            foreach (WordClass w in Words)
            {
                if (w.Word.Contains(text) && text != string.Empty)
                {
                    if (category != "" && w.Category == category)
                    {
                        Recomandations.Add(w);
                    }
                    else if (category == "")
                    {
                        Recomandations.Add(w);
                    }
                }
            }
            List<WordClass> list = Recomandations.ToList();
            list.Sort((x, y) => string.Compare(x.Word, y.Word));

            Recomandations.Clear();

            foreach (var item in list)
            {
                Recomandations.Add(item);
            }
        }

        public WordClass VerifyWord(WordClass word)
        {
            foreach (WordClass w in Words)
            {
                if (w.Word == word.Word)
                {
                    return w;
                }
            }
            return null;
        }

        public void AddWord(WordClass word)
        {
            WordClass existingWord = VerifyWord(word);
            if(word.ImagePath=="")
            {
                word.ImagePath = "D:\\VisualStudio\\DexExplicativ\\images\\noImage.jpg";
            }

            if (word.Word != "" && word.Explenation != "" && word.ImagePath != "" && word.Category != "")
            {
                if (existingWord == null)
                {
                    Words.Add(word);
                }
                else
                {
                    existingWord.Word = word.Word;
                    existingWord.Explenation = word.Explenation;
                    existingWord.ImagePath = word.ImagePath;
                    existingWord.Category = word.Category;
                }
            }
            else
            {
                MessageBox.Show("Nu au fost introduse toate informațiile");
            }
        }

        public void UpdateCategoryList()
        {
            CategoryList.Clear();
            foreach (var item in Words)
            {
                CategoryList.Add(item.Category);
            }
            HashSet<string> hash =  new HashSet<string>(CategoryList);
            CategoryList.Clear();
            foreach(var item in hash)
            {
                CategoryList.Add(item);
            }
        }

        public void DeleteWord(string word)
        {
            int length = Words.Count;
            foreach (var item in Words)
            {
                if (item.Word == word)
                {
                    Words.Remove(item);
                    MessageBox.Show("Cuvantul a fost sters cu succes");
                    break;
                }
            }
            if(length == Words.Count)
            {
                MessageBox.Show("Cuvantul nu a putut fi gasit");
            }
        }

        public List<WordClass> SelectFive()
        {
            List<WordClass> list = new List<WordClass>();
            Random random = new Random();
            if (Words.Count >= 5)
            {
                while (list.Count < 5)
                {
                    int randomIndex = random.Next(0, Words.Count);
                    if (!list.Contains(Words[randomIndex]))
                    {
                        list.Add(Words[randomIndex]);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lista nu conține suficiente cuvinte.");
            }
            return list;
        }

        public List<int> propertyShownWords (List<WordClass> list)
        {
            List<int> indexes = new List<int>();
            foreach (var item in list)
            {
                if (item.ImagePath == "D:\\VisualStudio\\DexExplicativ\\images\\noImage.jpg")
                {
                    indexes.Add(1);
                }
                else
                {
                    Random random = new Random();
                    int randomIndex = (random.Next(1, 100))%2 +1;
                    indexes.Add(randomIndex); 
                }
            }
            return indexes;
        }
    }
}
