using JournalDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace JournalApp.SettingsForms
{
    public partial class DictionaryPlainList : JournalAppDataForm, IPreparation
    {
        Parameters parameters;
        DB db;
        DbSet data;
        public object SelectedResult;
        protected bool SelectMode;
        public DictionaryPlainList()
        {
            InitializeComponent();
        }

        public void Prepare()
        {
            Prepare((Parameters)Tag);
        }
        public void Prepare(Parameters parameters)
        {
            this.parameters = parameters;
            lblWindowCaption.Text = parameters.Caption;
            string typeName = parameters.TypeName;
            SelectMode = parameters.SelectMode;
            var type = GetObjectType(typeName);
            ConnectDB(type);
            ReloadData(type);
            if (SelectMode)
                dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private Type GetObjectType(string TypeName)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Type type = null;
            foreach (Assembly asm in assemblies)
            {
                var typeList = asm.GetTypes();
                type = typeList.FirstOrDefault(t => t.FullName == TypeName);
                if (type != null) break;
            }
            return type;
        }

        private void ConnectDB(Type type)
        {

            if (type != null)
            {
                db = new DB();
                data = db.Set(type);
                data.Load();
            }
        }

        private void ReloadData(Type type)
        {
            if (type != null)
            {
                dgvData.DataSource = null;
                var localdata = data.Local;
                if (localdata.Count > 0)
                    dgvData.DataSource = localdata;


                //var keyprop=Array.Find(properties, p=>Array.Find(p.GetCustomAttributes(false),ca=>ca is KeyAttribute)!=null);
                if (localdata.Count > 0)
                {
                    var properties = localdata[0].GetType().GetProperties();
                    foreach (DataGridViewColumn column in dgvData.Columns)
                    {
                        var columnProperty = Array.Find(properties, p => p.Name == column.DataPropertyName);
                        if (columnProperty != null)
                        {
                            var attributes = columnProperty.GetCustomAttributes(false);
                            var keyAttr = Array.Find(attributes, a => a is KeyAttribute);
                            if (keyAttr != null)
                                column.ReadOnly = true;
                        }

                    }
                }

                for (int i = 0; i <= dgvData.Columns.Count - 1; i++)
                {
                    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                }
                dgvData.Refresh();
                dgvData.ReadOnly = SelectMode;
            }
        }

        public class Parameters
        {
            public string Caption;
            public string TypeName;
            public DbContext Context;
            public bool SelectMode = false;
        }

        private void DictionaryPlainList_FormClosed(object sender, FormClosedEventArgs e)
        {
            db?.Dispose();
        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                db?.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void tsmiAddLine_Click(object sender, EventArgs e)
        {
            var type = GetObjectType(parameters.TypeName);
            var obj = Activator.CreateInstance(type);
            data.Add(obj);
            try
            {
                db?.SaveChanges();
            }
            catch
            {

            }
            ReloadData(type);
        }

        private void tsmiDeleteLine_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dgvData.SelectedRows.Count > 0)
                {
                    var obj = dgvData.SelectedRows[0].DataBoundItem;
                    data.Remove(obj);
                    db?.SaveChanges();
                    var type = GetObjectType(parameters.TypeName);
                    ReloadData(type);
                }
            }
        }
        private void DgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!SelectMode) return;
            SelectedResult = data.Local[e.RowIndex];
            Close();
        }


        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

    }
}
