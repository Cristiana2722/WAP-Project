using PAW.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAW
{
    public partial class MainForm : Form
    {
        private const string ConnectionString = "Data Source=PizzaDatabase.db";

        private List<Client> clients;

        private int currentClientIndex;

        public MainForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            clients = new List<Client>();
        }

        private void DisplayClients()
        {
            lv.Items.Clear();

            clients.Sort();

            foreach (Client client in clients)
            {
                var item = new ListViewItem(client.ClientId.ToString());
                item.SubItems.Add(client.LastName);
                item.SubItems.Add(client.FirstName);
                item.SubItems.Add(client.PhoneNo);

                item.SubItems.Add(client.ClientAddress.Street);
                item.SubItems.Add(client.ClientAddress.Floor);
                item.SubItems.Add(client.ClientAddress.Apartment);

                item.SubItems.Add(client.ClientPizza.PizzaType);
                item.SubItems.Add(client.ClientPizza.PizzaSize);

                item.SubItems.Add(client.ClientAddress.AddressId.ToString());
                item.SubItems.Add(client.ClientPizza.PizzaId.ToString());

                item.Tag = client;

                lv.Items.Add(item);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var client = new Client();
            AddEditForm addForm = new AddEditForm(client);
            if (DialogResult.OK == addForm.ShowDialog())
            {
                clients.Add(client);
                DisplayClients();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count == 0)
            {
                MessageBox.Show("Choose someone!");
                return;
            }

            ListViewItem selectedItem = lv.SelectedItems[0];
            Client client = (Client)selectedItem.Tag;

            AddEditForm editForm = new AddEditForm(client);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                clients.Clear();
                LoadClient();
                DisplayClients();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count == 0)
            {
                MessageBox.Show("Choose someone", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("Are you sure?", "Delete client", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ListViewItem selectedItem = lv.SelectedItems[0];
                    Client client = (Client)selectedItem.Tag;

                    DeleteClient(client);
                    DisplayClients();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #region MenuStrip
        private void serializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.Create("serialized.bin"))
                formatter.Serialize(stream, clients);
        }

        private void deserializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.OpenRead("serialized.bin"))
            {
                clients = (List<Client>)formatter.Deserialize(stream);
                DisplayClients();
            }
        }

        private void exportClientInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File | *.txt";
            saveFileDialog.Title = "Save as text file";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                try
                {
                    sw.WriteLine("ID, Last name, First name, Phone number");

                    foreach (var client in clients)
                    {
                        sw.WriteLine("{0}, {1}, {2}, {3}"
                            , client.ClientId
                            , client.LastName
                            , client.FirstName
                            , client.PhoneNo);
                    }
                }
                finally
                {
                    sw.Dispose();
                }
            }
            }

        private void exportAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File | *.txt";
            saveFileDialog.Title = "Save as text file";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                try
                {
                    foreach (var client in clients)
                    {
                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}"
                            , client.ClientId
                            , client.LastName
                            , client.FirstName
                            , client.PhoneNo
                            , client.ClientAddress.Street
                            , client.ClientAddress.Floor
                            , client.ClientAddress.Apartment
                            , client.ClientPizza.PizzaType
                            , client.ClientPizza.PizzaSize
                            , client.ClientAddress.AddressId
                            , client.ClientPizza.PizzaId);
                    }
                }
                finally
                {
                    sw.Dispose();
                }
            }
        }
        #endregion

        #region ToolStrip
        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a Pizza Delivery Application.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clients.Clear();
            LoadClient();
            DisplayClients();
        }
        #endregion

        #region Database
        private void LoadClient()
        {
            const string query = "SELECT c.ClientId, c.LastName, c.FirstName, c.PhoneNo, a.Street, a.Floor, a.Apartment, p.PizzaType, p.PizzaSize, a.AddressId, p.PizzaId " +
                "FROM Client c, Address a, Pizza p " +
                "WHERE c.AddressId = a.AddressId AND c.ClientId = p.ClientId";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int clientId = reader.GetInt32(reader.GetOrdinal("ClientId"));
                        string lastName = reader.GetString(reader.GetOrdinal("LastName"));
                        string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        string phoneNo = reader.GetString(reader.GetOrdinal("PhoneNo"));
                        string street = reader.GetString(reader.GetOrdinal("Street"));
                        string floor = reader.GetString(reader.GetOrdinal("Floor"));
                        string apartment = reader.GetString(reader.GetOrdinal("Apartment"));
                        string pizzaType = reader.GetString(reader.GetOrdinal("PizzaType"));
                        string pizzaSize = reader.GetString(reader.GetOrdinal("PizzaSize"));
                        int addressId = reader.GetInt32(reader.GetOrdinal("AddressId"));
                        int pizzaId = reader.GetInt32(reader.GetOrdinal("PizzaId"));

                        Client client = new Client(clientId, lastName, firstName, phoneNo, street, floor, apartment, pizzaType, pizzaSize, addressId, pizzaId);
                        clients.Add(client);
                    }
                }
            }
        }

        private void DeleteClient(Client client)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {

                        const string deleteClientQuery = "DELETE FROM Client WHERE ClientId = @ClientId";
                        using (SQLiteCommand deletePrescriptionsCommand = new SQLiteCommand(deleteClientQuery, connection))
                        {
                            deletePrescriptionsCommand.Parameters.AddWithValue("@ClientId", client.ClientId);
                            deletePrescriptionsCommand.ExecuteNonQuery();
                        }


                        const string deleteAddressQuery = "DELETE FROM Address WHERE ClientId = @ClientId";
                        using (SQLiteCommand deleteDoctorsCommand = new SQLiteCommand(deleteAddressQuery, connection))
                        {
                            deleteDoctorsCommand.Parameters.AddWithValue("@ClientId", client.ClientId);
                            deleteDoctorsCommand.ExecuteNonQuery();
                        }


                        const string deletePizzaQuery = "DELETE FROM Pizza WHERE ClientId = @ClientId";
                        using (SQLiteCommand deletePatientsCommand = new SQLiteCommand(deletePizzaQuery, connection))
                        {
                            deletePatientsCommand.Parameters.AddWithValue("@ClientId", client.ClientId) ;
                            deletePatientsCommand.ExecuteNonQuery();
                        }
                        clients.Remove(client);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        transaction.Rollback();

                    }
                }
            }
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadClient();
                DisplayClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region StatusStrip
        private void btnAdd_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatus.Text = "Add a client to the database";
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatus.Text = string.Empty;
        }

        private void btnEdit_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatus.Text = "Edit a client";
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatus.Text = string.Empty;
        }
        private void btnDelete_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatus.Text = "Delete a client from the database";
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatus.Text = string.Empty;
        }

        private void btnInfo_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatus.Text = "Information about the application";
        }

        private void btnInfo_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatus.Text = string.Empty;
        }

        private void btnExit_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatus.Text = "Exit";
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatus.Text = string.Empty;
        }
        private void btnRefresh_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatus.Text = "Refresh list";
        }
        private void btnRefresh_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatus.Text = string.Empty;
        }
        #endregion

        #region ContextMenuStrip
        private void darkThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(229, 51, 127);
            labelName.ForeColor = Color.White;
            btnAdd.ForeColor = Color.White;
            btnAdd.BackColor = Color.FromArgb(229, 51, 127);
            btnEdit.ForeColor = Color.White;
            btnEdit.BackColor = Color.FromArgb(229, 51, 127);
            btnDelete.ForeColor = Color.White;
            btnDelete.BackColor = Color.FromArgb(229, 51, 127);
            menuStripMain.ForeColor = Color.White;
            menuStripMain.BackColor = Color.FromArgb(229, 51, 127);
            statusStripMain.ForeColor = Color.White;
            statusStripMain.BackColor = Color.FromArgb(229, 51, 127);
        }

        private void lightThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
            labelName.ForeColor = SystemColors.ControlText;
            btnAdd.ForeColor = Color.Black;
            btnAdd.BackColor = Color.White;
            btnEdit.ForeColor = Color.Black;
            btnEdit.BackColor = Color.White;
            btnDelete.ForeColor = Color.Black;
            btnDelete.BackColor = Color.White;
            menuStripMain.ForeColor = SystemColors.ControlText;
            menuStripMain.BackColor = SystemColors.Control;
            statusStripMain.ForeColor = SystemColors.ControlText;
            statusStripMain.BackColor = SystemColors.Control;
        }
        #endregion

        #region Statistics
        private void btnStat_Click(object sender, EventArgs e)
        {
            Statistics statForm = new Statistics();
            statForm.ShowDialog();
        }
        private void btnStat_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatus.Text = "Some relevant statistics";
        }
        private void btnStat_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatus.Text = string.Empty;
        }
        #endregion

        #region Print
        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog.PageSettings = printDocument.DefaultPageSettings;

            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
                printDocument.DefaultPageSettings = pageSetupDialog.PageSettings;
        }

        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            currentClientIndex = 0;
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Microsoft Sans Serif", 18);

            var pageSettings = e.PageSettings;

            var printAreaHeight = e.MarginBounds.Height;

            var printAreaWidth = e.MarginBounds.Width;

            var marginLeft = pageSettings.Margins.Left;

            var marginTop = pageSettings.Margins.Top;

            if (pageSettings.Landscape)
            {
                var intTemp = printAreaHeight;
                printAreaHeight = printAreaWidth;
                printAreaWidth = intTemp;


                const int rowHeight = 40;
                var columnWidth = printAreaWidth / 4 + 60;

                StringFormat fmt = new StringFormat(StringFormatFlags.LineLimit);
                fmt.Trimming = StringTrimming.EllipsisCharacter;

                var currentY = marginTop;
                var currentX = marginLeft;

                e.Graphics.DrawRectangle(Pens.Black, currentX, currentY, columnWidth, rowHeight);
                e.Graphics.DrawString("Last name", font, Brushes.Black, new RectangleF(currentX, currentY, columnWidth, rowHeight), fmt);
                currentX += columnWidth;

                e.Graphics.DrawRectangle(Pens.Black, currentX, currentY, columnWidth, rowHeight);
                e.Graphics.DrawString("Phone no.", font, Brushes.Black, new RectangleF(currentX, currentY, columnWidth, rowHeight), fmt);
                currentX += columnWidth;

                e.Graphics.DrawRectangle(Pens.Black, currentX, currentY, columnWidth, rowHeight);
                e.Graphics.DrawString("Pizza type", font, Brushes.Black, new RectangleF(currentX, currentY, columnWidth, rowHeight), fmt);
                currentX += columnWidth;

                e.Graphics.DrawRectangle(Pens.Black, currentX, currentY, columnWidth, rowHeight);
                e.Graphics.DrawString("Pizza size", font, Brushes.Black, new RectangleF(currentX, currentY, columnWidth, rowHeight), fmt);
                currentX += columnWidth;

                currentY += rowHeight;

                while (currentClientIndex < clients.Count)
                {
                    currentX = marginLeft;

                    e.Graphics.DrawRectangle(Pens.Black, currentX, currentY, columnWidth, rowHeight);
                    e.Graphics.DrawString(clients[currentClientIndex].LastName, font, Brushes.Black, currentX, currentY, fmt);
                    currentX += columnWidth;

                    e.Graphics.DrawRectangle(Pens.Black, currentX, currentY, columnWidth, rowHeight);
                    e.Graphics.DrawString(clients[currentClientIndex].PhoneNo, font, Brushes.Black, currentX, currentY, fmt);
                    currentX += columnWidth;

                    e.Graphics.DrawRectangle(Pens.Black, currentX, currentY, columnWidth, rowHeight);
                    e.Graphics.DrawString(clients[currentClientIndex].ClientPizza.PizzaType, font, Brushes.Black, currentX, currentY, fmt);
                    currentX += columnWidth;

                    e.Graphics.DrawRectangle(Pens.Black, currentX, currentY, columnWidth, rowHeight);
                    e.Graphics.DrawString(clients[currentClientIndex].ClientPizza.PizzaSize, font, Brushes.Black, currentX, currentY, fmt);
                    currentX += columnWidth;

                    currentClientIndex++;

                    currentY += rowHeight;

                    if (currentY + rowHeight > printAreaHeight)
                    {
                        e.HasMorePages = true;
                        break;
                    }
                }
            }
            else
            {
                var columnWidth = printAreaWidth / 3;
                const int rowHeight = 40;

                StringFormat fmt = new StringFormat(StringFormatFlags.LineLimit);
                fmt.Trimming = StringTrimming.EllipsisCharacter;

                var currentY = marginTop;
                var currentX = marginLeft;

                e.Graphics.DrawRectangle(Pens.Black, currentX, currentY, columnWidth, rowHeight);
                e.Graphics.DrawString("Phone no.", font, Brushes.Black, new RectangleF(currentX, currentY, columnWidth, rowHeight), fmt);
                currentX += columnWidth;

                e.Graphics.DrawRectangle(Pens.Black, currentX, currentY, columnWidth, rowHeight);
                e.Graphics.DrawString("Pizza type", font, Brushes.Black, new RectangleF(currentX, currentY, columnWidth, rowHeight), fmt);
                currentX += columnWidth;

                e.Graphics.DrawRectangle(Pens.Black, currentX, currentY, columnWidth, rowHeight);
                e.Graphics.DrawString("Pizza size", font, Brushes.Black, new RectangleF(currentX, currentY, columnWidth, rowHeight), fmt);
                currentX += columnWidth;

                currentY += rowHeight;

                while (currentClientIndex < clients.Count)
                {
                    currentX = marginLeft;

                    e.Graphics.DrawRectangle(Pens.Black, currentX, currentY, columnWidth, rowHeight);
                    e.Graphics.DrawString(clients[currentClientIndex].PhoneNo, font, Brushes.Black, currentX, currentY, fmt);
                    currentX += columnWidth;

                    e.Graphics.DrawRectangle(Pens.Black, currentX, currentY, columnWidth, rowHeight);
                    e.Graphics.DrawString(clients[currentClientIndex].ClientPizza.PizzaType, font, Brushes.Black, currentX, currentY, fmt);
                    currentX += columnWidth;

                    e.Graphics.DrawRectangle(Pens.Black, currentX, currentY, columnWidth, rowHeight);
                    e.Graphics.DrawString(clients[currentClientIndex].ClientPizza.PizzaSize, font, Brushes.Black, currentX, currentY, fmt);
                    currentX += columnWidth;

                    currentClientIndex++;

                    currentY += rowHeight;

                    if (currentY + rowHeight > printAreaHeight)
                    {
                        e.HasMorePages = true;
                        break;
                    }
                }
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialog.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDocument.Print();
        }
        #endregion

        #region Drag&Drop
        private void lv_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void lv_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (filePaths.Length > 0)
                {
                    string filePath = filePaths[0];

                    InsertContentIntoDatabase(filePath);
                }
            }
        }
        private void InsertContentIntoDatabase(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    foreach (string line in lines)
                    {
                        string[] values = line.Split(',');

                        if (values.Length == 11)
                        {
                            int ClientId = int.Parse(values[0]);
                            string LastName = values[1];
                            string FirstName = values[2];
                            string PhoneNo = values[3];
                            string Street = values[4];
                            string Floor = values[5];
                            string Apartment = values[6];
                            string PizzaType = values[7];
                            string PizzaSize = values[8];
                            int AddressId = int.Parse(values[9]);
                            int PizzaId = int.Parse(values[10]);

                            var insertClient = "INSERT INTO Client(ClientId, AddressId, LastName, FirstName, PhoneNo)" + " VALUES (@ClientId, @AddressId, @LastName, @FirstName, @PhoneNo); " + "SELECT last_insert_rowid()";
                            using (SQLiteCommand insertCommand = new SQLiteCommand(insertClient, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@ClientId", ClientId);
                                insertCommand.Parameters.AddWithValue("@AddressId", AddressId);
                                insertCommand.Parameters.AddWithValue("@LastName", LastName);
                                insertCommand.Parameters.AddWithValue("@FirstName", FirstName);
                                insertCommand.Parameters.AddWithValue("@PhoneNo", PhoneNo);

                                insertCommand.ExecuteNonQuery();
                            }

                            var insertAddress = "INSERT INTO Address(AddressId, ClientId, Street, Floor, Apartment)" + " VALUES (@AddressId, @ClientId, @Street, @Floor, @Apartment); " + "SELECT last_insert_rowid()";
                            using (SQLiteCommand insertCommand = new SQLiteCommand(insertAddress, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@AddressId", AddressId);
                                insertCommand.Parameters.AddWithValue("@ClientId", ClientId);
                                insertCommand.Parameters.AddWithValue("@Street", Street);
                                insertCommand.Parameters.AddWithValue("@Floor", Floor);
                                insertCommand.Parameters.AddWithValue("@Apartment", Apartment);

                                insertCommand.ExecuteNonQuery();
                            }

                            string insertPizza = "INSERT INTO Pizza(PizzaId, ClientId, PizzaType, PizzaSize)" + " VALUES (@PizzaId, @ClientId, @PizzaType, @PizzaSize); " + "SELECT last_insert_rowid()";
                            using (SQLiteCommand insertCommand = new SQLiteCommand(insertPizza, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@PizzaId", PizzaId);
                                insertCommand.Parameters.AddWithValue("@ClientId", ClientId);
                                insertCommand.Parameters.AddWithValue("@PizzaType", PizzaType);
                                insertCommand.Parameters.AddWithValue("@PizzaSize", PizzaSize);

                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
