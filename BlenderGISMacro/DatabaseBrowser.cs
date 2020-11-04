using MacroMan.MacroActions;
using System;
using System.Data;
using System.Windows.Forms;

namespace MacroMan
{
    public partial class DatabaseBrowser : Form
    {
        private DataTable dataTable;
        private Func<DataTable> getDataTable;
        private Action<int, object, object> setDataValue;

        public DatabaseBrowser()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            if (dataTable != null)
            {
                dataTable.TableNewRow -= DataTable_TableNewRow;
                dataTable.RowDeleting -= DataTable_RowDeleting;
                dataTable.RowChanged -= DataTable_RowChanged;
            }

            dataTable = getDataTable();
            dataTable.TableNewRow += DataTable_TableNewRow;
            dataTable.RowDeleting += DataTable_RowDeleting;
            dataTable.RowChanged += DataTable_RowChanged;
            databaseGridView.DataSource = dataTable;
        }
        public void SetupData(Func<DataTable> _getDataTable, Action<int, object, object> _setDataValue)
        {
            getDataTable = _getDataTable;
            setDataValue = _setDataValue;

            RefreshData();
        }

        private void UpdateRowInDatabase(int integerId)
        {
            if (integerId >= 0)
                setDataValue(integerId, dataTable.Rows[integerId][2], dataTable.Rows[integerId][1]);
        }
        private void DataTable_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            UpdateRowInDatabase(dataTable.Rows.IndexOf(e.Row));
        }

        private void DataTable_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            dataTable.Columns[0].ReadOnly = false;
            int startIndex = dataTable.Rows.IndexOf(e.Row);
            for (int i = startIndex + 1; i < dataTable.Rows.Count; i++)
            {
                dataTable.Rows[i].SetField(0, i - 1);
            }
            dataTable.Columns[0].ReadOnly = true;
        }

        private void DataTable_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            int primaryKey = dataTable.Rows.Count;
            e.Row.SetField(0, primaryKey);
        }

        private void databaseGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //UpdateRowInDatabase(e.RowIndex); //I want to add this since sometimes clicking outside of a cell doesn't apply changes, but it happens with new rows and because of that it would cause an error since the row doesn't exist yet
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
