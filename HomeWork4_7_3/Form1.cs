using System.Reflection;

namespace HomeWork4_7_3 {
    public partial class Form1 : Form {

        private Assembly assembly;

        public Form1() {
            InitializeComponent();
        }

        private void menuOpenFile_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                try {
                    assembly = Assembly.LoadFile(openFileDialog1.FileName);
                } catch (Exception exc) {
                    MessageBox.Show("ви втворили повну херню");
                    return;
                }

                lvMembers.Items.Clear();
                lblFileName.Text = Path.GetFileName(openFileDialog1.FileName);
                LoadTypes();
            }
        }

        private void LoadTypes() {
            lvTypes.BeginUpdate();

            lvTypes.Items.Clear();
            var assemblyTypes = assembly.GetTypes();
            foreach (var t in assemblyTypes) {
                var lvi = lvTypes.Items.Add(t.FullName);
                lvi.SubItems.Add(t.IsPublic ? "Так" : "Ні");
            }

            lvTypes.EndUpdate();
        }

        private void lvTypes_SelectedIndexChanged(object sender, EventArgs e) {
            LoadMembers();
        }

        private void LoadMembers() {
            if (lvTypes.SelectedItems.Count == 0) {
                // clear previously displayed members
                lvMembers.Items.Clear();
            } else {
                // list methods/properies from selected type
                var selectedTypeName = lvTypes.SelectedItems[0].Text;

                var type = assembly.GetType(selectedTypeName);
                lvMembers.BeginUpdate();
                lvMembers.Items.Clear();

                var grpMethods = lvMembers.Groups[0];
                var grpProps = lvMembers.Groups[1];
                var grpFields = lvMembers.Groups[2];
                var grpEvents = lvMembers.Groups[3];

                if (chbMethods.Checked) {
                    var methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(m => !m.IsSpecialName);
                    foreach (var m in methods) {
                        var lvi = lvMembers.Items.Add(m.Name);
                        lvi.SubItems.Add(m.IsPublic ? "Так" : "Ні");
                        lvi.Group = grpMethods;
                    }
                }
                if (chbProperties.Checked) {
                    var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    foreach (var m in props) {
                        var lvi = lvMembers.Items.Add(m.Name);
                        lvi.SubItems.Add(m.CanWrite ? "Так" : "Ні");
                        lvi.Group = grpProps;
                    }
                }
                if (chbFields.Checked) {
                    var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    foreach (var m in fields) {
                        var lvi = lvMembers.Items.Add(m.Name);
                        lvi.SubItems.Add(m.IsPublic ? "Так" : "Ні");
                        lvi.Group = grpFields;
                    }
                }
                if (chbEvents.Checked) {
                    var events = type.GetEvents(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    foreach (var m in events) {
                        var lvi = lvMembers.Items.Add(m.Name);
                        //lvi.SubItems.Add(m. ? "Так" : "Ні");
                        lvi.Group = grpEvents;
                    }
                }
                lvMembers.EndUpdate();
            }
        }

        private void FiltersCheckboxChanged(object sender, EventArgs e) {
            LoadMembers();
        }
    }
}
