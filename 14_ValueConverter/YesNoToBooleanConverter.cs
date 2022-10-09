using System;
using System.Windows.Data;

namespace _14_ValueConverter
{
    public class YesNoToBooleanConverter : IValueConverter
    {
        // Convert heisst vom Source zum Target
        //
        // Im Beispiel ist unsere Source die TextBox, wo wir "yes" und "no" reinschreiben.
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Zum Testen: in dieser Methode einen Haltepunkt setzen, Programm starten, "yes" in die TextBox schreiben und schauen, wie oft der ValueConverter aufgerufen wird


            // if int 7
            // "007" → Person.LuckyNumber(int) 7
            // 00088800

            switch (value?.ToString().ToLower())
            {
                case "yes":
                case "oui":
                    return true;
                case "no":
                case "non":
                    return false;
            }
            return false;
        }

        // ConvertBack heisst vom Target zur Source
        //
        // Im Beispiel haben wir zwei Target:
        // - einmal der TextBlock und
        // - einmal die CheckBox
        // Die Target ist das Objekt, wo wir das Binding-Schlüsselwort verwenden.
        // - <TextBlock Text="{Binding ElementName=TxtValue, ...
        // - <CheckBox IsChecked="{Binding ElementName=TxtValue, ...
        //
        // Im Beispiel haben wir eine Source:
        // - die TextBox
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool) value == true)
                {
                    return "yes";
                }
                else
                { 
                    return "no";
                }
            }
            return "no";
        }
    }
}