using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace _04_ComboBox
{
    public partial class Form1 : Form
    {
        private List<Person> persons;
        private BindingSource bindingSource;

        public Form1()
        {
            InitializeComponent();
            InitializeComboBoxWithStrings();
            InitializeComboBoxWithEnums();
            InitializeComboBoxWithObjects();
        }

        #region strings

        [SuppressMessage("ReSharper", "CoVariantArrayConversion")]
        private void InitializeComboBoxWithStrings()
        {
            var items = new[]
            {
                "C#-Programmierung",
                "Projektmanagement",
                "Entwurfsmuster",
                "Windows Forms"
            };
            stringsComboBox.Items.AddRange(items);
            const int indexDesErstenComboBoxEintrags = 0;
            stringsComboBox.SelectedIndex = indexDesErstenComboBoxEintrags; // Ohne diese Zeile ist anfänglich kein Wert selektiert
        }

        private void stringsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSelectionOfStringComboBoxLabel.Text = stringsComboBox.SelectedItem.ToString();

            //// Alternative, wenn man über den "sender" gehen will, und den Code
            //// wiederverwendbar machen will für andere ComboBoxen
            //bool isComboBox = sender is ComboBox;
            //if (isComboBox)
            //{
            //    ComboBox thisComboBox = sender as ComboBox;
            //    currentSelectionOfStringComboBoxLabel.Text = thisComboBox.SelectedText.ToString();  
            //}
        }

        #endregion

        #region enums

        private enum FuelTypes
        {
            Bleifrei95,
            Bleifrei98,
            Diesel
        }

        private void InitializeComboBoxWithEnums()
        {
            enumsComboBox.DataSource = Enum.GetValues(typeof(FuelTypes));
            enumsComboBox.SelectedItem = (int)FuelTypes.Diesel;
        }

        private void enumsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1/2: Selected item setzen
            currentSelectionOfEnumsComboBoxLabel.Text = enumsComboBox.SelectedItem.ToString();

            // 2/2: Treibstoffpreis setzen
            // Auswahl mit switch auswerten
            switch ((FuelTypes)enumsComboBox.SelectedItem) // SelectedItem ist vom Typ object
            {
                case FuelTypes.Bleifrei95:
                    SetPrice(1.49);
                    break;
                case FuelTypes.Bleifrei98:
                    SetPrice(1.50);
                    break;
                case FuelTypes.Diesel:
                    SetPrice(1.67);
                    break;
            }
        }

        private void SetPrice(double price)
        {
            priceLabel.Text = $"{price:C2}";
        }

        #endregion

        #region objects

        public void InitializeComboBoxWithObjects()
        {
            // Databinding einer Liste
            persons = new List<Person>
            {
                new Person {Id = 11, Firstname = "Viktor", Lastname = "Giacobbo"},
                new Person {Id = 22, Firstname = "Marco", Lastname = "Rima"},
                new Person {Id = 33, Firstname = "Massimo", Lastname = "Rocchi"}
            };


            // https://stackoverflow.com/a/26006620
            objectsComboBox.ValueMember = "Id";
            objectsComboBox.DisplayMember = "Lastname"; // Name der anzeigten Eigenschaft
            //objectsComboBox.DisplayMember = "Firstname";
            bindingSource = new BindingSource();
            bindingSource.DataSource = persons;


            // Databinding mit ComboBox aufsetzen
            objectsComboBox.DataSource = bindingSource; // Muss IList- oder IListSource-Interface implementieren

            // Databinding mit den drei TextBox-Controls aufsetzen
            // Das ist eine two-way Binding, d.h. Ändern der Werte in der Textbox ändert das Person-Objekt im Speicher und umgekehrt
            personIdTextBox.DataBindings.Add(
                /*Eigenschaft des Textboxes*/ "Text",
                /*Objekt*/ bindingSource,
                /*Eigenschaft des Objekts*/ "Id");
            personFirstnameTextBox.DataBindings.Add("Text", bindingSource, "Firstname");
            personLastnameTextBox.DataBindings.Add("Text", bindingSource, "Lastname", true, DataSourceUpdateMode.OnValidation);

            // Änderung auf dem Modell löst Databinding-Synchronisation aus;
            objectsComboBox.SelectedItem = persons[2];
        }

        private void objectsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Unterschied von ValueMember und DisplayMember illustrieren
            Debug.WriteLine("---");
            Debug.WriteLine($"ValueMember [{objectsComboBox.ValueMember}]: {objectsComboBox.SelectedValue}"); // ValueMember haben wir oben auf "Id" gestellt und darum kommt hier die Id
            Debug.WriteLine($"DisplayMember [{objectsComboBox.DisplayMember}]: {objectsComboBox.Text}");      // DisplayMember haben wir oben auf "Lastname" gestellt und darum kommt hier die Lastname
            Debug.WriteLine($"SelectedItem [{objectsComboBox.SelectedItem}]: {objectsComboBox.SelectedItem}");// SelectedItem haben wir oben mit einer List<Person> verhängt und darum kommt hier ein Object vom Typ Person
        }

        private void ButtonUpdatePerson(object sender, EventArgs e)
        {
            #region Variante 1: Mit Data-binding
            persons[2].Lastname = persons[2].Lastname + "x"; // Damit das funktioniert, braucht es INotifyPropertyChanged in der Person-Klasse

            // Wenn Person das Interface INotifyPropertyChanged implementiert, braucht es hier keine Logik mehr um GUI-Komponenten
            // zu aktualisieren.
            #endregion


            #region Variante 2: Ohne Data-binding

            // Die alternative wäre, Person ohne das INotifyPropertyChanged-Interface zu implementieren (so wie wir es bisher immer gemacht
            // haben), dafür müssten wir hier aber Code haben, um GUI-Komponenten zu aktualisieren.

            // Beispiel:
            //// Schritt 1/3: Person-Objekt aktualisieren
            //// persons[2].Lastname = persons[2].Lastname + "x";
            //// Schritt 2/3: Erste gebunde GUI-Komponente, die ComboBox, aktualisieren
            //objectsComboBox.DataSource = null;
            //objectsComboBox.ValueMember = "Id";
            //objectsComboBox.DisplayMember = "Lastname"; // Name der anzeigten Eigenschaft
            //objectsComboBox.DataSource = bindingSource;
            //// Schritt 3/3: Zweite gebundene GUI-Komponente, die TextBox für den Familiennamen, aktualisieren
            //personLastnameTextBox.DataBindings.Clear();
            //personLastnameTextBox.DataBindings.Add("Text", bindingSource, "Lastname");

            #endregion
        }

        #endregion

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}