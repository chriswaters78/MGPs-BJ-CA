using System;
using System.Globalization;
using ClosedXML.Excel;

namespace BJ_CA
{

    // Excel Range behaviour the results export was written against, implemented over ClosedXML.
    public static class BJCAExcelExtensions
    {

        // Range.Offset: the same-sized range moved by rows/columns.
        public static IXLRange Offset(this IXLRange range, int rows, int columns)
        {
            var first = range.RangeAddress.FirstAddress;
            var last = range.RangeAddress.LastAddress;
            return range.Worksheet.Range(first.RowNumber + rows, first.ColumnNumber + columns, last.RowNumber + rows, last.ColumnNumber + columns);
        }

        // Range.End(xlDown) from the first cell: the last cell of the filled block below it, or the next
        // filled cell below a gap, or the bottom of the sheet if there is none.
        public static IXLRange EndDown(this IXLRange range)
        {
            var ws = range.Worksheet;
            var cell = range.FirstCell();
            int column = cell.Address.ColumnNumber;
            int row = cell.Address.RowNumber;

            if (row < XLHelper.MaxRowNumber && !ws.Cell(row + 1, column).IsEmpty())
            {
                while (row < XLHelper.MaxRowNumber && !ws.Cell(row + 1, column).IsEmpty())
                    row += 1;
            }
            else
            {
                var next = ws.Column(column).CellsUsed(c => c.Address.RowNumber > row && !c.IsEmpty());
                row = XLHelper.MaxRowNumber;
                foreach (var c in next)
                {
                    row = c.Address.RowNumber;
                    break;
                }
            }
            return ws.Range(row, column, row, column);
        }

        // Range.ClearContents: values and formulas only, formatting kept.
        public static void ClearContents(this IXLRange range)
        {
            range.Clear(XLClearOptions.Contents);
        }

        // Range.Select: makes this the sheet's only selection.
        public static void SelectOnly(this IXLRange range)
        {
            range.Worksheet.SelectedRanges.RemoveAll();
            range.Select();
            range.Worksheet.ActiveCell = range.FirstCell();
        }

        // Range.Formula = value: numbers and booleans are stored as such, and text is parsed the way
        // Excel parses typed entries ("=..." as a formula, "88" as a number, "False" as a boolean).
        public static void SetExcelValue(this IXLRange range, object value)
        {
            foreach (var cell in range.Cells())
                SetCell(cell, value);
        }

        private static void SetCell(IXLCell cell, object value)
        {
            switch (value)
            {
                case null:
                    cell.Value = Blank.Value;
                    break;
                case bool b:
                    cell.Value = b;
                    break;
                case string s:
                    if (s.Length > 1 && s[0] == '=')
                        cell.FormulaA1 = s.Substring(1);
                    else if (s.Length == 0)
                        cell.Value = Blank.Value;
                    else if (double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out double d))
                        cell.Value = d;
                    else if (string.Equals(s, "TRUE", StringComparison.OrdinalIgnoreCase))
                        cell.Value = true;
                    else if (string.Equals(s, "FALSE", StringComparison.OrdinalIgnoreCase))
                        cell.Value = false;
                    else
                        cell.Value = s;
                    break;
                default:
                    cell.Value = Convert.ToDouble(value, CultureInfo.InvariantCulture);
                    break;
            }
        }
    }
}
