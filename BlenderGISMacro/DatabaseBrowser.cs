using System;
using System.Data;
using System.Windows.Forms;

namespace MacroMan
{
    public partial class DatabaseBrowser : Form
    {
        private DataTable dataTable;
        private Func<DataTable> getDataTable;
        private Func<string> getExt;
        private Action<int, object, object> setDataValue;
        private Action<string> exportValues, importValues;

        public DatabaseBrowser()
        {
            InitializeComponent();

            foreach (ToolStripMenuItem menuItem in menuStrip1.Items)
                ((ToolStripDropDownMenu)menuItem.DropDown).ShowImageMargin = false;
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
        public void SetupData(Func<DataTable> _getDataTable, Action<int, object, object> _setDataValue, Action<string> _exportValues, Action<string> _importValues, Func<string> _getExt)
        {
            getDataTable = _getDataTable;
            setDataValue = _setDataValue;
            exportValues = _exportValues;
            importValues = _importValues;
            getExt = _getExt;

            RefreshData();
        }

        private void UpdateRowInDatabase(int valueId)
        {
            if (valueId >= 0)
                setDataValue(valueId, dataTable.Rows[valueId][2], dataTable.Rows[valueId][1]);
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

        private SaveFileDialog DefaultSaveDialog()
        {
            var saveDialog = new SaveFileDialog();
            var ext = getExt();
            saveDialog.Filter = "Database file (*." + ext + ")|*." + ext + "|All files (*.*)|*.*";
            saveDialog.AddExtension = true;
            saveDialog.CheckPathExists = true;
            string initialDirectory = Environment.CurrentDirectory;
            saveDialog.InitialDirectory = initialDirectory;
            return saveDialog;
        }
        private OpenFileDialog DefaultOpenDialog()
        {
            var openDialog = new OpenFileDialog();
            var ext = getExt();
            openDialog.Filter = "Database file (*." + ext + ")|*." + ext + "|All files (*.*)|*.*";
            openDialog.AddExtension = true;
            openDialog.CheckPathExists = true;
            openDialog.CheckFileExists = true;
            string initialDirectory = Environment.CurrentDirectory;
            openDialog.InitialDirectory = initialDirectory;
            return openDialog;
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openDialog = DefaultOpenDialog();
            var result = openDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                importValues(openDialog.FileName);
                RefreshData();
            }
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataTable.Rows.Count > 0)
            {
                var saveDialog = DefaultSaveDialog();
                var result = saveDialog.ShowDialog();
                if (result == DialogResult.OK)
                    exportValues(saveDialog.FileName);
            }
            else
                MessageBox.Show("Cannot save an empty database", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
