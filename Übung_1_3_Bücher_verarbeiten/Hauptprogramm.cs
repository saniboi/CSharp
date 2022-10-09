using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Uebung_1_3_Bücher_verarbeiten
{
    public partial class Hauptprogramm : Form
    {
        public Hauptprogramm()
        {
            InitializeComponent();
        }

        private void LadeXmlDatei_Click(object sender, EventArgs e)
        {
            string xmlDateiPfad = @"Testdaten\Bücher.xml";
            string xmlString = File.ReadAllText(xmlDateiPfad);
            xmlTextBox.Text = xmlString;
        }

        private void ÖffneOrdner_Click(object sender, EventArgs e)
        {
            Process.Start("Testdaten");
        }

        private void SpeichereAlsXml_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"Testdaten\XmlExport.xml", xmlTextBox.Text);
        }

        private void SpeichereAlsCvs_Click(object sender, EventArgs e)
        {
            XDocument books = XDocument.Parse(xmlTextBox.Text);

            IEnumerable<string> queryTitleAndPrice =
                from book in books.Descendants("book")
                where (double)book.Element("price") < 20
                select $"{(string)book.Element("title")};{(string)book.Element("price")}";

            File.WriteAllLines(@"Testdaten\CsvExport.csv", queryTitleAndPrice.ToList());
        }

        private void FügeIsbnAttributHinzu_Click(object sender, EventArgs e)
        {
            XDocument books = XDocument.Parse(xmlTextBox.Text);
            IEnumerable<XElement> booksNodes = books.Descendants("book");
            foreach (XElement booksNode in booksNodes)
            {
                XAttribute isbnAttribute = new XAttribute("ISBN", "test isbn 123123123");
                booksNode.Add(isbnAttribute);
            }

            xmlTextBox.Text = books.ToString();
        }

        private void FügePublishingLocationXmlElementHinzu_Click(object sender, EventArgs e)
        {
            XDocument books = XDocument.Parse(xmlTextBox.Text);
            IEnumerable<XElement> booksNodes = books.Descendants("book");
            foreach (XElement booksNode in booksNodes)
            {
                XElement publishingLocationXmlElement = new XElement("publishing_location", "test publishing location 123123123");
                booksNode.Add(publishingLocationXmlElement);
            }

            xmlTextBox.Text = books.ToString();
        }
    }
}
