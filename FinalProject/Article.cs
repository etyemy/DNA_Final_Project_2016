using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    /*
     * Article class holds the article details.
     * Contains only constractor, getters and toString method. 
     * Main purpose - easy transfer of article details.
     */
    public class Article
    {
        private string _title;
        private string _author;
        private int _year;
        private string _journal;
        private string _cosmicId;
        private string _pubmedId;

        public Article(string title, string author, int year, string journal, string cosmicId, string pubmedId)
        {
            _title = title;
            _author = author;
            _year = year;
            _journal = journal.Split(';')[0].Trim(new char[] { '"' });
            _cosmicId = cosmicId;
            _pubmedId = pubmedId;
        }
        public override string ToString()
        {
            return "Title: " + _title + Environment.NewLine
                + "Author: " + _author + Environment.NewLine
                + "Year: " + _year + Environment.NewLine
                + "Journal: " + _journal + Environment.NewLine
                + "CosmicID: " + _cosmicId + Environment.NewLine
                + "PubmedID: " + _pubmedId + Environment.NewLine;
        }
        public string Title { get { return _title; } }
        public string Author { get { return _author; } }
        public string Year { get { return Convert.ToString(_year); } }
        public string Journal { get { return _journal; } }
        public string PubMedID { get { return _pubmedId; } }
    }
}
