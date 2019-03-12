using System.Collections.Generic;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Utils
{
    public class TableMapper
    {
        public static IList<TableViewModel> GetTableModelFrom(IList<TablesLayout> tablesLayouts)
        {
            var returnedList = new List<TableViewModel>();
            foreach (var table in tablesLayouts)
            {
                returnedList.Add(new TableViewModel()
                {
                    id = table.localTableId,
                    hidden = table.hidden,
                    pinned = table.pinned,
                    position = new TablePosition()
                    {
                        x = table.position_x,
                        y = table.position_y,
                        w = table.position_w,
                        h = table.position_h
                    }

                });
            }
            return returnedList;
        }
    }
}
