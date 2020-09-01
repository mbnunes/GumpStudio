using System;
using System.IO;
using System.Windows.Forms;
using Ultima;

namespace GumpStudio.Forms
{
    public partial class ClilocBrowserForm : Form
    {
        private StringList _stringList;

        public int CliLocId { get; set; }

        public ClilocBrowserForm()
        {
            InitializeComponent();
        }

        private void ClilocBrowserForm_Load(object sender, EventArgs e)
        {
            foreach (var file in Directory.GetFiles(XMLSettings.CurrentOptions.ClientPath, "Cliloc.*"))
            {
                LanguageComboBox.Items.Add(Path.GetExtension(file).Substring(1));
            }

            LanguageComboBox.SelectedIndex = LanguageComboBox.Items.IndexOf("enu");
            _stringList = new StringList("enu");
        }

        private void cboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LanguageComboBox.SelectedIndex == -1)
            {
                return;
            }

            _stringList = new StringList(LanguageComboBox.Items[LanguageComboBox.SelectedIndex].ToString());

            EntriesListView.VirtualListSize = _stringList.Entries.Count;
            EntriesListView.BeginUpdate();
            EntriesListView.EndUpdate();
        }

        private void lvEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EntriesListView.SelectedIndices?.Count == 1)
            {
                CliLocId = int.Parse(EntriesListView.Items[EntriesListView.SelectedIndices[0]].Text);
            }
        }

        private void lvEntries_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (_stringList.Entries.Count == 0)
            {
                return;
            }

            var entry = _stringList.Entries[e.ItemIndex];
            e.Item = new ListViewItem(entry.Number.ToString());
            e.Item.SubItems.Add(entry.Text);
        }
    }
}
