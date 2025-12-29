using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.PMP.Utils
{
    internal class UltraGridHelper
    {
        #region ActiveRow 기억

        public static Dictionary<string, string> RememberActiveRow(
            UltraGrid grid,
            params string[] keyColumns)
        {
            var result = new Dictionary<string, string>();

            if (grid?.ActiveRow == null || grid.ActiveRow.Index < 0)
                return result;

            DataRow row = ((DataRowView)grid.ActiveRow.ListObject).Row;

            foreach (string col in keyColumns)
            {
                result[col] = row[col]?.ToString();
            }

            return result;
        }

        #endregion

        #region ActiveRow 복원

        public static void RestoreActiveRow(
            UltraGrid grid,
            Dictionary<string, string> keyValues)
        {
            if (grid == null || keyValues == null || keyValues.Count == 0)
                return;

            foreach (UltraGridRow row in grid.Rows)
            {
                DataRow dr = ((DataRowView)row.ListObject).Row;

                bool match = true;

                foreach (var kv in keyValues)
                {
                    if (dr[kv.Key]?.ToString() != kv.Value)
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    grid.ActiveRow = row;
                    row.Selected = true;
                    grid.ActiveRowScrollRegion.ScrollRowIntoView(row);
                    break;
                }
            }
        }

        #endregion
    }
}
