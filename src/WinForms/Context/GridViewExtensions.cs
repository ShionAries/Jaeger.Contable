using System;
using System.Windows.Forms;

namespace Jaeger.Contable.WinForms.Context {
    internal static class GridViewExtensions {
        public static void ColumnText(this DataGridView gridView, string propertyName, string headerText, string format = null) {
            gridView.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = propertyName,
                Name = propertyName,
                HeaderText = headerText,
                MinimumWidth = 70,
                DefaultCellStyle = { Format = format }
            });
        }

        public static void AddColumnText(this DataGridView gridView, string propertyName, string headerText, string format = null) {
            gridView.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = propertyName,
                Name = propertyName,
                HeaderText = headerText,
                MinimumWidth = 70,
                DefaultCellStyle = { Format = format }
            });
        }

        public static void AddColumnNumeric(this DataGridView gridView, string propertyName, string headerText, string format = null) {
            gridView.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = propertyName,
                Name = propertyName,
                HeaderText = headerText,
                MinimumWidth = 70,
                DefaultCellStyle = { 
                    Format = format, 
                    Alignment = DataGridViewContentAlignment.MiddleRight 
                }
            });
        }

        public static void ColumnComboBox(this DataGridView gridView, string propertyName, string headerText, string valueMember, string displayMember, int widthColumn = 100, int minimumWidth = 70) {
            gridView.Columns.Add(new DataGridViewComboBoxColumn {
                DataPropertyName = propertyName,
                Name = propertyName,
                HeaderText = headerText,
                Width = widthColumn,
                MinimumWidth = minimumWidth,
                ValueMember = valueMember,
                DisplayMember = displayMember
            });
        }

        public static void ToNumericUpDown(this NumericUpDown numericUpDown, int decimalPlaces) {
            numericUpDown.DecimalPlaces = decimalPlaces;
            numericUpDown.Maximum = 999999999999999m;
            numericUpDown.Minimum = -999999999999999m;
            numericUpDown.Increment = decimalPlaces == 6 ? 0.000001m : 0.0001m;
            numericUpDown.ThousandsSeparator = true;
            numericUpDown.TextAlign = HorizontalAlignment.Right;
        }

        public static decimal SetValueDecimal(double? x) {
            if (!x.HasValue || double.IsNaN(x.Value) || double.IsInfinity(x.Value))
                return 0m;
            if (x.Value > (double)decimal.MaxValue)
                return decimal.MaxValue;
            if (x.Value < (double)decimal.MinValue)
                return decimal.MinValue;
            return Convert.ToDecimal(x.Value);
        }

        public static DateTime? GetFecha(this DateTimePicker pickerDateTime) {
            return pickerDateTime.Checked ? pickerDateTime.Value.Date : (DateTime?)null;
        }

        public static void SetFecha(this DateTimePicker pickerDateTime, DateTime? v) {
            pickerDateTime.ShowCheckBox = true;
            pickerDateTime.Checked = v.HasValue;
            pickerDateTime.Value = v ?? DateTime.Today;
        }
    }
}
