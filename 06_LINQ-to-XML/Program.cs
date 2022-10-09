using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
// ReSharper disable AssignNullToNotNullAttribute

namespace _06_LINQ_to_XML
{
    public class Program
    {
        [SuppressMessage("ReSharper", "UnreachableSwitchCaseDueToIntegerAnalysis")]
        public static void Main()
        {
            int beispiel = 2;

            switch (beispiel)
            {
                case 1:
                    XDocumentFunktioniertMitLinq();
                    break;
                case 2:
                    XmlTextReaderFunktioniertNichtMitLinq();
                    break;
            }
        }

        private static void XDocumentFunktioniertMitLinq()
        {
            // XDocument funktioniert mit LINQ
            XmlDatenViaXDocumentEinlesen();
            XmlDatenLesenUndInObjekteUmwandeln();
            XmlDatenMitXElementSchreiben();
            XmlElementHinzufügen();
            XmlDatenModifizieren();
            XmlDatenLöschen();
        }

        private static void XmlTextReaderFunktioniertNichtMitLinq()
        {
            // XmlTextReader funktioniert ohne LINQ
            XmlTextReaderBeispiel();
            XmlWriterBeispiel();
        }

        private static void XmlDatenViaXDocumentEinlesen()
        {
            Console.WriteLine("--- XmlDatenViaXDocumentEinlesen ---");
            string pathToXmlFile = @"InputData\Books.xml";
            XDocument books = XDocument.Load(pathToXmlFile);

            var queryTitleAndPrice =
                from book in books.Descendants("book")
                where (double)book.Element("price") < 20
                select $"{(string)book.Element("title")} (CHF {(string)book.Element("price")})";

            // Vorteil von LINQ
            // Mit prozeduralem Code wären vielen Zeilen zusammengekommen: Zeitaufwand, Kosten.
            // Mit der deklarativen LINQ-Syntax, kann man die Lösung in wenigen, sprechenden Zeilen Code lösen.

            foreach (string book in queryTitleAndPrice)
            {
                Console.WriteLine(book);
            }
        }

        private static void XmlDatenLesenUndInObjekteUmwandeln()
        {
            Console.WriteLine("\n--- XmlDatenLesenUndInObjekteUmwandeln ---");
            var provider = CultureInfo.InvariantCulture;
            var books = XDocument.Load(@"InputData\Books.xml");

            var bookList =
                from book in books.Descendants("book")
                select new Book
                {
                    Id = book.Attribute("id")?.Value,
                    Author = book.Element("author")?.Value,
                    Title = book.Element("title")?.Value,
                    Genre = book.Element("genre")?.Value,
                    Price = double.Parse(book.Element("price")?.Value),
                    PublishDate = DateTime.ParseExact(book.Element("publish_date")?.Value, "yyyy-MM-dd", provider),
                    Description = book.Element("description")?.Value
                };

            foreach (var book in bookList)
            {
                Console.WriteLine(
                    $"Book: {book.Id}, {book.Title}, {book.Author}, {book.Price} {book.PublishDate.ToShortDateString()}");
            }
        }

        private static void XmlDatenMitXElementSchreiben()
        {
            Console.WriteLine("\n--- XmlDatenMitXElementSchreiben ---");
            XElement books = new XElement("catalog",
                new XElement("book",
                    new XAttribute("id", "Twentyfour01"),
                    new XElement("author", "Jack Bauer"),
                    new XElement("title", "24 Hours"),
                    new XElement("genre", "Thriller"),
                    new XElement("price", "28.50"),
                    new XElement("publish_date", "2004-12-22"),
                    new XElement("description", "Jack is hunting for bad guys.")
                    ),
                new XElement("book",
                    new XAttribute("id", "Moonwalker01"),
                    new XElement("author", "Michael Jackson"),
                    new XElement("title", "24 Hours on the Moon"),
                    new XElement("genre", "Thriller"),
                    new XElement("price", "59.90"),
                    new XElement("publish_date", "2000-02-08"),
                    new XElement("description", "Michael is taking a walk on the moon.")
                )
            );
            books.Save("NewBooks.xml");
            Console.WriteLine("Siehe 'NewBooks.xml'");
        }

        private static void XmlElementHinzufügen()
        {
            Console.WriteLine("\n--- XmlElementHinzufügen ---");
            var books = XDocument.Load("NewBooks.xml");
            books.Element("catalog")?.Add(
                new XElement("book",
                    new XAttribute("id", "Moonwalker"),
                    new XElement("author", "Michael Jackson"),
                    new XElement("title", "24 Hours on the Moon"),
                    new XElement("genre", "Thriller"),
                    new XElement("price", "59.90"),
                    new XElement("publish_date", "2000-02-08"),
                    new XElement("description", "Michael is taking a walk on the moon.")
                )
            );
            books.Save("NewBooks2.xml");
            Console.WriteLine("Siehe 'NewBooks2.xml'");
        }

        private static void XmlDatenModifizieren()
        {
            Console.WriteLine("\n--- XmlDatenModifizieren ---");
            var books = XDocument.Load(@"InputData\Books.xml");
            XElement root = books.Root;
            root?.Elements("book")
                .Where(e => e.Attribute("id")?.Value == "bk103")
                .Select(e => e.Element("price")).Single()?.SetValue("9.95");
            root?.Elements("book")
                .Where(e => e.Attribute("id")?.Value == "bk104")
                .Select(e => e.Attribute("id")).Single()?.SetValue("myBK999");
            books.Save("NewBooks3_ModifiedBooks.xml");
        }

        private static void XmlDatenLöschen()
        {
            Console.WriteLine("\n--- XmlDatenLöschen ---");
            var books = XDocument.Load(@"InputData\Books.xml");
            XElement root = books.Root;
            root?.Elements("book")
                .Single(e => e.Attribute("id")?.Value == "bk103").Remove();
            books.Save("NewBooks4_RemoveBooks.xml");
        }

        [SuppressMessage("ReSharper", "RedundantBoolCompare")]
        private static void XmlTextReaderBeispiel()
        {
            Console.WriteLine("--- XmlTextReaderBeispiel ---");
            var reader = new XmlTextReader(@"InputData\Books.xml");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "catalog")
                    {
                        Console.WriteLine("Catalog");
                    }
                    if (reader.Name == "book")
                    {
                        if (reader.MoveToAttribute("id") == true)
                        {
                            Console.WriteLine($"Book: Id = {reader.Value}");
                        }
                    }
                    if (reader.Name == "author")
                    {
                        //Console.WriteLine($"   Author: {reader.Value}"); // Geht leider nicht wie bei Attributen
                        Console.WriteLine($"   Author: {reader.ReadElementContentAsString()}");
                    }
                }
            }
        }

        private static void XmlWriterBeispiel()
        {
            Console.WriteLine("\n--- XmlWriterBeispiel ---");

            var writer = new XmlTextWriter(@"out.xml", Encoding.UTF8);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartElement("catalog");
            writer.WriteStartElement("book");
            writer.WriteAttributeString("id", "myBookId");
            writer.WriteStartElement("author");
            writer.WriteValue("Stephen King");
            //writer.WriteEndElement(); // Wird von writer.Close() automatisch versucht zu schliessen mit AutoCompleteAll()
            //writer.WriteEndElement(); // Wird von writer.Close() automatisch versucht zu schliessen mit AutoCompleteAll()
            //writer.WriteEndElement(); // Wird von writer.Close() automatisch versucht zu schliessen mit AutoCompleteAll()
            writer.Flush(); // Ohne Flush() wir die Datei leer sein. https://stackoverflow.com/a/35845771
                            // Ein using würde Dipose aufrufen.
                            // Dispose würde Close() aufrufen
                            // Close() würde Flush() vor dem Close() aufrufen.
            writer.Close(); // Ohne Close steht nur folgendes in der Datei
                            // <catalog>
                            //   <book id="myBookId">
                            //     <author>Stephen King
                            //
                            // Interessanterweise schliesst Close() die fehlenden WriteEndElemente, weil in XmlTextWriter.Close()
                            // ein AutoCompleteAll() aufgerufen wird.



            //// Variante mit using
            //using (var writer = new XmlTextWriter(@"out.xml", Encoding.UTF8))
            //{
            //    writer.Formatting = Formatting.Indented;

            //    writer.WriteStartElement("catalog");
            //    writer.WriteStartElement("book");
            //    writer.WriteAttributeString("id", "myBookId");
            //    writer.WriteStartElement("author");
            //    writer.WriteValue("Stephen King");
            //    //writer.WriteEndElement();
            //    //writer.WriteEndElement();
            //    //writer.WriteEndElement();
            //    //writer.Flush(); // Braucht es nicht

            //    //writer.Close();
            //}
        }
    }
}