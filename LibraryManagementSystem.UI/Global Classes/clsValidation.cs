using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DVLD.Global_Classes
{
    public class clsValidation {

        public static bool IsValidTextBox(string value) =>
        !string.IsNullOrWhiteSpace(value);

        //public static bool ValidateTextBox(string value, ErrorProvider errorProvider, string error_message) {
        //    if (string.IsNullOrWhiteSpace(textBox.Text)) {
        //        errorProvider.SetError(value, $"{error_message}");
        //        return false;
        //    }

        //    errorProvider.SetError(value, "");
        //    return true;
        //}

        public static bool IsValidName(string name, int minLength = 2, int maxLength = 50) {
            return IsValidTextBox(name) &&
                   name.Length >= minLength &&
                   name.Length <= maxLength &&
                   Regex.IsMatch(name, @"^[A-Za-z\s]+$");
        }

        public static bool IsValidEmail(string email) {
            //if (string.IsNullOrWhiteSpace(email)) return false;
            if(email == "") return true;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool IsValidPhone(string phone) {
            //if (string.IsNullOrWhiteSpace(phone)) return false;
            if(phone == "") return true;
            return Regex.IsMatch(phone, @"^\d{7,15}$");
        }

        public static bool IsValidDate(DateTime date, int minimumDate = 10) {
            return date <= DateTime.Now.AddYears(-minimumDate);
        }

        public static bool ValidateEmail(string emailAddress) {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            var regex = new Regex(pattern);
            return regex.IsMatch(emailAddress);
        }

        public static bool ValidateInteger(string Number) {
            var pattern = @"^[0-9]*$";
            var regex = new Regex(pattern);
            return regex.IsMatch(Number);
        }

        public static bool ValidateFloat(string Number) {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";
            var regex = new Regex(pattern);
            return regex.IsMatch(Number);
        }

        public static bool IsNumber(string Number){
            return (ValidateInteger(Number) || ValidateFloat(Number));
        }

    }
}
